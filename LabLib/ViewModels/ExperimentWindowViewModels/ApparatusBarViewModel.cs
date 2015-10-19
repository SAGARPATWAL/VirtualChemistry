using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabLib.Commands;
using System.Windows.Input;
using LabLib.ExternalClasses;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using LabLib.Services;

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

        private List<Apparatus> _experimentApparatus;
        private ExperimentWindowViewModel _windowModel;
        private Apparatus _selectedApparatus;
        private RelayCommand _onApparatusSelectCommand;
        public List<Apparatus> ExperimentApparatus
        {
            get { return _experimentApparatus; }
            protected set
            {
                _experimentApparatus = value;
                OnPropertyChanged("ExperimentApparatus");
            }
        }
        
        /// <summary>
        /// Fills the apparatus list of the current class with the matching experiment from the main appratus list
        /// </summary>
        /// 
        
        public Apparatus SelectedApparatus
        {
            get
            {
                return _selectedApparatus;
            }

            set
            {
                _selectedApparatus = value;
                PublishMessage<Apparatus>(value);
                OnPropertyChanged("SelectedApparatus");
            }
        }

        public RelayCommand OnApparatusSelectCommand
        {
            get
            {
                return _onApparatusSelectCommand;
            }

            set
            {
                _onApparatusSelectCommand = value;
                OnPropertyChanged("OnApparatusSelectCommand");
            }
        }

        protected virtual void FillApparatuses()
        {
            try
            {
                ExperimentApparatus = AllApparatus.ApparatusList;
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Cannot fill Apparatus because AllApparatus.ApparatusList is null");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Cannot fill Apparatus");
            }
        }

        private void SetCommands()
        {
            _onApparatusSelectCommand = new RelayCommand()
            {
                CanExecuteCommand = (app) => { return true; },
                ExecuteCommand = (app) => {
                    Apparatus a = app as Apparatus;
                    PublishMessage<Apparatus>(a);
                }
        };
        }
        #region Dragging
        public void DragMethod(object sender,MouseEventArgs e)
        {
            StackPanel sp = FindAncestor<StackPanel>((DependencyObject)e.OriginalSource);
            ListViewItem listItem = FindAncestor<ListViewItem>((DependencyObject)e.OriginalSource);
            
            if (sp != null)
            {
                try
                {

                    DataObject obj = new DataObject("ControlFormat", sp.Tag.ToString());
                    DragDrop.DoDragDrop(listItem, obj, DragDropEffects.Move);
                    PublishMessage<Apparatus>(SelectedApparatus);
                }
                catch (System.NullReferenceException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {

            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);

            }
            while (current != null);
            return null;
        }

        #endregion
        public ApparatusBarViewModel()
        {
            command = new ExpandTheSideBar(this);
            vis = false;
            OtherVisible = false;
            PropertyVisible = false;
            FillApparatuses();
        }
    }
}
