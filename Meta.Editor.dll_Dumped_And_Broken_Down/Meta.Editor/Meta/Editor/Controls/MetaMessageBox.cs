using System;
using System.Threading;
using System.Windows;

#nullable enable
namespace Meta.Editor.Controls
{
  public class MetaMessageBox : MetaDockableWindow
  {
    public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof (Text), typeof (string), typeof (MetaMessageBox), new PropertyMetadata((object) ""));
    public static readonly DependencyProperty AlignmentProperty = DependencyProperty.Register(nameof (Alignment), typeof (TextAlignment), typeof (MetaMessageBox), new PropertyMetadata((object) TextAlignment.Left));
    public static readonly DependencyProperty ButtonsProperty = DependencyProperty.Register(nameof (Buttons), typeof (MessageBoxButton), typeof (MetaMessageBox), new PropertyMetadata((object) MessageBoxButton.OK));

    public string Text
    {
      get => (string) this.GetValue(MetaMessageBox.TextProperty);
      set => this.SetValue(MetaMessageBox.TextProperty, (object) value);
    }

    public TextAlignment Alignment
    {
      get => (TextAlignment) this.GetValue(MetaMessageBox.AlignmentProperty);
      set => this.SetValue(MetaMessageBox.AlignmentProperty, (object) value);
    }

    public MessageBoxButton Buttons
    {
      get => (MessageBoxButton) this.GetValue(MetaMessageBox.ButtonsProperty);
      set => this.SetValue(MetaMessageBox.ButtonsProperty, (object) value);
    }

    public MessageBoxResult MessageBoxResult { get; set; }

    public MetaMessageBox()
    {
      this.Topmost = true;
      this.ShowInTaskbar = false;
      this.ResizeMode = ResizeMode.NoResize;
      this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
      this.MessageBoxResult = MessageBoxResult.Cancel;
      this.SizeToContent = SizeToContent.Height;
      this.Width = 500.0;
      this.Height = 150.0;
      this.Icon = Application.Current.MainWindow.Icon;
    }

    public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      this.Width = 100.0;
    }

    public void RequestClose(MessageBoxResult result)
    {
      this.MessageBoxResult = result;
      this.Close();
    }

    public static MessageBoxResult Show(string text)
    {
      bool rememberAction = false;
      return MetaMessageBox.ShowInternal(text, "", MessageBoxButton.OK, false, ref rememberAction);
    }

    public static MessageBoxResult Show(string text, string title)
    {
      bool rememberAction = false;
      return MetaMessageBox.ShowInternal(text, title, MessageBoxButton.OK, false, ref rememberAction);
    }

    public static MessageBoxResult Show(string text, string title, MessageBoxButton button)
    {
      bool rememberAction = false;
      return MetaMessageBox.ShowInternal(text, title, button, false, ref rememberAction);
    }

    public static MessageBoxResult Show(
      string text,
      string title,
      MessageBoxButton button,
      ref bool rememberAction)
    {
      return MetaMessageBox.ShowInternal(text, title, button, true, ref rememberAction);
    }

    private static MessageBoxResult ShowInternal(
      string text,
      string title,
      MessageBoxButton button,
      bool rememberActionPrompt,
      ref bool rememberAction)
    {
      MessageBoxResult msgBoxResult = MessageBoxResult.None;
      TextAlignment alignment = TextAlignment.Center;
      if (text.Contains("\r\n"))
        alignment = TextAlignment.Left;
      if (Thread.CurrentThread.GetApartmentState() != 0)
      {
        bool result = false;
        bool flag = false;
        Application.Current.Dispatcher.Invoke((Action) (() =>
        {
          MetaMessageBox metaMessageBox = new MetaMessageBox()
          {
            Text = text,
            Title = title,
            Buttons = button,
            Alignment = alignment
          };
          metaMessageBox.ShowDialog();
          result = true;
          msgBoxResult = metaMessageBox.MessageBoxResult;
        }));
        while (!result)
          Thread.Sleep(10);
        rememberAction = flag;
      }
      else
      {
        MetaMessageBox metaMessageBox1 = new MetaMessageBox();
        metaMessageBox1.Text = text;
        metaMessageBox1.Title = title;
        metaMessageBox1.Buttons = button;
        metaMessageBox1.Alignment = alignment;
        MetaMessageBox metaMessageBox2 = metaMessageBox1;
        metaMessageBox2.ShowDialog();
        msgBoxResult = metaMessageBox2.MessageBoxResult;
      }
      return msgBoxResult;
    }
  }
}
