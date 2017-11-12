using _0StoreDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace _2FormatDataBinding
{
    public class TemplateSelector:DataTemplateSelector
    {
        public DataTemplate DefaultTemplate
        {
            get;set;
        }
        public DataTemplate HighlightTemplate
        {
            get;set;
        }
        public string PropertyToEvaluate
        {
            get;
            set;
        }
        public string PropertyValueToHighlight
        {
            get;
            set;
        }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Product product = item as Product;
            PropertyInfo property = product.GetType().GetProperty(PropertyToEvaluate);

            if (property.GetValue(product).ToString() == PropertyValueToHighlight)
            {
                return HighlightTemplate;
            }
            else
            {
                return DefaultTemplate;
            }
        }
    }
}
