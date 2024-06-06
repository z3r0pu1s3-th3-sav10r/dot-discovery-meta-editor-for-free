using MaterialDesignThemes.Wpf;
using Meta.Editor.Commands;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

#nullable enable
namespace Meta.Editor.Controls
{
  public class ContextMenuItem : MenuItem
  {
    public ContextMenuItem(
      string text,
      string tooltip,
      string icon,
      RelayCommand inCommand,
      bool isAddedByPlugin = false)
    {
      this.Header = (object) text;
      this.ToolTip = (object) tooltip;
      PackIconKind result;
      if (Enum.TryParse<PackIconKind>(icon, out result))
      {
        PackIcon packIcon = new PackIcon();
        packIcon.Kind = result;
        ((FrameworkElement) packIcon).Width = 16.0;
        ((FrameworkElement) packIcon).Height = 16.0;
        this.Icon = (object) packIcon;
      }
      this.Command = (ICommand) inCommand;
    }
  }
}
