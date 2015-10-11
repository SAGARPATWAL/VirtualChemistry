using ExternalResources.Apparatuses;
using LabLib.ExternalClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LabLib.ViewModels
{
    
    public class ExperimentGridViewModel : ViewModelBaseClass
    {
        private int _apparatusCount;
        private string _workingExperiment;
        private int _gridRowCount;
        private int _gridColumnCount;
        private ExperimentWindowViewModel _windowModel;

        private ObservableCollection<Apparatus> _apparatusAppplied;

        public int ApparatusCount
        {
            get
            {
                return _apparatusCount;
            }
            set
            {
                _apparatusCount = value;
                OnPropertyChanged("ApparatusCount");
            }
        }

        public string WorkingExperiment
        {
            get
            {
                return _workingExperiment;
            }

            set
            {
                _workingExperiment = value;
                OnPropertyChanged("WorkingExperiment");
            }
        }

        public int GridRowCount
        {
            get
            {
                return _gridRowCount;
            }

            set
            {
                _gridRowCount = value;
                OnPropertyChanged("GridRowCount");
            }
        }

        public int GridColumnCount
        {
            get
            {
                return _gridColumnCount;
            }

            set
            {
                _gridColumnCount = value;
                OnPropertyChanged("GridColumnCount");
            }
        }

        public ObservableCollection<Apparatus> ApparatusAppplied
        {
            get
            {
                return _apparatusAppplied;
            }
            set
            {
                _apparatusAppplied = value;
                OnPropertyChanged("ApparatusApplied");
            }
        }

        public ExperimentWindowViewModel WindowModel
        {
            get { return _windowModel; }
        }

        public void DropApparatus(object sender, DragEventArgs e)
        {
            Grid grid = sender as Grid;
            if (e.Data.GetDataPresent("ControlFormat"))
            {
                string apparatusName = e.Data.GetData("ControlFormat").ToString();
                UIElement apparatusControl = GetApparatusFromStringData(apparatusName);
                if (apparatusControl != null)
                {
                    grid.Children.Add(apparatusControl);
                }
            }
        }

        private UIElement GetApparatusFromStringData(string apparatusName)
        {
            switch (apparatusName)
            {
                case "Conical Flask": return new ConicalFlask();
                case "Burette": return new Burette();
                case "Stand": return new Stand();
                default: return null;
            }
        }

        private void SetApparatusPosition(UIElement apparatus)
        {

        }

        public ExperimentGridViewModel(ExperimentWindowViewModel winModel)
        {
            _apparatusCount = 0;
            _workingExperiment = "";
            _gridColumnCount = 0;
            _gridColumnCount = 0;
            _windowModel = winModel;
        }

    }
}
