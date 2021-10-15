using System;
using System.Windows.Input;

namespace MaterialXAMLDialogs.Framework
{
    public class RelayCommand : ICommand
    {
        // Fields
        private readonly Predicate<object> _canExecute;
        private readonly Action _execute;
        private event EventHandler CanExecuteChangedInternal;

        // Properties
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
                CanExecuteChangedInternal += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
                CanExecuteChangedInternal -= value;
            }
        }

        // Constructors
        public RelayCommand(Predicate<object> canExecute, Action execute)
        {
            _canExecute = canExecute;
            _execute = execute;
        }

        // Methods
        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }
        public void Execute(object parameter)
        {
            _execute();
        }
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChangedInternal?.Invoke(this, EventArgs.Empty);
        }
    }
}
