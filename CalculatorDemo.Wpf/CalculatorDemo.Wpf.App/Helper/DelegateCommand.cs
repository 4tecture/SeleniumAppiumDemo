using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace SimpleCalculatorWpf.Helper
{
    public class DelegateCommand : ICommand
    {
        public DelegateCommand(Action executeAction)
        {
            this.executeAction = executeAction;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
        private Action executeAction;

        public void Execute(object parameter)
        {
            if (executeAction != null)
            {
                executeAction();
            }
        }
    }
}
