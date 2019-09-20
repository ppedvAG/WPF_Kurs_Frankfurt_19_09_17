using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Commands
{
    //Commandklassen müssen das Interface ICommand implementieren
    public class CustomCommand : ICommand
    {
        //Diese Command-Klasse ist nicht spezialisiert. Sie kann über den Konstruktor mit beliebigen Methoden befüllt werden

        //Delegatedefinition
        public delegate bool CanExecuteDelegate(object parameter);
        public delegate void ExecuteDelegate(object parameter);

        //Eigenschaftsdefinitionen
        public CanExecuteDelegate CanExecuteMethod { get; set; }
        public ExecuteDelegate ExecuteMethod { get; set; }


        //Konstruktor
        public CustomCommand(CanExecuteDelegate can, ExecuteDelegate exe)
        {
            CanExecuteMethod = can;
            ExecuteMethod = exe;
        }


        //Eventanmeldung
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        //Methoden
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
