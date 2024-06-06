using Meta.Editor.Controls;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

#nullable enable
namespace Meta.Editor.Windows
{
  public class InputWindow : MetaWindow, IComponentConnector
  {
    internal 
    #nullable disable
    Label lblQuestion;
    internal TextBox txtAnswer;
    internal Button btnDialogOk;
    private bool _contentLoaded;

    public InputWindow(
    #nullable enable
    string question, string defaultAnswer = "")
    {
      this.InitializeComponent();
      this.lblQuestion.Content = (object) question;
      this.txtAnswer.Text = defaultAnswer;
    }

    private void btnDialogOk_Click(object sender, RoutedEventArgs e)
    {
      this.DialogResult = new bool?(true);
    }

    private void Window_ContentRendered(object sender, EventArgs e)
    {
      this.txtAnswer.SelectAll();
      this.txtAnswer.Focus();
    }

    public string Answer => this.txtAnswer.Text;

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "7.0.11.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/Meta.Editor;V1.0.5.32;component/windows/inputwindow.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "7.0.11.0")]
    internal 
    #nullable disable
    Delegate _CreateDelegate(Type delegateType, string handler)
    {
      return Delegate.CreateDelegate(delegateType, (object) this, handler);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "7.0.11.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          this.lblQuestion = (Label) target;
          break;
        case 2:
          this.txtAnswer = (TextBox) target;
          break;
        case 3:
          this.btnDialogOk = (Button) target;
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
