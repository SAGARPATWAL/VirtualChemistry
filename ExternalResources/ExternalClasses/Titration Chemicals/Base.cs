using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExternalResources.Apparatuses;
namespace LabLib.ExternalClasses.Titration_Chemicals
{
    public class Base : Chemical
    {
        private double molarity;
        private double acidity;
        private double normality;

        public double Normality
        {
            get
            {
                return normality;
            }
            set
            {
                normality = value;
            }
        }
        public double Molarity
        {
            get
            {
                return molarity;
            }

            set
            {
                molarity = value;
            }
        }

        public double Acidity
        {
            get
            {
                return acidity;
            }

            set
            {
                acidity = value;
            }
        }
        public Base(string name, double mol, double nor, double acidity)
        {
            this.ChemicalName = name;
            this.Molarity = mol;
            Normality = nor;
            this.Acidity = acidity;
        }
        public Base(){ }
    }
}
