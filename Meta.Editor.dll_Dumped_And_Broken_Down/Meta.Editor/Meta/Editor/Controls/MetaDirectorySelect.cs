using Ookii.Dialogs.Wpf;
using PropertyTools.Wpf;
using System;
using System.Windows.Input;

#nullable disable
namespace Meta.Editor.Controls
{
  public class MetaDirectorySelect : DirectoryPicker
  {
    public MetaDirectorySelect()
    {
      this.BrowseCommand = (ICommand) new DelegateCommand(new Action(this.Browse));
    }

    private void Browse()
    {
      VistaFolderBrowserDialog folderBrowserDialog = new VistaFolderBrowserDialog();
      folderBrowserDialog.Description = "Please select a folder.";
      folderBrowserDialog.UseDescriptionForTitle = true;
      bool? nullable = folderBrowserDialog.ShowDialog();
      if (!(1 == (nullable.GetValueOrDefault() ? 1 : 0) & nullable.HasValue))
        return;
      this.Directory = folderBrowserDialog.SelectedPath;
    }
  }
}
