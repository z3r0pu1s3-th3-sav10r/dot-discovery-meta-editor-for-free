using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

#nullable enable
namespace Meta.Editor.Controls
{
  [TemplatePart(Name = "PART_CloseButton", Type = typeof (ButtonBase))]
  [TemplatePart(Name = "PART_DragLabel", Type = typeof (Label))]
  public class MetaTabItem : TabItem
  {
    private const string PART_CloseButton = "PART_CloseButton";
    private const string PART_DragLabel = "PART_DragLabel";
    public static readonly DependencyProperty IconProperty = DependencyProperty.Register(nameof (Icon), typeof (string), typeof (MetaTabItem), (PropertyMetadata) new FrameworkPropertyMetadata((object) "Home"));
    public static readonly DependencyProperty SvgIconProperty = DependencyProperty.Register(nameof (SvgIcon), typeof (Geometry), typeof (MetaTabItem), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    public static readonly DependencyProperty CloseButtonVisibleProperty = DependencyProperty.Register(nameof (CloseButtonVisible), typeof (bool), typeof (MetaTabItem), (PropertyMetadata) new FrameworkPropertyMetadata((object) false));
    public static readonly DependencyProperty ObjectProperty = DependencyProperty.Register(nameof (Object), typeof (object), typeof (MetaTabItem), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    private ButtonBase closeButton;
    private Label dragLabel;

    public string Icon
    {
      get => (string) this.GetValue(MetaTabItem.IconProperty);
      set => this.SetValue(MetaTabItem.IconProperty, (object) value);
    }

    public Geometry SvgIcon
    {
      get => (Geometry) this.GetValue(MetaTabItem.SvgIconProperty);
      set => this.SetValue(MetaTabItem.SvgIconProperty, (object) value);
    }

    public bool CloseButtonVisible
    {
      get => (bool) this.GetValue(MetaTabItem.CloseButtonVisibleProperty);
      set => this.SetValue(MetaTabItem.CloseButtonVisibleProperty, (object) value);
    }

    public object Object
    {
      get => this.GetValue(MetaTabItem.ObjectProperty);
      set => this.SetValue(MetaTabItem.ObjectProperty, value);
    }

    public object SelectedClass => this.Object;

    public string TabId { get; set; }

    private event RoutedEventHandler closeButtonClick;

    public event RoutedEventHandler CloseButtonClick
    {
      add => this.closeButtonClick += value;
      remove => this.closeButtonClick -= value;
    }

    private event MouseEventHandler middleMouseButtonClick;

    public event MouseEventHandler MiddleMouseButtonClick
    {
      add => this.middleMouseButtonClick += value;
      remove => this.middleMouseButtonClick -= value;
    }

    private event MouseEventHandler rightMouseButtonClick;

    public event MouseEventHandler RightMouseButtonClick
    {
      add => this.rightMouseButtonClick += value;
      remove => this.rightMouseButtonClick -= value;
    }

    static MetaTabItem()
    {
      FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (MetaTabItem), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (MetaTabItem)));
    }

    public void Terminate()
    {
      RoutedEventArgs e = new RoutedEventArgs();
      RoutedEventHandler closeButtonClick = this.closeButtonClick;
      if (closeButtonClick == null)
        return;
      closeButtonClick((object) this, e);
    }

    public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      this.closeButton = this.GetTemplateChild("PART_CloseButton") as ButtonBase;
      this.dragLabel = this.GetTemplateChild("PART_DragLabel") as Label;
      if (this.closeButton != null && this.closeButtonClick != null)
        this.closeButton.Click += this.closeButtonClick;
      if (this.dragLabel == null)
        return;
      this.dragLabel.MouseUp += (MouseButtonEventHandler) ((s, o) =>
      {
        if (o.ChangedButton == MouseButton.Right)
        {
          MouseEventHandler mouseButtonClick = this.rightMouseButtonClick;
          if (mouseButtonClick == null)
            return;
          mouseButtonClick(s, (MouseEventArgs) o);
        }
        else
        {
          if (o.ChangedButton != MouseButton.Middle)
            return;
          MouseEventHandler mouseButtonClick = this.middleMouseButtonClick;
          if (mouseButtonClick == null)
            return;
          mouseButtonClick(s, (MouseEventArgs) o);
        }
      });
    }
  }
}
