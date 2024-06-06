using System;
using System.Diagnostics;
using System.Windows.Input;

#nullable enable
namespace Meta.Editor.Commands
{
  public class RelayCommand : ICommand
  {
    private readonly Action<object> _execute;
    private readonly Predicate<object> _canExecute;

    public RelayCommand(Action<object> execute)
      : this(execute, (Predicate<object>) null)
    {
    }

    public RelayCommand(Action<object> execute, Predicate<object> canExecute)
    {
      this._execute = execute ?? throw new ArgumentNullException(nameof (execute));
      this._canExecute = canExecute;
    }

    [DebuggerStepThrough]
    public bool CanExecute(object parameters)
    {
      return this._canExecute == null || this._canExecute(parameters);
    }

    public event EventHandler CanExecuteChanged
    {
      add => CommandManager.RequerySuggested += value;
      remove => CommandManager.RequerySuggested -= value;
    }

    public void Execute(object parameters) => this._execute(parameters);
  }
}
