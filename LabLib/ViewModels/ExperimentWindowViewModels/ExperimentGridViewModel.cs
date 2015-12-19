using ExternalResources.Apparatuses;
using LabLib.ExternalClasses;
using LabLib.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace LabLib.ViewModels
{
    
    public class ExperimentGridViewModel : ViewModelBaseClass
    {
        #region Private backing Fields
        private Apparatus _droppedApparatus;
        private int _apparatusCount;
        private string _workingExperiment;
        private int _gridRowCount;
        private int _gridColumnCount;
        #endregion

        #region Public Properties

        private ObservableCollection<Apparatus> _apparatusAppplied;

        public int ApparatusCount
        {
            get
            {
                return _apparatusCount;
            }
            set
            {
                _apparatusCount = value;
                OnPropertyChanged("ApparatusCount");
            }
        }

        public string WorkingExperiment
        {
            get
            {
                return _workingExperiment;
            }

            set
            {
                _workingExperiment = value;
                OnPropertyChanged("WorkingExperiment");
            }
        }

        public int GridRowCount
        {
            get
            {
                return _gridRowCount;
            }

            set
            {
                _gridRowCount = value;
                OnPropertyChanged("GridRowCount");
            }
        }

        public int GridColumnCount
        {
            get
            {
                return _gridColumnCount;
            }

            set
            {
                _gridColumnCount = value;
                OnPropertyChanged("GridColumnCount");
            }
        }

        public ObservableCollection<Apparatus> ApparatusAppplied
        {
            get
            {
                return _apparatusAppplied;
            }
            set
            {
                _apparatusAppplied = value;
                OnPropertyChanged("ApparatusApplied");
            }
        }

        public Apparatus DroppedApparatus
        {
            get
            {
                return _droppedApparatus;
            }

            set
            {
                _droppedApparatus = value;
                OnPropertyChanged("DroppedApparatus");
            }
        }
        #endregion


        public override void Subscribe() //To Subscribe to the message, after this the provided method gets called when a view Model publishes 
            // a message containing a Apparatus
        {
            MessageBus.Subscribe<Apparatus>(OnApparatusDataRecieve);
        }
        public override void UnSubcscribe()
        {
            MessageBus.UnSubscribe<Apparatus>(OnApparatusDataRecieve);
        }

        public void OnApparatusDataRecieve(Apparatus apparatus)
        {
            this._droppedApparatus = apparatus;
        }

        public void DropApparatus(object sender, DragEventArgs e)
        {
            Canvas canvas = sender as Canvas;
            
            if (e.Data.GetDataPresent("ControlFormat"))
            {
                string apparatusName = e.Data.GetData("ControlFormat").ToString();
                UserControl apparatusControl = GetApparatusFromStringData(apparatusName);

                try
                {
                    if (this.ApparatusAppplied.Any<Apparatus>((i) => (i.AppratusName == DroppedApparatus.AppratusName)))
                    {
                        MessageBox.Show("You can drop an apparatus only once");
                    }
                    else
                    {
                        if (apparatusControl != null)
                        {
                            SetApparatusPosition(apparatusControl,canvas);
                            if (apparatusControl is ContainerApparatus)
                            {
                                SetApparatusBinding((ContainerApparatus)apparatusControl);
                            }
                            this.ApparatusAppplied.Add(DroppedApparatus);
                        }
                    }
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void FillApparatusApplied(string apparatusName)
        {
            
        }

        private UserControl GetApparatusFromStringData(string apparatusName)
        {
            switch (apparatusName)
            {
                case "Conical Flask": return new ConicalFlask();
                case "Burette": return new Burette();
                case "Stand": return new Stand();
                default: return null;
            }
        }

        private void SetApparatusBinding(ContainerApparatus apparatus)
        {
            apparatus.DataContext = new ContainerAppartusViewModel() { VolumeOfApparatus = apparatus.Volume,ChemicalPresent=apparatus.Chemical };
            
            /*Binding bind = new Binding();
            bind.Path = new PropertyPath("Volume");
            apparatus.SetBinding(ContainerApparatus.VolumeProperty, bind);*/
        }

        protected virtual void SetApparatusPosition(UIElement apparatusControl,Canvas canvas)
        {
            canvas.Children.Add(apparatusControl);
            Canvas.SetTop(apparatusControl,DroppedApparatus.CanvasProperties.Top);
            Canvas.SetLeft(apparatusControl, DroppedApparatus.CanvasProperties.Left);
            Panel.SetZIndex(apparatusControl, DroppedApparatus.CanvasProperties.Zindex);
        }

        public ExperimentGridViewModel()
        {
            _apparatusCount = 0;
            _workingExperiment = "";
            _gridColumnCount = 0;
            _gridColumnCount = 0;
            _apparatusAppplied = new ObservableCollection<Apparatus>();
        }

    }
}
