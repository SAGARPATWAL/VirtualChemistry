using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabLib.ExternalClasses
{
    public class AcidBaseTitrationExperimentApparatus
    {
        private List<Apparatus> acidBaseApparatus;
        
        public List<Apparatus> AcidBaseApparatus
        {
            get { return acidBaseApparatus; }
            set
            {
                acidBaseApparatus = value;
            }
        }
        
        public AcidBaseTitrationExperimentApparatus() 
        {
            acidBaseApparatus = new List<Apparatus>();
            FillApparatuses();
        }
        public void FillApparatuses()
        {
            if (AllApparatus.ApparatusList != null)
            {
                AcidBaseApparatus = AllApparatus.ApparatusList.FindAll(delegate (Apparatus i)
                {
                    return i.Experiments.Contains("AcidBaseTitration");
                });
            }
        }
    }
}
