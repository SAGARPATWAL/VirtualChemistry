using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabLib.Commands;
using System.Windows.Input;

namespace LabLib.ViewModels
{
   public class ApparatusBarViewModel : ViewModelBaseClass
   {
        #region VisibilityControl
        private bool vis;
        public bool Visi
        {
            get { return vis; }
            set
            {
                vis = value;
                OnPropertyChanged("Visi");
            }
        }
        #region visible Property for 2
        private bool otherVisible;
        public bool OtherVisible
        {
            get
            {
                return otherVisible;
            }
            set
            {
                otherVisible = value;
                OnPropertyChanged("OtherVisible");
            }
        }
        #endregion
        #region visible Property for properties
        private bool _propertyVisible;
        public bool PropertyVisible
        {
            get { return _propertyVisible; }
            set
            {
                _propertyVisible = value;
                OnPropertyChanged("PropertyVisible");
            }
        }
        #endregion
        #region CommandProperty
        private ExpandTheSideBar command;
        public ExpandTheSideBar Command
        {
            get { return command; }
            set
            {
                command = value;
                OnPropertyChanged("Command");
            }
        }
        #endregion
        public ApparatusBarViewModel(ExperimentWindowViewModel windowModel)
        {
            command = new ExpandTheSideBar(this);
            vis = false;
            OtherVisible = false;
            PropertyVisible = false;
        }

        public void DragApparatus(object sender, MouseEventArgs e)
        {

        }


        public void CollapseSideBarFor1()
        {
            if (Visi)
                Visi = false;
            else
                Visi = true;
        }
        public void CollapseSideBarFor2()
        {
            if (OtherVisible)
                OtherVisible = false;
            else
                OtherVisible = true;
        }
        public void CollapseSideBarFor3()
        {
            if (PropertyVisible)
                PropertyVisible = false;
            else
                PropertyVisible = true;
        }
        #endregion

        private ExperimentWindowViewModel _windowModel;
        public ExperimentWindowViewModel WindowModel
        {
            get { return _windowModel; }
        }
    }
}
