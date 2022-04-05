using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace XION_Aufgabe
{
    class DelegateCommand : ICommand
    {
        readonly Predicate<object> canExecute;
        readonly Action<object> execute;

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Predicate<object> canExecute, Action<object> execute)
        {
            this.canExecute = canExecute;
            this.execute = execute;
        }

        public DelegateCommand(Action<object> execute)
        {
            this.canExecute = null;
            this.execute = execute;
        }

        public void RaiseCanExecuteChanged()
        {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            if (canExecute != null)
            {
                canExecute.Invoke(parameter);
            }

            return true;
        }

        public void Execute(object parameter)
        {
            execute.Invoke(parameter);
        }
    }
}
