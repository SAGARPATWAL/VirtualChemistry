using LabLib.ExternalClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExternalResources.Apparatuses;

namespace LabLib.ViewModels
{
    public class ContainerAppartusViewModel : ApparatusViewModel
    {
        private Chemical chemical;
        private double volume;

        public Chemical Chemical
        {
            get
            {
                return chemical;
            }

            set
            {
                chemical = value;
                OnPropertyChanged("Chemical");
            }
        }
        public double VolumeOfApparatus
        {
            get
            {
                return volume;
            }

            set
            {
                volume = value;
                OnPropertyChanged("VolumeOfApparatus");
            }

        }

        private string _ChemicalPresent;
        public string ChemicalPresent
        {
            get { return _ChemicalPresent; }
            set
            {
                _ChemicalPresent = value;
                OnPropertyChanged("ChemicalPresent");
            }
        }
       

    }
}
