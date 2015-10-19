using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabLib.ExternalClasses.Titration_Chemicals
{
    public class Acid : Chemical
    {
        private double _molarity;
        private double _basisity;

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
    }
}
