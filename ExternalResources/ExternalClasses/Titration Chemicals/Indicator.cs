﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using ExternalResources.Apparatuses;
namespace LabLib.ExternalClasses.Titration_Chemicals
{
    public class Indicator : Chemical
    {
        private Color endColor;

        public Color EndColor
        {
            get { return endColor; }
            set { endColor = value; }
        }

        public Indicator(string name,Color color)
        {
            this.ChemicalName = name;
            this.endColor = color;
        }
        public Indicator() { }
    }
}
