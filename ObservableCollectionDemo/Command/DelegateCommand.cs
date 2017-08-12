using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ObservableCollectionDemo.Command
{
    public class DelegateCommand : ICommand
    {
        readonly Action<object> _execute;
        readonly Predicate<object> _canExcute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public DelegateCommand(Action<object> action)
            :this(action,null)
        {

        }
        public DelegateCommand(Action<object> action, Predicate<object> predicate)
        {
            _execute = action;
            _canExcute = predicate;
        }

        public bool CanExecute(object parameter)
        {
            return _canExcute != null ? _canExcute(parameter):true;
        }

        public void Execute(object parameter)
        {
            _execute?.Invoke(parameter);
        }
    }
}
