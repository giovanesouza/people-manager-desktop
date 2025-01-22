global using System;
global using System.Threading.Tasks;
global using System.Windows.Input;

namespace PeopleManager.Common
{
    public partial class RelayCommand<T> : ICommand
    {
        private readonly Func<T, Task> _executeAsyncWithParam;
        private readonly Action<T> _executeWithParam;
        private readonly Func<T, bool> _canExecuteWithParam;

        private readonly Func<Task> _executeAsyncWithoutParam;
        private readonly Action _executeWithoutParam;
        private readonly Func<bool> _canExecuteWithoutParam;

        private bool _isExecuting;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<T> execute, Func<T, bool> canExecute = null)
        {
            _executeWithParam = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecuteWithParam = canExecute;
        }

        public RelayCommand(Func<T, Task> executeAsync, Func<T, bool> canExecute = null)
        {
            _executeAsyncWithParam = executeAsync ?? throw new ArgumentNullException(nameof(executeAsync));
            _canExecuteWithParam = canExecute;
        }

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _executeWithoutParam = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecuteWithoutParam = canExecute;
        }
        public RelayCommand(Func<Task> executeAsync, Func<bool> canExecute = null)
        {
            _executeAsyncWithoutParam = executeAsync ?? throw new ArgumentNullException(nameof(executeAsync));
            _canExecuteWithoutParam = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            return !_isExecuting &&
                (_canExecuteWithParam?.Invoke((T)parameter) ??
                _canExecuteWithoutParam?.Invoke() ?? true);
        }
        public async void Execute(object parameter)
        {
            _isExecuting = true;
            RaiseCanExecuteChanged();
            try
            {
                if (_executeAsyncWithParam != null)
                {
                    await _executeAsyncWithParam((T)parameter);
                }
                else if (_executeWithParam != null)
                {
                    _executeWithParam((T)parameter);
                }
                else if (_executeAsyncWithoutParam != null)
                {
                    await _executeAsyncWithoutParam();
                }
                else
                {
                    _executeWithoutParam?.Invoke();
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
