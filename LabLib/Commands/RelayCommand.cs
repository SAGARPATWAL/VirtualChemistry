using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LabLib.Commands
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public Action<Object> ExecuteCommand { get; set; }
        public Predicate<object> CanExecuteCommand { get; set; }
        public bool CanExecute(object parameter)
        {
            return this.CanExecuteCommand.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            ExecuteCommand.Invoke(parameter);
        }
    }
}
