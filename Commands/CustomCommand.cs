using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Commands
{
    public class CustomCommand : ICommand
    {
        public delegate bool CanExecuteDelegate(object parameter);
        public delegate void ExecuteDelegate(object parameter);

        public CanExecuteDelegate CanExecuteMethod { get; set; }
        public ExecuteDelegate ExecuteMethod { get; set; }


        public CustomCommand(CanExecuteDelegate can, ExecuteDelegate exe)
        {
            CanExecuteMethod = can;
            ExecuteMethod = exe;
        }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        } 

        public bool CanExecute(object parameter)
        {
            return CanExecuteMethod(parameter);
        }

        public void Execute(object parameter)
        {
            ExecuteMethod(parameter);
        }
    }
}
