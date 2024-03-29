﻿using LabLib.DataAccess;
using LabLib.ExternalClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExternalResources.Apparatuses
{
    /// <summary>
    /// Interaction logic for ConicalFlask.xaml
    /// </summary>
    public partial class ConicalFlask : ContainerApparatus
    {
        public ConicalFlask()
        {
            InitializeComponent();
            this.Chemicals = new ObservableCollection<Chemical>(AllChemicals.AllChemials);
        }
    }
}
