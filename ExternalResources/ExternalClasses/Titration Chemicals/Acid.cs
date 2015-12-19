using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExternalResources.Apparatuses;
namespace LabLib.ExternalClasses.Titration_Chemicals
{
    public class Acid : Chemical
    {
        private double _molarity;
        private double _basisity;
        private double _normality;

        public double Normality
        {
            get { return _normality; }
            set
            {
                _molarity = value;
            }
        }
        public double Molarity
        {
            get
            {
                return _molarity;
            }

            set
            {
                _molarity = value;
            }
        }

        public double Basisity
        {
            get
            {
                return _basisity;
            }
            set
            {
                _basisity = value;
            }
        }

        public Acid()
        {
            
        }
        public Acid(string name,double mol,double nor, double basisity)
        {
            this.ChemicalName = name;
            this.Molarity = mol;
            Normality = nor;
            this.Basisity = basisity;
        }
    }
}
