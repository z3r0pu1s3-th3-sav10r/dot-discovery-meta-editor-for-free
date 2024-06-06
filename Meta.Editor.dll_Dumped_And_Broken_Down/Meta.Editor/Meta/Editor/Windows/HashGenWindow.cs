using Meta.Editor.Controls;
using MetaEditor;
using Microsoft.Win32;
using Ookii.Dialogs.Wpf;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

#nullable enable
namespace Meta.Editor.Windows
{
  public class HashGenWindow : MetaWindow, IComponentConnector
  {
    internal 
    #nullable disable
    TextBox PathInput;
    internal Button OpenFileBtn;
    internal Button OpenFolderBtn;
    internal TextBlock FormattedPath;
    internal TextBox modTitleTextBox;
    private bool _contentLoaded;

    public HashGenWindow()
    {
      this.InitializeComponent();
      this.OpenFileBtn.Click += new RoutedEventHandler(this.OpenFileBtn_Click);
      this.OpenFolderBtn.Click += new RoutedEventHandler(this.OpenFolderBtn_Click);
    }

    private void OpenFolderBtn_Click(
    #nullable enable
    object sender, RoutedEventArgs e)
    {
      VistaFolderBrowserDialog folderBrowserDialog = new VistaFolderBrowserDialog();
      folderBrowserDialog.Description = "Please select a folder.";
      folderBrowserDialog.UseDescriptionForTitle = true;
      bool? nullable = folderBrowserDialog.ShowDialog();
      if (!(1 == (nullable.GetValueOrDefault() ? 1 : 0) & nullable.HasValue))
        return;
      this.PathInput.Text = folderBrowserDialog.SelectedPath;
    }

    private void OpenFileBtn_Click(object sender, RoutedEventArgs e)
    {
      OpenFileDialog openFileDialog1 = new OpenFileDialog();
      openFileDialog1.Title = "Open File";
      OpenFileDialog openFileDialog2 = openFileDialog1;
      bool? nullable = openFileDialog2.ShowDialog();
      bool flag = true;
      if (!(nullable.GetValueOrDefault() == flag & nullable.HasValue))
        return;
      this.PathInput.Text = openFileDialog2.FileName;
    }

    private void PathInput_SelectionChanged(object sender, RoutedEventArgs e)
    {
      string formatted = "";
      this.modTitleTextBox.Text = this.PathInput.Text.Hash(App.CurrentGame.Folders, out formatted).ToString();
      this.FormattedPath.Text = string.Format("Formatted: {0} ", (object) formatted);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "7.0.11.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/Meta.Editor;V1.0.5.32;component/windows/hashgenwindow.xaml", UriKind.Relative));
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
          this.PathInput = (TextBox) target;
          this.PathInput.TextChanged += new TextChangedEventHandler(this.PathInput_SelectionChanged);
          break;
        case 2:
          this.OpenFileBtn = (Button) target;
          break;
        case 3:
          this.OpenFolderBtn = (Button) target;
          break;
        case 4:
          this.FormattedPath = (TextBlock) target;
          break;
        case 5:
          this.modTitleTextBox = (TextBox) target;
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
