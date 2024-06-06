using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

#nullable enable
namespace Meta.Editor.Controls
{
  public class MetaDetachedTabControl : ContentControl
  {
    public static readonly DependencyProperty HeaderControlProperty = DependencyProperty.Register(nameof (HeaderControl), typeof (Control), typeof (MetaDetachedTabControl), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));

    public Control HeaderControl
    {
      get => (Control) this.GetValue(MetaDetachedTabControl.HeaderControlProperty);
      set
      {
        this.SetValue(MetaDetachedTabControl.HeaderControlProperty, (object) value);
        Binding binding = new Binding("SelectedContent")
        {
          Source = (object) value,
          Mode = BindingMode.OneWay
        };
        BindingOperations.SetBinding((DependencyObject) this, ContentControl.ContentProperty, (BindingBase) binding);
      }
    }
  }
}
