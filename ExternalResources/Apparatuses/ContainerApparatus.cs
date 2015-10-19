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
            ChemicalNames = new ObservableCollection<string>();
            ChemicalName = "";
        }
        public static readonly DependencyProperty VolumeProperty = DependencyProperty.Register("Volume", typeof(double), typeof(ContainerApparatus), new PropertyMetadata(0.0));
        public double Volume
        {
            get { return (double)GetValue(VolumeProperty); }
            set { SetValue(VolumeProperty, value); }
        }

        public static readonly DependencyProperty ChemicalNameProperty = DependencyProperty.Register("ChemicalName", typeof(string), typeof(ContainerApparatus));
        public string ChemicalName
        {
            get { return (string)GetValue(ChemicalNameProperty); }
            set { SetValue(ChemicalNameProperty, value); }
        }

        public static readonly DependencyProperty ChemicalNamesProperty = DependencyProperty.Register("ChemicalNames", typeof(ObservableCollection<string>), typeof(ContainerApparatus));
        public ObservableCollection<string> ChemicalNames
        {
            get { return (ObservableCollection<string>)GetValue(ChemicalNamesProperty); }
            set
            {
                SetValue(ChemicalNamesProperty, value);
            }
        }
            
    }
}
