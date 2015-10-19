using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabLib.ExternalClasses.Titration_Chemicals
{
    public class Base : Chemical
    {
        private double molarity;
        private double acidity;

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
    }
}
