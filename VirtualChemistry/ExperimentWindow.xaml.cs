using System;
using System.Collections.Generic;
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
using LabLib.ViewModels;
using LabLib.Services;
using LabLib.ViewModels.AcidBaseExperiment;

namespace VirtualChemistry
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ExperimentWindow : Window
    {
        public ExperimentWindow()
        {
            InitializeComponent();
            string experimentName="AcidBaseTitration";
            ExperimentWindowViewModel vm;
            if (experimentName == "AcidBaseTitration")
            {
                vm = new AcidBaseExperimentViewModel();
            }
            else
            {
                vm = new ExperimentWindowViewModel();
            }
            MessageBus messageBus = new MessageBus();
            vm.MessageBus = messageBus;
            this.DataContext = vm;
            vm.ExperimentGridViewModel.MessageBus = messageBus;
            vm.ApparatusBarViewModel.MessageBus = messageBus;
            vm.PropertiesViewModel.MessageBus = messageBus;
            ExperimentGrid.DataContext = vm.ExperimentGridViewModel;
            SideBar.DataContext = vm.ApparatusBarViewModel;
            PropertiesGrid.DataContext = vm.PropertiesViewModel;
        }
    }
}
