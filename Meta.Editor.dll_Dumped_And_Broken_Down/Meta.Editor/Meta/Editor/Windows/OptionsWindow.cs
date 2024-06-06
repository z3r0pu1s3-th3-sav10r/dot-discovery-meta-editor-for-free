using Meta.Core;
using Meta.Editor.Controls;
using Meta.Editor.Extensions;
using Microsoft.Win32;
using PropertyTools.DataAnnotations;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

#nullable enable
namespace Meta.Editor.Windows
{
  public class OptionsWindow : MetaWindow, IComponentConnector
  {
    [ExpandableObject]
    private OptionsWindow.EditorOptionsData MetaOptions;
    internal 
    #nullable disable
    PropertyTools.Wpf.PropertyGrid pgrid;
    internal Button cancelButton;
    internal Button saveButton;
    private bool _contentLoaded;

    public OptionsWindow() => this.InitializeComponent();

    private void Window_Loaded(
    #nullable enable
    object sender, RoutedEventArgs e)
    {
      this.MetaOptions = new OptionsWindow.EditorOptionsData();
      this.MetaOptions.Load();
      this.pgrid.SelectedObject = (object) this.MetaOptions;
    }

    private void cancelButton_Click(object sender, RoutedEventArgs e) => this.Close();

    private void saveButton_Click(object sender, RoutedEventArgs e)
    {
      if (this.Validate())
      {
        this.MetaOptions.Save();
        this.Close();
      }
      Config.Save();
    }

    private bool Validate() => this.MetaOptions.Validate();

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "7.0.11.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/Meta.Editor;V1.0.5.32;component/windows/optionswindow.xaml", UriKind.Relative));
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
          this.pgrid = (PropertyTools.Wpf.PropertyGrid) target;
          break;
        case 2:
          this.cancelButton = (Button) target;
          this.cancelButton.Click += new RoutedEventHandler(this.cancelButton_Click);
          break;
        case 3:
          this.saveButton = (Button) target;
          this.saveButton.Click += new RoutedEventHandler(this.saveButton_Click);
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }

    [DisplayName("Editor Options")]
    public class EditorOptionsData : OptionsExtension
    {
      [Category("Backups")]
      [DisplayName("Enabled")]
      [Description("Enables file backups.")]
      public bool BackupsEnabled { get; set; } = true;

      [Category("Backups")]
      [DisplayName("Max Count")]
      [Description("Maximum amount of backups to save per each file.")]
      public int BackupsMaxCount { get; set; } = 3;

      [Category("Editor")]
      [DisplayName("Set as Default Installation")]
      [Description("Use this installation for .JSFB files.")]
      public bool DefaultInstallation { get; set; } = false;

      [Category("Watcher")]
      [DisplayName("Enabled")]
      [Description("Meta will actively watch your exported JSON and re-compile.")]
      public bool WatchEnabled { get; set; } = true;

      [Category("Watcher")]
      [DisplayName("Windows Notifications")]
      [Description("Meta will actively watch your exported JSON and re-compile.")]
      public bool WindowsNotifications { get; set; } = true;

      [Category("Watcher")]
      [DisplayName("Load check")]
      [Description("Enabling this will make Meta check whether any changes have been outside of Meta for JSON files.")]
      public bool WatchLoadEnabled { get; set; } = true;

      [Category("Editor")]
      [DirectoryPath]
      [AutoUpdateText]
      [Browsable(false)]
      public 
      #nullable enable
      string PrefWorkDir { get; set; }

      public override void Load()
      {
        base.Load();
        this.BackupsEnabled = Config.Get<bool>("BackupsEnabled", true);
        this.BackupsMaxCount = Config.Get<int>("BackupsMaxCount", 3);
        this.WatchEnabled = Config.Get<bool>("WatchEnabled", true);
        this.PrefWorkDir = Config.Get<string>("PrefWorkDir", string.Empty);
        this.WindowsNotifications = Config.Get<bool>("WindowsNotifications", true);
        this.WatchLoadEnabled = Config.Get<bool>("WatchLoadEnabled", true);
        string str = "2kjsfb";
        string location = Assembly.GetEntryAssembly().Location;
        if (Registry.CurrentUser.OpenSubKey("Software\\Classes\\" + str) == null || !((string) Registry.CurrentUser.OpenSubKey("Software\\Classes\\" + str).OpenSubKey("shell").OpenSubKey("open").OpenSubKey("command").GetValue("")).Contains(location))
          return;
        this.DefaultInstallation = true;
      }

      public override void Save()
      {
        base.Save();
        Config.Add("BackupsEnabled", (object) this.BackupsEnabled);
        Config.Add("BackupsMaxCount", (object) this.BackupsMaxCount);
        Config.Add("WatchEnabled", (object) this.WatchEnabled);
        Config.Add("PrefWorkDir", (object) this.PrefWorkDir);
        Config.Add("WindowsNotifications", (object) this.WindowsNotifications);
        Config.Add("WatchLoadEnabled", (object) this.WatchLoadEnabled);
        Config.Save();
        if (!this.DefaultInstallation)
          return;
        string str1 = ".jsfb";
        string str2 = "2kjsfb";
        string location = Assembly.GetEntryAssembly().Location;
        string str3 = "Flatbuffer File";
        RegistryKey subKey1 = Registry.CurrentUser.CreateSubKey("Software\\Classes\\" + str1);
        subKey1.SetValue("", (object) str2);
        RegistryKey subKey2 = Registry.CurrentUser.CreateSubKey("Software\\Classes\\" + str2);
        subKey2.SetValue("", (object) str3);
        subKey2.CreateSubKey("DefaultIcon").SetValue("", (object) ("\"" + location + "\",0"));
        RegistryKey subKey3 = subKey2.CreateSubKey("shell");
        subKey3.CreateSubKey("edit").CreateSubKey("command").SetValue("", (object) ("\"" + location + "\" \"%1\""));
        subKey3.CreateSubKey("open").CreateSubKey("command").SetValue("", (object) ("\"" + location + "\" \"%1\""));
        subKey1.Close();
        subKey2.Close();
        subKey3.Close();
        RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\" + str1, true);
        registryKey.DeleteSubKey("UserChoice", false);
        registryKey.Close();
        OptionsWindow.EditorOptionsData.SHChangeNotify(134217728U, 0U, IntPtr.Zero, IntPtr.Zero);
      }

      public override bool Validate() => true;

      [DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
      private static extern void SHChangeNotify(
        uint wEventId,
        uint uFlags,
        IntPtr dwItem1,
        IntPtr dwItem2);
    }
  }
}
