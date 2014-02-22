using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
namespace Northwind.ViewModel
{
   public class RelayCommand : ICommand
    {
       private Action<object> _execute;
       private Func<object, bool> _canExecute;
       
       public RelayCommand( Action<object> execute)
           : this(execute, null) {}

       public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
        {
           this._execute = execute;
           this._canExecute = canExecute;
       }

        public bool CanExecute(object parameter)
        {
            if (_canExecute != null)
                return _canExecute(parameter);

            return true;
        }

        public event EventHandler CanExecuteChanged = delegate {};

        public void RaiseExecuteChanged()
        {
            CanExecuteChanged(this, new EventArgs());
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
