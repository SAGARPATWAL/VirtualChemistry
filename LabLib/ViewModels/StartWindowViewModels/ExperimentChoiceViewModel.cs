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
        //edit

        private Action _takeAction;
        public Action TakeAction
        {
            get { return _takeAction; }
            set
            {
                _takeAction = value;
                OnPropertyChanged("TakeAction");
            }
        }
        public void ExecuteAction()
        {
            SelectedExperiment = getSelectedExperiment();
            TakeAction();


        }
        #region Selcted Experiment properties
        private bool _titration { get; set; }
        public bool Titration
        {
            get { return _titration; }
            set
            {
                _titration = value;
                OnPropertyChanged("Titration");
            }
        }

        private bool _redox { get; set; }
        public bool Redox
        {
            get { return _redox; }
            set
            {
                _redox = value;
                OnPropertyChanged("Redox");
            }
        }

        private bool _something { get; set; }
        public bool something
        {
            get { return _something; }
            set
            {
                _something = value;
                OnPropertyChanged("something");
            }
        }

        private bool _otherthing { get; set; }
        public bool otherthing
        {
            get { return _otherthing; }
            set
            {
                _otherthing = value;
                OnPropertyChanged("otherthing");
            }
        }
        #endregion
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

            Titration = true;
            Redox = false;
            //this.ChoiceWindow = ChoiceWindow;
            SelectedExperiment = "";
            _openExperimentCommand = new OpenExperimentWindowCommand(this);
            _experimentList = XMLManipulation.GetExperiments();

        }

        private string getSelectedExperiment()
        {
            if (Titration)
                return "AcidBaseTitration";
            else if (Redox)
                return "RedoxReaction";
            else if (something)
                return "SomeReaction";
            else if (otherthing)
                return "OtherReaction";
            else return "Acid Base Titration";
        }


    }
}
