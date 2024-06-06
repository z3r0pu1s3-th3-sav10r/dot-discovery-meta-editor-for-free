using System.Windows;
using System.Windows.Controls;

#nullable disable
namespace Meta.Editor.Controls
{
  public class MetaSpinner : Control
  {
    static MetaSpinner()
    {
      FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (MetaSpinner), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (MetaSpinner)));
    }
  }
}
