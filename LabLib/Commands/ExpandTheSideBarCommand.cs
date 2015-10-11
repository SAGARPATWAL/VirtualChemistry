using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LabLib.Commands
{
   public class ExpandTheSideBar : ICommand
    {
        #region ViewModel
        private ViewModels.ApparatusBarViewModel model;

        public ViewModels.ApparatusBarViewModel Model
        {
            get { return model; }
            set { model = value; }
        }
        #endregion


        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public ExpandTheSideBar(ViewModels.ApparatusBarViewModel m)
        {
            this.model = m;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (!(string.IsNullOrEmpty(parameter.ToString())))
                if (parameter.ToString() == "Toolbar")
                    model.CollapseSideBarFor1();
                else if (parameter.ToString() == "Properties")
                    model.CollapseSideBarFor3();
                else if (parameter.ToString() == "Help")
                    model.CollapseSideBarFor2();
        }
    }
}
