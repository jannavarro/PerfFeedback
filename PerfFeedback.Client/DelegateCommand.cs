using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PerfFeedback.Client
{
    public class DelegateCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;

        public DelegateCommand(Predicate<object> canExecute, 
            Action<object> execute)
        {
            _execute = execute;
            _canExecute = canExecute;
            //CommandManager.RequerySuggested += (s, e) => myCommand.RaiseCanExecuteChanged();
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }

            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged;

        //event EventHandler CanExecuteChanged2
        //{
            
        //}

        public EventHandler GetCanExecuteChanged()
        {
            return CanExecuteChanged;
        }
    }
}
