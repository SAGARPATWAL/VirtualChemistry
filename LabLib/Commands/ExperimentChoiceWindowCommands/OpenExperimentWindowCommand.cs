using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LabLib.ViewModels.StartWindowViewModels;

namespace LabLib.Commands.ExperimentChoiceWindowCommands
{
    public class OpenExperimentWindowCommand : ICommand
    {
        private ExperimentChoiceViewModel viewModel;

        public ExperimentChoiceViewModel ViewModel
        {
            get { return viewModel; }
            set
            {
                viewModel = value;
            }
        }

        event EventHandler ICommand.CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        bool ICommand.CanExecute(object parameter)
        {

            return true;

        }

        void ICommand.Execute(object parameter)
        {
            viewModel.ExecuteAction();
        }


        public OpenExperimentWindowCommand(ExperimentChoiceViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

    }
}
