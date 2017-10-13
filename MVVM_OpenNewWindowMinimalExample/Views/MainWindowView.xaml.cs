using System;
using System.Windows;
using System.Windows.Input;

namespace MVVM_OpenNewWindowMinimalExample.Views {
    public partial class MainWindowView : Window {

        public ICommand ExitCommand { get; }

        public MainWindowView() {
            InitializeComponent();

            ExitCommand = new DelegateCommand(_ => Close());
        }
    }

    class DelegateCommand : ICommand
    {
        protected readonly Predicate<object> _canExecute;
        protected readonly Action<object> _execute;

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action<object> execute) : this(execute, _ => true) { }

        public DelegateCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("Action excute is null");
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public void RaiseCanExecuteChanged()
          => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        event EventHandler ICommand.CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
