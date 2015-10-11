using LabLib.ExternalClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabLib.ViewModels
{
    public class AcidBaseExperimentViewModel  : ViewModelBaseClass
    {
        private AcidBaseTitrationExperimentApparatus apparatus;
        private ApparatusBarViewModel appViewModel;

        public AcidBaseTitrationExperimentApparatus Apparatus
        {
            get { return apparatus; }
            set
            {
                apparatus = value;
                
                OnPropertyChanged("Apparatus");
            }
        }

        public AcidBaseExperimentViewModel()
        {
            apparatus = new AcidBaseTitrationExperimentApparatus();
        }
    }
}
