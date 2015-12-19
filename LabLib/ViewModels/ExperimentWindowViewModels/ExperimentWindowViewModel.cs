namespace LabLib.ViewModels
{
    public class ExperimentWindowViewModel : ViewModelBaseClass
    {
        private ApparatusBarViewModel appViewModel; 
        private ExperimentGridViewModel experimentGridViewModel;
        private PropertiesViewModel propertiesViewModel;
        private string _experimentName;

        public ApparatusBarViewModel ApparatusBarViewModel
        {
            get { return appViewModel; }
            set { appViewModel = value;
                OnPropertyChanged("ApparatusBarViewModel");
            }
        }

        public string ExperimentName
        {
            get { return _experimentName; }
            set
            {
                _experimentName = value;
                OnPropertyChanged("ExperimentName");
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

        public PropertiesViewModel PropertiesViewModel
        {
            get
            {
                return propertiesViewModel;
            }

            set
            {
                propertiesViewModel = value;
                OnPropertyChanged("PropertiesViewModel");
            }
        }

        public ExperimentWindowViewModel()
        {
            //switch(experimentName)
            //{
            //    case "AcidBaseTitration":
            //        this.ApparatusBarViewModel = new AcidBaseExperiment.AcidBaseApparatusBarViewModel();
            //        this.ExperimentGridViewModel = new AcidBaseExperiment.AcidBaseExperimentGridViewModel(); break;
            //    case "Something": break;
            //    default: ExperimentGridViewModel = new ExperimentGridViewModel();
            //        ApparatusBarViewModel = new ApparatusBarViewModel(); break;
            //}
            ApparatusBarViewModel = new ApparatusBarViewModel();
            ExperimentGridViewModel = new ExperimentGridViewModel();
            PropertiesViewModel = new PropertiesViewModel();
        }
    }
}
