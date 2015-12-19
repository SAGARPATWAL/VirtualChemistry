
using LabLib.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabLib.ExternalClasses
{
    public class AllApparatus
    {
        /// <summary>
        /// Represents all apparatus used in modern chemistry
        /// </summary>
        private static readonly List<Apparatus> apparatusList = XMLManipulation.GetApparatuses();

        public static List<Apparatus> ApparatusList
        {
            get { return apparatusList; }
        }

        //static AllApparatus()
        //{
        //    apparatusList = XMLManipulation.GetApparatuses();
        //}

        
    }
}
