using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabLib.ExternalClasses
{
    public abstract class Chemical
    {
        protected double _volume;
        protected string _chemicalName;

        public double Volume
        {
            get { return Volume; }
            set
            {
                Volume = value;
            }
        }

        public string ChemicalName
        {
            get { return _chemicalName; }
            set
            {
                _chemicalName = value;
            }
        }
    }
}
