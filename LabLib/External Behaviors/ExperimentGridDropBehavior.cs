using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;

namespace LabLib.External_Behaviors
{
    public class ExperimentGridDropBehavior : Behavior<UIElement>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.AllowDrop = true;
            this.AssociatedObject.Drop += AssociatedObject_Drop;
        }

        private void AssociatedObject_Drop(object sender, DragEventArgs e)
        {
           
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.Drop -= AssociatedObject_Drop;
        }
    }
}
