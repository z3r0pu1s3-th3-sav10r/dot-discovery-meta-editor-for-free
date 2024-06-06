using System;
using System.Windows;
using System.Windows.Input;

#nullable enable
namespace Meta.Editor.Controls
{
  public class WindowCloseCommand : ICommand
  {
    public bool CanExecute(object parameter) => true;

    public event EventHandler CanExecuteChanged;

    public void Execute(object parameter)
    {
      if (!(parameter is Window window))
        return;
      window.Close();
    }
  }
}
