using Meta.Core;
using Microsoft.Win32;

#nullable enable
namespace Meta.Editor.Controls
{
  public class MetaSaveFileDialog
  {
    private string key;
    private SaveFileDialog sfd;
    private bool config;

    public string FileName => this.sfd.FileName;

    public string InitialDirectory
    {
      get => this.sfd.InitialDirectory;
      set => this.sfd.InitialDirectory = value;
    }

    public int FilterIndex => this.sfd.FilterIndex;

    public MetaSaveFileDialog(
      string title,
      string filter,
      string inKey,
      string filename = "",
      bool overwritePrompt = true,
      bool config = true)
    {
      this.key = inKey + "_ExportPath";
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.Title = title;
      saveFileDialog.Filter = filter;
      saveFileDialog.FileName = filename;
      saveFileDialog.OverwritePrompt = overwritePrompt;
      this.sfd = saveFileDialog;
      this.config = config;
    }

    public bool ShowDialog()
    {
      bool? nullable = this.sfd.ShowDialog();
      bool flag = true;
      if (!(nullable.GetValueOrDefault() == flag & nullable.HasValue))
        return false;
      if (this.config)
      {
        Config.Add(this.key, (object) this.sfd.FileName);
        Config.Save();
      }
      return true;
    }
  }
}
