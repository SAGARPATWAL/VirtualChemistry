using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace LabLib.External_Behaviors
{
    public class ApparatusDragBehavior : Behavior<UIElement>
    {

        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.PreviewMouseLeftButtonDown += AssociatedObject_MouseLeftButtonDown;
        }

        private void AssociatedObject_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            
            StackPanel sp = FindAncestor<StackPanel>((DependencyObject)e.OriginalSource);
            ListViewItem listItem = FindAncestor<ListViewItem>((DependencyObject)e.OriginalSource);
            
            if (sp != null)
            {
                try
                {
                    
                    DataObject obj = new DataObject("ControlFormat", sp.Tag.ToString());
                    DragDrop.DoDragDrop(listItem, obj, DragDropEffects.Move);
                }
                catch (System.NullReferenceException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch(System.Exception ex)
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



        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.MouseLeftButtonDown -= AssociatedObject_MouseLeftButtonDown;
        }

    }
}
