using Meta.Core;
using Meta.Core.Attributes;
using Meta.Core.Interfaces;
using Meta.Editor.Commands;
using Meta.Editor.Windows;
using Meta.Structures.Flatbuffers;
using MetaEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Threading;

#nullable enable
namespace Meta.Editor.Controls
{
  [TemplatePart(Name = "PART_FilterTextBox", Type = typeof (MetaWatermarkTextbox))]
  [TemplatePart(Name = "PART_JsonTreeView", Type = typeof (TreeView))]
  public class FlatbufferControl : MetaBaseControl
  {
    private const string PART_FilterTextBox = "PART_FilterTextBox";
    private MetaWatermarkTextbox filterTb;
    private const string PART_JsonTreeView = "PART_JsonTreeView";
    private bool firstTimeLoad = true;
    private MetaTabItem controlTab;
    private bool expanded;
    protected TreeView dataTreeView;
    public Meta.Editor.Controls.Editor assetEditor;
    private FlatbufferSchema schema;
    private string activeFile;

    public MetaTabItem Tab
    {
      get => this.controlTab;
      set
      {
        if (value == this.controlTab)
          return;
        this.controlTab = value;
      }
    }

    public ObservableCollection<MetaFlatbufferItem> Items { get; set; } = new ObservableCollection<MetaFlatbufferItem>();

    public bool IsExpanded
    {
      get => this.expanded && this.Items.Count != 0;
      set => this.expanded = value;
    }

    public TreeView Tree => this.dataTreeView;

    public override string Icon => this.assetEditor.Icon;

    public string OpenFile
    {
      get => this.activeFile;
      set
      {
        if (!(value != this.activeFile))
          return;
        this.activeFile = value;
      }
    }

    public FlatbufferSchema Schema
    {
      get => this.schema;
      set
      {
        if (value == this.schema)
          return;
        this.schema = value;
      }
    }

    static FlatbufferControl()
    {
      FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (FlatbufferControl), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (FlatbufferControl)));
    }

    public FlatbufferControl(ILogger inLogger, FlatbufferSchema _schema, string _filename)
      : base(inLogger)
    {
      this.OpenFile = _filename;
      this.Schema = _schema;
      this._onEngineChange = this._onEngineChange + new MetaEngineChangeCallback(this.OnEngineChanged);
      this.LoadAsset(_filename);
    }

    public bool Initialize()
    {
      if (this.Schema.identifier == null)
        return false;
      var data = ((IEnumerable<Type>) Assembly.GetExecutingAssembly().GetTypes()).Where<Type>((Func<Type, bool>) (t => t.GetCustomAttributes(typeof (EditorTypeAttribute), true).Length != 0)).Where<Type>((Func<Type, bool>) (t => t.GetCustomAttributes(typeof (GameVersionAttribute), true).Cast<GameVersionAttribute>().Any<GameVersionAttribute>((Func<GameVersionAttribute, bool>) (attr => attr.Value.Equals(App.Game))))).Select(t => new
      {
        Type = t,
        Attributes = t.GetCustomAttributes(typeof (EditorTypeAttribute), true).Cast<EditorTypeAttribute>().FirstOrDefault<EditorTypeAttribute>()
      }).FirstOrDefault(x => x.Attributes.Value.Contains(this.Schema.identifier));
      Meta.Editor.Controls.Editor instance;
      if (data == null)
        instance = (Meta.Editor.Controls.Editor) Activator.CreateInstance(typeof (Meta.Editor.Controls.Editor), (object) App.Logger, (object) this.Schema, (object) this.OpenFile);
      else
        instance = (Meta.Editor.Controls.Editor) Activator.CreateInstance(data.Type, (object) App.Logger, (object) this.Schema, (object) this.OpenFile);
      this.assetEditor = instance;
      if (this.assetEditor == null)
        return false;
      this.assetEditor.FControl = this;
      return true;
    }

    public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      this.filterTb = this.GetTemplateChild("PART_FilterTextBox") as MetaWatermarkTextbox;
      this.dataTreeView = this.GetTemplateChild("PART_JsonTreeView") as TreeView;
      this.dataTreeView.SelectedItemChanged += new RoutedPropertyChangedEventHandler<object>(this.JsonTreeView_SelectedItemChanged);
      this.Loaded += new RoutedEventHandler(this.FlatBufferControl_Loaded);
      this.filterTb.TextChanged += new TextChangedEventHandler(this.FilterTb_LostFocus);
    }

    private void FilterTb_LostFocus(object sender, RoutedEventArgs e)
    {
      if (this.dataTreeView.Items == null || !(this.filterTb.Text == ""))
        return;
      this.dataTreeView.Items.Filter = (Predicate<object>) null;
    }

    public override List<ToolbarItem> RegisterToolbarItems()
    {
      List<ToolbarItem> toolbarItemList = base.RegisterToolbarItems();
      toolbarItemList.Add(new ToolbarItem("Export JSON", "Export to JSON", "ArrowUpBold", new RelayCommand((Action<object>) (state => this.ExportButton_Click((object) this, new RoutedEventArgs())))));
      toolbarItemList.InsertRange(toolbarItemList.Count, (IEnumerable<ToolbarItem>) this.assetEditor.RegisterToolbarItems());
      return toolbarItemList;
    }

    public override void Closed()
    {
      base.Closed();
      if (this.assetEditor == null)
        return;
      this.assetEditor.Shutdown();
    }

    private void ExportButton_Click(object sender, RoutedEventArgs e)
    {
      MetaSaveFileDialog saveDialog = new MetaSaveFileDialog("Export to JSON", "*.json (JSON File)|*.json", this.assetEditor.Asset.CName, this.assetEditor.Asset.CName, config: false);
      if (!saveDialog.ShowDialog())
        return;
      MetaTaskWindow.Show("Exporting to JSON", "", (MetaTaskCallback) (task => this.assetEditor.Export(saveDialog.FileName)));
    }

    private void ImportButton_Click(object sender, RoutedEventArgs e) => this.assetEditor.Import();

    private void JsonTreeView_SelectedItemChanged(
      object sender,
      RoutedPropertyChangedEventArgs<object> e)
    {
      TreeViewItem selectedItem = this.dataTreeView.SelectedItem as TreeViewItem;
      this.dataTreeView.ContextMenu = this.dataTreeView.Resources[(object) "SolutionContext"] as ContextMenu;
    }

    public void UpdateControlSource()
    {
      ((DispatcherObject) this).Dispatcher.BeginInvoke((Delegate) (() =>
      {
        this.Items.Clear();
        this.Items.Add(this.assetEditor.CreateRootNode());
        this.dataTreeView.ItemsSource = (IEnumerable) this.Items;
      }), Array.Empty<object>());
    }

    private void FlatBufferControl_Loaded(object sender, RoutedEventArgs e)
    {
      if (this.firstTimeLoad)
      {
        this.Engine = (EngineVersion) 0;
        this.dataTreeView.PreviewMouseRightButtonDown += new MouseButtonEventHandler(this.TreeViewItem_PreviewMouseRightButtonDown);
        MetaSchemaWindow.Show(this.Asset, this.Schema, (MetaSchemaCallback) (task => this.OnDeserializerSuccess(task)), (MetaSchemaFailedCallback) (task => this.OnDeserializerFailed()));
        this.firstTimeLoad = false;
        this.DataContext = (object) this;
      }
      App.DiscordManager.SetPresence("Viewing: " + this.Asset.NameWithExt);
    }

    private void OnEngineChanged(EngineVersion version) => this.Engine = version;

    private void OnDeserializerSuccess(MetaSchemaWindow window)
    {
      this.assetEditor.Asset = window.Asset;
      this.Items.Add(this.assetEditor.CreateRootNode());
      ((DispatcherObject) this).Dispatcher.BeginInvoke((Delegate) (() =>
      {
        this.dataTreeView.ItemsSource = (IEnumerable) this.Items;
        this.assetEditor.Initialize((object) this);
        this.dataTreeView.ContextMenu = this.dataTreeView.Resources[(object) "SolutionContext"] as ContextMenu;
        this.dataTreeView.ContextMenu.ItemsSource = (IEnumerable) this.assetEditor.RegisterContextMenuItems();
        Config.AddRecentFile(this.assetEditor.Asset.Name);
      }), Array.Empty<object>());
    }

    private void OnDeserializerFailed()
    {
      this.Tab.Terminate();
      int num = (int) MetaMessageBox.Show("There was an error attempting to deserialize " + this.Asset.DisplayName + ". Validate schema.", "Meta Schema Manager");
    }

    private void TreeViewItem_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
    {
      TreeViewItem treeViewItem = FlatbufferControl.VisualUpwardSearch<TreeViewItem>(e.OriginalSource as DependencyObject);
      if (treeViewItem == null)
        return;
      treeViewItem.IsSelected = true;
      e.Handled = true;
    }

    private static T VisualUpwardSearch<T>(DependencyObject source) where T : DependencyObject
    {
      DependencyObject dependencyObject1;
      DependencyObject dependencyObject2;
      for (dependencyObject1 = source; dependencyObject1 != null && !(dependencyObject1 is T); dependencyObject1 = dependencyObject2 ?? LogicalTreeHelper.GetParent(dependencyObject1))
      {
        dependencyObject2 = (DependencyObject) null;
        if (dependencyObject1 is Visual || dependencyObject1 is Visual3D)
          dependencyObject2 = VisualTreeHelper.GetParent(dependencyObject1);
      }
      return dependencyObject1 as T;
    }
  }
}
