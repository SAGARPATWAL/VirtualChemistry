using System.Windows;
using System.Windows.Controls;
using ExternalResources.Apparatuses;
namespace LabLib.ExternalClasses
{
    public class PropertySelector:DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if(item!=null && item is ConicalFlask)
            {
                return (container as FrameworkElement).FindResource("Flask") as DataTemplate;
            }
            else if (item != null && item is Stand)
            {
                return (container as FrameworkElement).FindResource("Stand") as DataTemplate;
            }
            else if (item != null && item is Burette)
            {
                return (container as FrameworkElement).FindResource("Burette") as DataTemplate;
            }
            else
            {
                return null;
            }
        }
    }
}
