using Meta.Core;
using Meta.Editor.Controls.CreationSuite;
using MetaEditor;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

#nullable enable
namespace Meta.Editor.Controls
{
  public class CreationWindow : MetaWindow, IComponentConnector
  {
    public static readonly DependencyProperty ObjectProperty = DependencyProperty.Register(nameof (Object), typeof (object), typeof (CreationWindow), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, new PropertyChangedCallback(CreationWindow.OnObjectChanged)));
    internal 
    #nullable disable
    Grid mainGrid;
    internal Menu menu;
    internal MenuItem NewCreationProfile;
    internal MenuItem CreateCharacterProfile;
    internal MenuItem CreateBeltProfile;
    internal MenuItem OpenModMenuItem;
    internal MenuItem SaveAsModMenuItem;
    internal MenuItem ExitMenuItem;
    internal MetaTabControl tabControl;
    internal MetaDetachedTabControl tabContent;
    internal MetaTabControl miscTabControl;
    internal TextBox log;
    private bool _contentLoaded;

    public 
    #nullable enable
    object Object
    {
      get => this.GetValue(CreationWindow.ObjectProperty);
      set => this.SetValue(CreationWindow.ObjectProperty, value);
    }

    private static void OnObjectChanged(
      DependencyObject sender,
      DependencyPropertyChangedEventArgs args)
    {
      CreationWindow creationWindow = sender as CreationWindow;
      if (args.NewValue == null)
        return;
      creationWindow.ProcessClassEditors(args.NewValue);
    }

    public CreationWindow()
    {
      this.InitializeComponent();
      this.tabContent.HeaderControl = (Control) this.tabControl;
      RoutedCommand routedCommand1 = new RoutedCommand();
      RoutedCommand routedCommand2 = new RoutedCommand();
      routedCommand1.InputGestures.Add((InputGesture) new KeyGesture((Key) 58, (ModifierKeys) 2));
      routedCommand2.InputGestures.Add((InputGesture) new KeyGesture((Key) 62, (ModifierKeys) 2));
      this.CommandBindings.Add(new CommandBinding((ICommand) routedCommand1, new ExecutedRoutedEventHandler(this.OpenCreationProfile_Click)));
      this.CommandBindings.Add(new CommandBinding((ICommand) routedCommand2, new ExecutedRoutedEventHandler(this.SaveAsModMenuItem_Click)));
    }

    private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if ((this.tabControl.SelectedItem is MetaTabItem selectedItem ? selectedItem.Content : (object) null) is CreationEditor)
        ;
    }

    private void LogTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
      if (this.log == null)
        return;
      if (this.log.IsFocused)
        this.log.MoveFocus(new TraversalRequest((FocusNavigationDirection) 1));
      this.log.ScrollToEnd();
    }

    private void MetaWindow_Loaded(object sender, RoutedEventArgs e)
    {
      (App.Logger as MetaLogger).AddBinding((UIElement) this.log, TextBox.TextProperty);
    }

    private void ProcessClassEditors(object value)
    {
      this.RemoveAllTabs();
      CreationControl creationControl = (CreationControl) value;
      if (creationControl != null)
      {
        foreach (CreationEditor editor in (Collection<CreationEditor>) creationControl.Editors)
        {
          MetaTabItem newItem = new MetaTabItem();
          newItem.Content = (object) editor;
          newItem.Header = (object) editor.Title;
          newItem.Icon = editor.Icon;
          newItem.TabId = editor.Name;
          newItem.IsSelected = true;
          newItem.CloseButtonVisible = false;
          this.tabControl.Items.Add((object) newItem);
          App.Logger.Log("[Editor][{0}] Loaded", new object[1]
          {
            (object) editor.Title
          });
        }
        this.tabControl.SelectedIndex = 0;
      }
      App.Logger.Log("[Editor] Finished", Array.Empty<object>());
    }

    private void RemoveAllTabs()
    {
      while (this.tabControl.Items.Count > 0)
        this.RemoveTab(this.tabControl.Items[0] as MetaTabItem);
      GC.Collect();
    }

    private void RemoveTab(MetaTabItem ti)
    {
      if (ti.Content is CreationControl content)
        content.Closed();
      this.tabControl.Items.Remove((object) ti);
    }

    private void CreateCharacterProfile_Click(object sender, RoutedEventArgs e)
    {
      this.RemoveAllTabs();
      switch (Config.Get<string>("Game", (string) null))
      {
        case "WWE 2K23":
          this.Object = (object) new CharacterCreationControl(App.Logger, this.tabControl);
          break;
        case "WWE 2K24":
          this.Object = (object) new CharacterCreationControl_WWE2K24(App.Logger, this.tabControl);
          break;
        default:
          int num = (int) MetaMessageBox.Show("Game not supported", "Meta Memory Manager");
          break;
      }
    }

    private void CreateBeltProfile_Click(object sender, RoutedEventArgs e)
    {
      this.RemoveAllTabs();
      switch (Config.Get<string>("Game", (string) null))
      {
        case "WWE 2K23":
          this.Object = (object) new BeltCreationControl(App.Logger, this.tabControl);
          break;
        case "WWE 2K24":
          this.Object = (object) new BeltCreationControl_WWE2K24(App.Logger, this.tabControl);
          break;
        default:
          int num = (int) MetaMessageBox.Show("Game not supported", "Meta Memory Manager");
          break;
      }
    }

    private void SaveAsModMenuItem_Click(object sender, RoutedEventArgs e)
    {
      if (this.Object == null || !this.Object.GetType().IsSubclassOf(typeof (CreationControl)))
        return;
      ((CreationControl) this.Object).SaveAs();
    }

    private void OpenCreationProfile_Click(object sender, RoutedEventArgs e)
    {
      OpenFileDialog openFileDialog1 = new OpenFileDialog();
      openFileDialog1.Filter = "(All supported formats)|*.json";
      openFileDialog1.Title = "Open Profile";
      openFileDialog1.Multiselect = false;
      OpenFileDialog openFileDialog2 = openFileDialog1;
      bool? nullable = openFileDialog2.ShowDialog();
      bool flag = true;
      if (!(nullable.GetValueOrDefault() == flag & nullable.HasValue))
        return;
      Profile profile = JsonConvert.DeserializeObject<Profile>(File.ReadAllText(openFileDialog2.FileName));
      if (profile != null)
      {
        this.Object = (object) this.CreationControlFromGame(App.Game, profile.Type);
        if (this.Object != null && this.Object.GetType().IsSubclassOf(typeof (CreationControl)))
          ((CreationControl) this.Object).OpenAs(profile);
      }
    }

    private CreationControl CreationControlFromGame(string id, ProfileType profile)
    {
      return (CreationControl) Activator.CreateInstance(((IEnumerable<Type>) Assembly.GetExecutingAssembly().GetTypes()).FirstOrDefault<Type>((Func<Type, bool>) (t => t.GetCustomAttributes(typeof (CreationControlAttribute), false).Cast<CreationControlAttribute>().Any<CreationControlAttribute>((Func<CreationControlAttribute, bool>) (a => a.id.Equals(id) && a.profile.Equals((object) profile))))), (object) App.Logger, (object) this.tabControl);
    }

    private void ExitMenuItem_Click(object sender, RoutedEventArgs e) => this.Close();

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "7.0.11.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/Meta.Editor;V1.0.5.32;component/controls/creationsuite/creationwindow.xaml", UriKind.Relative));
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
          this.mainGrid = (Grid) target;
          break;
        case 2:
          this.menu = (Menu) target;
          break;
        case 3:
          this.NewCreationProfile = (MenuItem) target;
          break;
        case 4:
          this.CreateCharacterProfile = (MenuItem) target;
          this.CreateCharacterProfile.Click += new RoutedEventHandler(this.CreateCharacterProfile_Click);
          break;
        case 5:
          this.CreateBeltProfile = (MenuItem) target;
          this.CreateBeltProfile.Click += new RoutedEventHandler(this.CreateBeltProfile_Click);
          break;
        case 6:
          this.OpenModMenuItem = (MenuItem) target;
          this.OpenModMenuItem.Click += new RoutedEventHandler(this.OpenCreationProfile_Click);
          break;
        case 7:
          this.SaveAsModMenuItem = (MenuItem) target;
          this.SaveAsModMenuItem.Click += new RoutedEventHandler(this.SaveAsModMenuItem_Click);
          break;
        case 8:
          this.ExitMenuItem = (MenuItem) target;
          this.ExitMenuItem.Click += new RoutedEventHandler(this.ExitMenuItem_Click);
          break;
        case 9:
          this.tabControl = (MetaTabControl) target;
          break;
        case 10:
          this.tabContent = (MetaDetachedTabControl) target;
          break;
        case 11:
          this.miscTabControl = (MetaTabControl) target;
          break;
        case 12:
          this.log = (TextBox) target;
          this.log.TextChanged += new TextChangedEventHandler(this.LogTextBox_TextChanged);
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
