using LabLib.ExternalClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ExternalResources.Apparatuses
{
    public class ContainerApparatus : UserControl,IApparatusControl
    {
        public ContainerApparatus()
        {
            Volume = 0;
            //Chemicals = new ObservableCollection<Chemical>();    
            VolumesAvailable = new ObservableCollection<double>();
            VolumesAvailable.Add(10);
            VolumesAvailable.Add(20);
            VolumesAvailable.Add(30);
            VolumesAvailable.Add(40);
        }

        public static readonly DependencyProperty ApparatusNameProperty = DependencyProperty.Register("ApparatusName", typeof(string), typeof(ContainerApparatus));

        public string ApparatusName
        {
            get { return (string)GetValue(ApparatusNameProperty); }
            set
            {
                SetValue(ApparatusNameProperty, value);
            }
        }

        public static readonly DependencyProperty VolumeProperty = DependencyProperty.Register("Volume", typeof(double), typeof(ContainerApparatus), new PropertyMetadata(0.0));
        
        public double Volume
        {
            get { return (double)GetValue(VolumeProperty); }
            set { SetValue(VolumeProperty, value); }
        }

        public static readonly DependencyProperty ChemicalProperty = DependencyProperty.Register("Chemical", typeof(Chemical), typeof(ContainerApparatus));
        public string Chemical
        {
            get { return (string)GetValue(ChemicalProperty); }
            set { SetValue(ChemicalProperty, value); }
        }

        public static readonly DependencyProperty ChemicalsProperty = DependencyProperty.Register("Chemicals", typeof(ObservableCollection<Chemical>), typeof(ContainerApparatus));
        public ObservableCollection<Chemical> Chemicals
        {
            get { return (ObservableCollection<Chemical>)GetValue(ChemicalsProperty); }
            set
            {
                SetValue(ChemicalsProperty, value);
            }
        }

        public static readonly DependencyProperty VolumesAvailableProperty = DependencyProperty.Register("VolumeAvailable", typeof(ObservableCollection<double>), typeof(ContainerApparatus));
        public ObservableCollection<double> VolumesAvailable
        {
            get { return (ObservableCollection<double>)GetValue(VolumesAvailableProperty); }
            set
            {
                SetValue(VolumesAvailableProperty, value);
            }
        }
    }
}
