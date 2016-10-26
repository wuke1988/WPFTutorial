using SDKSample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfDataTemplateTutorial
{
    public class MyTaskListDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;
            MyTask myTask = item as MyTask;
            if (myTask.Priority == 1)
            {               
                return element.FindResource("importantTaskTemplate") as DataTemplate;
            }
            else
            {
                return element.FindResource("myTemplate") as DataTemplate;
            }
        }
    }
}
