using System.Windows;
using System.Windows.Controls;

#nullable enable
namespace Meta.Editor.Controls
{
  [TemplatePart(Name = "PART_Watermark", Type = typeof (TextBlock))]
  public class MetaWatermarkTextbox : TextBox
  {
    private const string PART_Watermark = "PART_Watermark";
    public static readonly DependencyProperty WatermarkTextProperty = DependencyProperty.Register(nameof (WatermarkText), typeof (string), typeof (MetaWatermarkTextbox), (PropertyMetadata) new FrameworkPropertyMetadata((object) ""));
    private TextBlock watermarkTextBlock;

    public string WatermarkText
    {
      get => (string) this.GetValue(MetaWatermarkTextbox.WatermarkTextProperty);
      set => this.SetValue(MetaWatermarkTextbox.WatermarkTextProperty, (object) value);
    }

    static MetaWatermarkTextbox()
    {
      FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (MetaWatermarkTextbox), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (MetaWatermarkTextbox)));
    }

    public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      this.watermarkTextBlock = this.GetTemplateChild("PART_Watermark") as TextBlock;
      this.GotFocus += new RoutedEventHandler(this.MetaWatermarkTextBox_GotFocus);
      this.LostFocus += new RoutedEventHandler(this.MetaWatermarkTextBox_LostFocus);
    }

    private void MetaWatermarkTextBox_LostFocus(object sender, RoutedEventArgs e)
    {
      if (!(this.Text == ""))
        return;
      this.watermarkTextBlock.Visibility = Visibility.Visible;
    }

    private void MetaWatermarkTextBox_GotFocus(object sender, RoutedEventArgs e)
    {
      this.watermarkTextBlock.Visibility = Visibility.Collapsed;
    }
  }
}
