using System;
using System.Windows.Input;

#nullable enable
namespace Meta.Editor.Commands
{
  public class ItemDoubleClickCommand : ICommand
  {
    private readonly ItemDoubleClickCommand.DoubleClickCommandDelegate commandToRun;

    public event EventHandler CanExecuteChanged;

    public ItemDoubleClickCommand(
      ItemDoubleClickCommand.DoubleClickCommandDelegate inCommand)
    {
      this.commandToRun = inCommand;
    }

    public bool CanExecute(object parameter) => true;

    public void Execute(object parameter)
    {
      ItemDoubleClickCommand.DoubleClickCommandDelegate commandToRun = this.commandToRun;
      if (commandToRun == null)
        return;
      commandToRun();
    }

    public delegate void DoubleClickCommandDelegate();
  }
}
