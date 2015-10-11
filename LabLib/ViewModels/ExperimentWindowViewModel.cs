using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabLib.Commands;
namespace LabLib.ViewModels
{
    public class ExperimentWindowViewModel : ViewModelBaseClass
    {
        private ApparatusBarViewModel appViewModel; 
        private ExperimentGridViewModel experimentGridViewModel;
        
        public ApparatusBarViewModel ApparatusBarViewModel
        {
            get { return appViewModel; }
            set { appViewModel = value;
                OnPropertyChanged("ApparatusBarViewModel");
            }
        }

        public ExperimentGridViewModel ExperimentGridViewModel
        {
            get
            {
                return experimentGridViewModel;
            }

            set
            {
                experimentGridViewModel = value;
                OnPropertyChanged("ExperimentGridViewModel");
            }
        }

        public ExperimentWindowViewModel()
        {
            appViewModel = new ApparatusBarViewModel(this);
            experimentGridViewModel = new ExperimentGridViewModel(this);
        }
    }
}
