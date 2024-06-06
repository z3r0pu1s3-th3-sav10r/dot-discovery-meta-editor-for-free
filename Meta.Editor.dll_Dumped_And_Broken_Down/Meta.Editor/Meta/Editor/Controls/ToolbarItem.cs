using Meta.Editor.Commands;

#nullable enable
namespace Meta.Editor.Controls
{
  public class ToolbarItem
  {
    public string Text { get; private set; }

    public string ToolTip { get; private set; }

    public string Icon { get; private set; }

    public RelayCommand Command { get; private set; }

    public ToolbarItem(
      string text,
      string tooltip,
      string icon,
      RelayCommand inCommand,
      bool isAddedByPlugin = false)
    {
      this.Text = text;
      this.ToolTip = tooltip;
      this.Icon = icon;
      this.Command = inCommand;
    }
  }
}
