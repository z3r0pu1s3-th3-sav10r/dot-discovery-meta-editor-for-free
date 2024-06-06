using System.Windows;

#nullable enable
namespace Meta.Editor.Controls
{
  public class MetaDockableWindow : MetaWindow
  {
    public DependencyObject WindowParent { get; set; }

    static MetaDockableWindow()
    {
      FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (MetaDockableWindow), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (MetaDockableWindow)));
    }
  }
}
