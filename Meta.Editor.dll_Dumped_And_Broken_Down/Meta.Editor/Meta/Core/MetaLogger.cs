using Meta.Core.Interfaces;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Data;

#nullable enable
namespace Meta.Core
{
  public class MetaLogger : ILogger, INotifyPropertyChanged
  {
    private StringBuilder sb = new StringBuilder();

    public string LogText => this.sb.ToString();

    public void Log(string text, params object[] vars)
    {
      Assembly.GetCallingAssembly();
      string str = "[Core] ";
      this.sb.AppendLine(string.Format("[" + DateTime.Now.ToLongTimeString() + "]: " + str + text, vars));
      this.RaisePropertyChanged("LogText");
    }

    public void LogWarning(string text, params object[] vars)
    {
      Assembly.GetCallingAssembly();
      string str = "[Core] ";
      this.sb.AppendLine(string.Format("[" + DateTime.Now.ToLongTimeString() + "]: " + str + "(WARNING) " + text, vars));
      this.RaisePropertyChanged("LogText");
    }

    public void LogError(string text, params object[] vars)
    {
      Assembly.GetCallingAssembly();
      string str = "[Core] ";
      this.sb.AppendLine(string.Format("[" + DateTime.Now.ToLongTimeString() + "]: " + str + "(ERROR) " + text, vars));
      this.RaisePropertyChanged("LogText");
    }

    public void AddBinding(UIElement elementToBind, DependencyProperty propertyToBind)
    {
      Binding binding = new Binding("LogText")
      {
        Source = (object) this,
        Mode = BindingMode.OneWay
      };
      BindingOperations.SetBinding((DependencyObject) elementToBind, propertyToBind, (BindingBase) binding);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string name)
    {
      PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
      if (propertyChanged == null)
        return;
      propertyChanged((object) this, new PropertyChangedEventArgs(name));
    }
  }
}
