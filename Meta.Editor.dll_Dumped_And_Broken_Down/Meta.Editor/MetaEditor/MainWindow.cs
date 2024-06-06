using MaterialDesignThemes.Wpf;
using Meta.Core;
using Meta.Core.Attributes;
using Meta.Editor;
using Meta.Editor.Controls;
using Meta.Editor.Windows;
using Meta.Structures.Flatbuffers;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Shell;
using System.Windows.Threading;

#nullable enable
namespace MetaEditor
{
  public class MainWindow : MetaWindow, IComponentConnector, IStyleConnector
  {
    public static string Version = "";
    private Queue<string> fileQueue = new Queue<string>();
    internal 
    #nullable disable
    MainWindow Main;
    internal Grid mainGrid;
    internal Menu menu;
    internal MenuItem OpenModMenuItem;
    internal MenuItem OpenMoviesMenuItem;
    internal MenuItem OpenSDB;
    internal MenuItem OpenCollectionMenuItem;
    internal MenuItem SaveCollectionMenuItem;
    internal MenuItem RecentItemList;
    internal MenuItem ExitMenuItem;
    internal MenuItem ToolsMenuItem;
    internal MenuItem CreationSuite;
    internal MenuItem HashGenerator;
    internal MenuItem Plugins;
    internal MenuItem CloseAllDocumentsMenuItem;
    internal ComboBox GameList;
    internal ComboBox PART_EngineVersion;
    internal ItemsControl AssetEditorToolbarItems;
    internal MetaTabControl tabControl;
    internal TextBlock changeLogTextBlock;
    internal ListView LoadedPluginsList;
    internal MetaDetachedTabControl tabContent;
    internal MetaTabControl miscTabControl;
    internal TextBox tb;
    private bool _contentLoaded;

    public MainWindow()
    {
      this.InitializeComponent();
      this.tabContent.HeaderControl = (Control) this.tabControl;
      this.Title = "dot.Meta Editor | " + App.Version;
      MenuItem menuItem = new MenuItem();
      menuItem.Header = (object) "Options";
      menuItem.Icon = (object) new Image()
      {
        Source = (new ImageSourceConverter().ConvertFromString("pack://application:,,,/Meta.Editor;component/Images/Compile.png") as ImageSource)
      };
      MenuItem newItem1 = menuItem;
      newItem1.Click += new RoutedEventHandler(this.optionsMenuItem_Click);
      this.ToolsMenuItem.Items.Add((object) newItem1);
      this.TaskbarItemInfo = new TaskbarItemInfo();
      RoutedCommand routedCommand1 = new RoutedCommand();
      RoutedCommand routedCommand2 = new RoutedCommand();
      RoutedCommand routedCommand3 = new RoutedCommand();
      routedCommand1.InputGestures.Add((InputGesture) new KeyGesture((Key) 58, (ModifierKeys) 2));
      routedCommand2.InputGestures.Add((InputGesture) new KeyGesture((Key) 62, (ModifierKeys) 2));
      routedCommand3.InputGestures.Add((InputGesture) new KeyGesture((Key) 47, (ModifierKeys) 2));
      this.CommandBindings.Add(new CommandBinding((ICommand) routedCommand1, new ExecutedRoutedEventHandler(this.OpenCollectionMenuItem_Click)));
      this.CommandBindings.Add(new CommandBinding((ICommand) routedCommand2, new ExecutedRoutedEventHandler(this.SaveCollectionMenuItem_Click)));
      this.CommandBindings.Add(new CommandBinding((ICommand) routedCommand3, new ExecutedRoutedEventHandler(this.CloseAllDocumentsMenuItem_Click)));
      foreach (object newItem2 in Enum.GetValues(typeof (EngineVersion)))
        this.PART_EngineVersion.Items.Add(newItem2);
      this.PART_EngineVersion.SelectedItem = (object) (EngineVersion) 0;
      foreach (object key in App.FileData.Keys)
        this.GameList.Items.Add(key);
      this.GameList.SelectedItem = (object) Config.Get<string>("Game", "WWE 2K24");
      App.Game = (string) this.GameList.SelectedItem;
    }

    private void LogTextBox_TextChanged(
    #nullable enable
    object sender, TextChangedEventArgs e)
    {
      if (this.tb.IsFocused)
        this.tb.MoveFocus(new TraversalRequest((FocusNavigationDirection) 1));
      this.tb.ScrollToEnd();
    }

    public void OpenStringDatabase(string filePath)
    {
      MetaTabItem ti = new MetaTabItem();
      MetaSDBControl editor = new MetaSDBControl(App.Logger);
      editor.LoadAsset(filePath);
      RoutedCommand routedCommand = new RoutedCommand();
      routedCommand.InputGestures.Add((InputGesture) new KeyGesture((Key) 66, (ModifierKeys) 2));
      ti.Content = (object) editor;
      ti.Header = (object) Path.GetFileName(filePath);
      ti.Icon = editor.Icon;
      ti.IsSelected = true;
      ti.CloseButtonVisible = true;
      ti.CloseButtonClick += (RoutedEventHandler) ((s, o) => this.ShutdownEditorAndRemoveTab((MetaBaseControl) editor, ti));
      ti.MiddleMouseButtonClick += (MouseEventHandler) ((s, o) => this.ShutdownEditorAndRemoveTab((MetaBaseControl) editor, ti));
      editor.CommandBindings.Add(new CommandBinding((ICommand) routedCommand, (ExecutedRoutedEventHandler) ((o, e) => this.RemoveTab(ti))));
      this.AddTab(ti);
    }

    private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (!((this.tabControl.SelectedItem is MetaTabItem selectedItem ? selectedItem.Content : (object) null) is MetaBaseControl content))
        return;
      this.AssetEditorToolbarItems.ItemsSource = (IEnumerable) content.RegisterToolbarItems();
      this.PART_EngineVersion.SetBinding(Selector.SelectedItemProperty, (BindingBase) new Binding("Engine")
      {
        Source = (object) content
      });
    }

    private void OpenFlatbufferItem_Click(object sender, RoutedEventArgs e)
    {
      OpenFileDialog openFileDialog1 = new OpenFileDialog();
      openFileDialog1.Filter = "(All supported formats)|*.jsfb";
      openFileDialog1.Title = "Open Flatbuffer (JSFB)";
      openFileDialog1.Multiselect = true;
      OpenFileDialog openFileDialog2 = openFileDialog1;
      bool? nullable = openFileDialog2.ShowDialog();
      bool flag = true;
      if (!(nullable.GetValueOrDefault() == flag & nullable.HasValue))
        return;
      foreach (string fileName in openFileDialog2.FileNames)
        this.fileQueue.Enqueue(fileName);
      this.ProcessNextFile();
    }

    private async void ProcessNextFile()
    {
      if (this.fileQueue.Count <= 0)
        return;
      string file = this.fileQueue.Dequeue();
      if (File.Exists(file))
      {
        bool flag = await this.InitializeSchema(file);
        int num = flag ? 1 : 0;
        this.ProcessNextFile();
      }
      file = (string) null;
    }

    private async Task<bool> InitializeSchema(string file)
    {
      bool flag = await Task.Run<bool>((Func<bool>) (() =>
      {
        IEnumerable<FlatbufferSchema> flatbufferSchemas;
        if (App.SchemaManager.Exist(SchemaManager.GetTag(file), ref flatbufferSchemas, Enum.Parse<SchemaVersion>(App.Game.Replace(' ', '_'))))
        {
          CacheFile cached_file = Config.Get<CacheFile>(file, (CacheFile) null);
          if (cached_file != null)
          {
            if (cached_file.Schema != null)
            {
              FlatbufferSchema schema1 = flatbufferSchemas.Where<FlatbufferSchema>((Func<FlatbufferSchema, bool>) (schema => schema.name.Equals(cached_file.Schema.Schema_Name) && schema.identifier.Equals(cached_file.Schema.Schema_Tag))).FirstOrDefault<FlatbufferSchema>();
              if (schema1 != null)
              {
                Application.Current.Dispatcher.Invoke((Action) (() => this.LoadFlatbuffer(schema1, file)));
                return true;
              }
              App.Logger.LogError("There was a problem trying to find the specified cache scheme", Array.Empty<object>());
              return false;
            }
            if (File.Exists(cached_file.JSON_Path))
            {
              if (MetaMessageBox.Show("Cached file exists with missing schema data. Would you like to update?", "Meta File Manager", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
              {
                FlatbufferSchema schema = flatbufferSchemas.Count<FlatbufferSchema>() > 1 ? this.GetSchema(flatbufferSchemas, file) : flatbufferSchemas.FirstOrDefault<FlatbufferSchema>();
                if (schema != null)
                {
                  Application.Current.Dispatcher.Invoke((Action) (() => this.LoadFlatbuffer(schema, file)));
                  Config.UpdateFile(cached_file, cached_file.JSFB_Path, cached_file.JSON_Path, cached_file.LastModified, cached_file.Game, new CacheFile.SchemaConfig()
                  {
                    Schema_Name = schema.name,
                    Schema_Tag = schema.identifier
                  }, (EngineVersion) 0);
                  return true;
                }
              }
            }
            else
            {
              FlatbufferSchema schema = flatbufferSchemas.Count<FlatbufferSchema>() > 1 ? this.GetSchema(flatbufferSchemas, file) : flatbufferSchemas.FirstOrDefault<FlatbufferSchema>();
              if (schema != null)
              {
                Application.Current.Dispatcher.Invoke((Action) (() => this.LoadFlatbuffer(schema, file)));
                return true;
              }
            }
          }
          else
          {
            FlatbufferSchema schema = flatbufferSchemas.Count<FlatbufferSchema>() > 1 ? this.GetSchema(flatbufferSchemas, file) : flatbufferSchemas.FirstOrDefault<FlatbufferSchema>();
            if (schema != null)
            {
              Application.Current.Dispatcher.Invoke((Action) (() => this.LoadFlatbuffer(schema, file)));
              return true;
            }
          }
        }
        else if (MetaMessageBox.Show("Schema not supported.", "Meta File Manager", MessageBoxButton.OK) == MessageBoxResult.OK)
          return false;
        return false;
      }));
      return flag;
    }

    private bool LoadFlatbuffer(FlatbufferSchema schema, string file)
    {
      FlatbufferControl flatbuffer = new FlatbufferControl(App.Logger, schema, file);
      if (flatbuffer == null || !flatbuffer.Initialize())
        return false;
      MetaTabItem ti = new MetaTabItem();
      RoutedCommand routedCommand = new RoutedCommand();
      routedCommand.InputGestures.Add((InputGesture) new KeyGesture((Key) 66, (ModifierKeys) 2));
      ti.Content = (object) flatbuffer;
      ti.Header = (object) flatbuffer.Asset.NameWithExt;
      ti.Icon = schema.icon;
      ti.TabId = flatbuffer.Asset.NameWithExt;
      ti.IsSelected = true;
      ti.CloseButtonVisible = true;
      ti.CloseButtonClick += (RoutedEventHandler) ((s, o) => this.ShutdownEditorAndRemoveTab((MetaBaseControl) flatbuffer, ti));
      ti.MiddleMouseButtonClick += (MouseEventHandler) ((s, o) => this.ShutdownEditorAndRemoveTab((MetaBaseControl) flatbuffer, ti));
      flatbuffer.CommandBindings.Add(new CommandBinding((ICommand) routedCommand, (ExecutedRoutedEventHandler) ((o, e) => this.RemoveTab(ti))));
      this.AddTab(ti);
      flatbuffer.Tab = ti;
      return true;
    }

    private FlatbufferSchema GetSchema(IEnumerable<FlatbufferSchema> schemas, string file)
    {
      FlatbufferSchema selectedSchema = new FlatbufferSchema();
      Application.Current.Dispatcher.Invoke((Action) (() => SchemaWindow.Show((Window) this, file, schemas, (MetaSchemaTaskCallback) (task => { }), (MetaSchemaCancelCallback) (task => selectedSchema = (FlatbufferSchema) null), (MetaSchemaOkCallback) (task => selectedSchema = task.SelectedSchema))));
      return selectedSchema;
    }

    private void OpenCreation_Click(object sender, RoutedEventArgs e)
    {
      CreationWindow creationWindow = new CreationWindow();
      creationWindow.Owner = Application.Current.MainWindow;
      creationWindow.Show();
    }

    private void OpenSDBItem_Click(object sender, RoutedEventArgs e)
    {
      OpenFileDialog openFileDialog1 = new OpenFileDialog();
      openFileDialog1.Filter = "(All supported formats)|*.sdb";
      openFileDialog1.Title = "Open SDB (String Database)";
      openFileDialog1.Multiselect = false;
      OpenFileDialog openFileDialog2 = openFileDialog1;
      bool? nullable = openFileDialog2.ShowDialog();
      bool flag = true;
      if (!(nullable.GetValueOrDefault() == flag & nullable.HasValue))
        return;
      this.OpenStringDatabase(openFileDialog2.FileName);
    }

    private static bool ValidateFlatbufferWithName(string fileName, out string? type)
    {
      string ident = Path.GetFileNameWithoutExtension(fileName);
      var data = ((IEnumerable<Type>) Assembly.Load("Meta.Structures.Flatbuffers").GetTypes()).Where<Type>((Func<Type, bool>) (t => t.GetCustomAttributes(typeof (BufferIdentifierAttribute), true).Length != 0)).Where<Type>((Func<Type, bool>) (t => t.GetCustomAttributes(typeof (GameVersionAttribute), true).Cast<GameVersionAttribute>().Any<GameVersionAttribute>((Func<GameVersionAttribute, bool>) (attr => attr.Value.Equals(App.Game))))).Select(t => new
      {
        Type = t,
        Attributes = t.GetCustomAttributes(typeof (BufferIdentifierAttribute), true).Cast<BufferIdentifierAttribute>().FirstOrDefault<BufferIdentifierAttribute>()
      }).FirstOrDefault(x => x.Attributes.Value.Equals(ident));
      if (data != null)
      {
        type = data.Attributes.Value;
        return true;
      }
      type = (string) null;
      return false;
    }

    private static bool ValidateSchema(string fileName, out object types)
    {
      string ident = "";
      if (File.Exists(fileName))
      {
        using (BinaryReader binaryReader = new BinaryReader((Stream) new FileStream(fileName, FileMode.Open, FileAccess.Read)))
        {
          binaryReader.BaseStream.Position = 4L;
          ident = new string(binaryReader.ReadChars(4));
          binaryReader.Dispose();
        }
        List<Type> list = ((IEnumerable<Type>) Assembly.Load("Meta.Editor").GetTypes()).Where<Type>((Func<Type, bool>) (type => type.GetCustomAttributes<EditorTypeAttribute>().Any<EditorTypeAttribute>((Func<EditorTypeAttribute, bool>) (attr => attr.Value == ident)) && type.GetCustomAttributes<GameVersionAttribute>().Any<GameVersionAttribute>((Func<GameVersionAttribute, bool>) (attr => attr.Value == App.Game)))).ToList<Type>();
        if (list.Count<Type>() > 0)
        {
          types = (object) list;
          return true;
        }
        types = (object) null;
        return false;
      }
      int num = (int) MetaMessageBox.Show(fileName + " was not found.", "Meta File Manager");
      types = (object) null;
      return false;
    }

    private void MetaTabItem_MouseMove(object sender, MouseEventArgs e)
    {
      if (!(e.Source is MetaTabItem source) || Mouse.PrimaryDevice.LeftButton != MouseButtonState.Pressed)
        return;
      int num = (int) DragDrop.DoDragDrop((DependencyObject) source, (object) source, DragDropEffects.All);
    }

    private void MetaTabItem_DragOver(object sender, DragEventArgs e)
    {
      MetaTabControl parent;
      int num;
      if (e.Source is MetaTabItem source && e.Data.GetData(typeof (MetaTabItem)) is MetaTabItem data && !((object) source).Equals((object) data))
      {
        parent = source.Parent as MetaTabControl;
        num = parent != null ? 1 : 0;
      }
      else
        num = 0;
      if (num == 0)
        return;
      int insertIndex = parent.Items.IndexOf((object) source);
      parent.Items.Remove((object) data);
      parent.Items.Insert(insertIndex, (object) data);
      data.IsSelected = true;
    }

    private void optionsMenuItem_Click(object sender, RoutedEventArgs e)
    {
      this.Effect = (Effect) new BlurEffect()
      {
        Radius = 2.0
      };
      new OptionsWindow().ShowDialog();
    }

    private void AddTab(MetaTabItem ti)
    {
      this.tabControl.Items.Add((object) ti);
      (this.tabControl.Items[0] as MetaTabItem).Visibility = Visibility.Collapsed;
    }

    public void RemoveTab(MetaTabItem ti)
    {
      if (ti.Content is MetaBaseControl content)
        content.Closed();
      this.tabControl.Items.Remove((object) ti);
      if (this.tabControl.Items.Count != 1)
        return;
      MetaTabItem metaTabItem = this.tabControl.Items[0] as MetaTabItem;
      metaTabItem.Visibility = Visibility.Visible;
      metaTabItem.IsSelected = true;
      App.DiscordManager.SetPresence("Viewing: Home Page");
    }

    private void RemoveAllTabs()
    {
      while (this.tabControl.Items.Count > 1)
      {
        MetaTabItem ti = this.tabControl.Items[1] as MetaTabItem;
        if (ti.Content is MetaBaseControl content)
          this.ShutdownEditorAndRemoveTab(content, ti);
        else
          this.RemoveTab(ti);
      }
    }

    private void ShutdownEditorAndRemoveTab(MetaBaseControl editor, MetaTabItem ti)
    {
      editor.Closed();
      ((DispatcherObject) this).Dispatcher.Invoke((Action) (() =>
      {
        if (ti.IsSelected)
          this.AssetEditorToolbarItems.ItemsSource = (IEnumerable) null;
        this.tabControl.Items.Remove((object) ti);
        if (this.tabControl.Items.Count != 1)
          return;
        MetaTabItem metaTabItem = this.tabControl.Items[0] as MetaTabItem;
        metaTabItem.Visibility = Visibility.Visible;
        metaTabItem.IsSelected = true;
      }));
    }

    private void Main_MetaLoaded(object sender, EventArgs e)
    {
      (App.Logger as MetaLogger).AddBinding((UIElement) this.tb, TextBox.TextProperty);
      App.InitiateWatchGame();
      this.LoadMenuExtensions();
      this.RecentItemList.ItemsSource = (IEnumerable) Config.RecentFileList;
      this.LoadedPluginsList.ItemsSource = (IEnumerable) App.PluginManager.Plugins;
    }

    private void MenuRecentItem_Click(object sender, RoutedEventArgs e)
    {
      if (!(sender is MenuItem menuItem))
        return;
      this.fileQueue.Enqueue((string) menuItem.Tag);
      this.ProcessNextFile();
    }

    private void SaveCollectionMenuItem_Click(object sender, RoutedEventArgs e)
    {
      if (this.tabControl.Items.Count > 1)
      {
        MetaSaveFileDialog metaSaveFileDialog = new MetaSaveFileDialog("Save collection", "*.mcl (Meta Collection File)|*.mcl", "", config: false);
        if (!metaSaveFileDialog.ShowDialog())
          return;
        ObservableCollection<string> observableCollection = new ObservableCollection<string>();
        foreach (object obj in (IEnumerable) this.tabControl.Items)
        {
          if (((ContentControl) obj).Content.GetType() == typeof (FlatbufferControl))
          {
            Meta.Editor.Controls.Editor assetEditor = ((FlatbufferControl) ((ContentControl) obj).Content).assetEditor;
            if (assetEditor != null)
              observableCollection.Add(assetEditor.Asset.Name);
          }
        }
        File.WriteAllText(Path.GetDirectoryName(metaSaveFileDialog.FileName) + "\\" + Path.GetFileNameWithoutExtension(metaSaveFileDialog.FileName) + ".mcl", JsonConvert.SerializeObject((object) observableCollection, Formatting.Indented));
      }
      else
      {
        int num = (int) MetaMessageBox.Show("Error: No files are open");
      }
    }

    private void OpenCollectionMenuItem_Click(object sender, RoutedEventArgs e)
    {
      OpenFileDialog openFileDialog1 = new OpenFileDialog();
      openFileDialog1.Filter = "(All supported formats)|*.mcl";
      openFileDialog1.Title = "Open MCL (Meta Collection File)";
      openFileDialog1.Multiselect = false;
      OpenFileDialog openFileDialog2 = openFileDialog1;
      bool? nullable = openFileDialog2.ShowDialog();
      bool flag = true;
      if (!(nullable.GetValueOrDefault() == flag & nullable.HasValue))
        return;
      List<string> stringList = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(openFileDialog2.FileName));
      if (stringList.Count > 0)
      {
        foreach (string str in stringList)
        {
          this.fileQueue.Enqueue(str);
          this.ProcessNextFile();
        }
      }
      else
      {
        int num = (int) MetaMessageBox.Show("Error: No files to open");
      }
    }

    private void GameList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      this.RemoveAllTabs();
      App.Game = (string) this.GameList.SelectedItem;
      App.CurrentGame = JsonConvert.DeserializeObject<MetaGame>(JsonConvert.SerializeObject(App.FileData[App.Game]["Game"]));
      Config.Add("Game", this.GameList.SelectedItem);
      Config.Save();
    }

    private void EngineVersion_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (!((this.tabControl.SelectedItem is MetaTabItem selectedItem ? selectedItem.Content : (object) null) is MetaBaseControl content))
        return;
      content.OnEngineSet((EngineVersion) this.PART_EngineVersion.SelectedItem);
    }

    private void CloseAllDocumentsMenuItem_Click(object sender, RoutedEventArgs e)
    {
      this.RemoveAllTabs();
    }

    private void HashGenerator_Click(object sender, RoutedEventArgs e)
    {
      HashGenWindow hashGenWindow = new HashGenWindow();
      hashGenWindow.Owner = Application.Current.MainWindow;
      hashGenWindow.Show();
    }

    private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
    {
      Application.Current.Shutdown();
    }

    private void LoadMenuExtensions()
    {
      foreach (MenuExtension menuExtension in App.PluginManager.MenuExtensions)
      {
        PackIconKind result;
        if (Enum.TryParse<PackIconKind>(menuExtension.Icon, out result))
        {
          PackIcon packIcon1 = new PackIcon();
          packIcon1.Kind = result;
          ((FrameworkElement) packIcon1).Width = 16.0;
          ((FrameworkElement) packIcon1).Height = 16.0;
          PackIcon packIcon2 = packIcon1;
          MenuItem newItem = new MenuItem();
          newItem.Header = (object) menuExtension.MenuItemName;
          newItem.Icon = (object) packIcon2;
          newItem.Command = (ICommand) menuExtension.MenuItemClicked;
          this.Plugins.Items.Add((object) newItem);
        }
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "7.0.11.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/Meta.Editor;V1.0.5.32;component/windows/mainwindow.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "7.0.11.0")]
    internal 
    #nullable disable
    Delegate _CreateDelegate(Type delegateType, string handler)
    {
      return Delegate.CreateDelegate(delegateType, (object) this, handler);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "7.0.11.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          this.Main = (MainWindow) target;
          break;
        case 2:
          this.mainGrid = (Grid) target;
          break;
        case 3:
          this.menu = (Menu) target;
          break;
        case 4:
          this.OpenModMenuItem = (MenuItem) target;
          break;
        case 5:
          this.OpenMoviesMenuItem = (MenuItem) target;
          this.OpenMoviesMenuItem.Click += new RoutedEventHandler(this.OpenFlatbufferItem_Click);
          break;
        case 6:
          this.OpenSDB = (MenuItem) target;
          this.OpenSDB.Click += new RoutedEventHandler(this.OpenSDBItem_Click);
          break;
        case 7:
          this.OpenCollectionMenuItem = (MenuItem) target;
          this.OpenCollectionMenuItem.Click += new RoutedEventHandler(this.OpenCollectionMenuItem_Click);
          break;
        case 8:
          this.SaveCollectionMenuItem = (MenuItem) target;
          this.SaveCollectionMenuItem.Click += new RoutedEventHandler(this.SaveCollectionMenuItem_Click);
          break;
        case 9:
          this.RecentItemList = (MenuItem) target;
          break;
        case 11:
          this.ExitMenuItem = (MenuItem) target;
          this.ExitMenuItem.Click += new RoutedEventHandler(this.ExitMenuItem_Click);
          break;
        case 12:
          this.ToolsMenuItem = (MenuItem) target;
          break;
        case 13:
          this.CreationSuite = (MenuItem) target;
          this.CreationSuite.Click += new RoutedEventHandler(this.OpenCreation_Click);
          break;
        case 14:
          this.HashGenerator = (MenuItem) target;
          this.HashGenerator.Click += new RoutedEventHandler(this.HashGenerator_Click);
          break;
        case 15:
          this.Plugins = (MenuItem) target;
          break;
        case 16:
          this.CloseAllDocumentsMenuItem = (MenuItem) target;
          this.CloseAllDocumentsMenuItem.Click += new RoutedEventHandler(this.CloseAllDocumentsMenuItem_Click);
          break;
        case 17:
          ((ButtonBase) target).Click += new RoutedEventHandler(this.OpenFlatbufferItem_Click);
          break;
        case 18:
          ((ButtonBase) target).Click += new RoutedEventHandler(this.OpenSDBItem_Click);
          break;
        case 19:
          this.GameList = (ComboBox) target;
          this.GameList.SelectionChanged += new SelectionChangedEventHandler(this.GameList_SelectionChanged);
          break;
        case 20:
          this.PART_EngineVersion = (ComboBox) target;
          this.PART_EngineVersion.SelectionChanged += new SelectionChangedEventHandler(this.EngineVersion_SelectionChanged);
          break;
        case 21:
          this.AssetEditorToolbarItems = (ItemsControl) target;
          break;
        case 22:
          this.tabControl = (MetaTabControl) target;
          break;
        case 23:
          this.changeLogTextBlock = (TextBlock) target;
          break;
        case 24:
          this.LoadedPluginsList = (ListView) target;
          break;
        case 25:
          this.tabContent = (MetaDetachedTabControl) target;
          break;
        case 26:
          this.miscTabControl = (MetaTabControl) target;
          break;
        case 27:
          this.tb = (TextBox) target;
          this.tb.TextChanged += new TextChangedEventHandler(this.LogTextBox_TextChanged);
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "7.0.11.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IStyleConnector.Connect(int connectionId, object target)
    {
      if (connectionId != 10)
        return;
      ((MenuItem) target).Click += new RoutedEventHandler(this.MenuRecentItem_Click);
    }
  }
}
