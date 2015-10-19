using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabLib.ViewModels
{
    public abstract class  ApparatusViewModel : ViewModelBaseClass
    {
        private string apparatusName;

        public string ApparatusName
        {
            get
            {
                return apparatusName;
            }

            set
            {
                apparatusName = value;
                OnPropertyChanged("ApparatusViewModel");
            }
        }

    }
}
