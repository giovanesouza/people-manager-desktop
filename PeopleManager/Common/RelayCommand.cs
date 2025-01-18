using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PeopleManager.Common
{
    /*
    public class RelayCommand : ICommand
    {     
        private Action<object> _execute;
        private Func<object, bool> _canExecute;
        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this._execute = execute;
            this._canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        // Method to trigger the CanExecuteChanged event manually
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }


    }
      */


    public class RelayCommand<T> : ICommand
    {
        private readonly Func<T, Task> _executeAsync;
        private readonly Action<T> _execute;
        private readonly Func<T, bool> _canExecute;
        private bool _isExecuting;

        public RelayCommand(Action<T> execute, Func<T, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public RelayCommand(Func<T, Task> executeAsync, Func<T, bool> canExecute = null)
        {
            _executeAsync = executeAsync ?? throw new ArgumentNullException(nameof(executeAsync));
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return !_isExecuting && (_canExecute == null || _canExecute((T)parameter));
        }

        public virtual async void Execute(object parameter)
        {
            _isExecuting = true;

            RaiseCanExecuteChanged();

            try
            {
                if (_executeAsync != null)
                {
                    await _executeAsync((T)parameter);
                }
                else
                {
                    _execute?.Invoke((T)parameter);
                }
            }
            finally
            {
                _isExecuting = false;
                RaiseCanExecuteChanged();
            }

        }

        private void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

    }
}
