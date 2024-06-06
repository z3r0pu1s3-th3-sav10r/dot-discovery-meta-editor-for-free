using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

#nullable enable
namespace Meta.Editor.Controls
{
  public class MessageBoxClickCommand : ICommand
  {
    public event EventHandler CanExecuteChanged
    {
      add => CommandManager.RequerySuggested += value;
      remove => CommandManager.RequerySuggested -= value;
    }

    public bool CanExecute(object parameter) => true;

    public void Execute(object parameter)
    {
      Button button = parameter as Button;
      MetaMessageBox window = Window.GetWindow((DependencyObject) button) as MetaMessageBox;
      MessageBoxResult result;
      switch ((string) button.Content)
      {
        case "OK":
          result = MessageBoxResult.OK;
          break;
        case "No":
          result = MessageBoxResult.No;
          break;
        case "Yes":
          result = MessageBoxResult.Yes;
          break;
        default:
          result = MessageBoxResult.Cancel;
          break;
      }
      window.RequestClose(result);
    }
  }
}
