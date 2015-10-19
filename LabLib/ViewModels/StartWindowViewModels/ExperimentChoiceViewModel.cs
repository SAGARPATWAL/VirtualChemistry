using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabLib.DataAccess;
using LabLib.Commands.ExperimentChoiceWindowCommands;
namespace LabLib.ViewModels.StartWindowViewModels
{
    public class ExperimentChoiceViewModel : ViewModelBaseClass
    {
        private string _selectedExperiment;
        private List<string> _experimentList;
        
        private OpenExperimentWindowCommand _openExperimentCommand;

        public List<string> ExperimentList
        {
            get { return _experimentList; }
            set
            {
                _experimentList = value;
                OnPropertyChanged("ExperimentList");
            }
        }

        public string SelectedExperiment
        {
            get { return _selectedExperiment; }
            set
            {
                _selectedExperiment = value;
                OnPropertyChanged("SelectedExperiment");
            }

        }

        public OpenExperimentWindowCommand OpenExperimentCommand
        {
            get { return _openExperimentCommand; }
            set
            {
                _openExperimentCommand = value;
                OnPropertyChanged("OpenExperimentCommand");
            }
        }

        public ExperimentChoiceViewModel()
        {
            _selectedExperiment = "";
            _openExperimentCommand = new OpenExperimentWindowCommand(this);
            _experimentList = XMLManipulation.GetExperiments();
        }

    }
}
