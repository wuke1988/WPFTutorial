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
    public class SingleCriteriaHighStyleSelector:StyleSelector
    {
        public Style DefaultStyle
        { get; set; }
        public Style HighlightStyle
        { get; set; }
        public string PropertyToEvaluate
        { get; set; }
        public string PropertyValueToHighlight
        { get; set; }
        public override Style SelectStyle(object item, DependencyObject container)
        {
            Product product = item as Product;
            //使用反射获取指定属性的值，并与设定值比较
            PropertyInfo property = item.GetType().GetProperty(PropertyToEvaluate);
            if (property.GetValue(item).ToString() == PropertyValueToHighlight)
            {
                return HighlightStyle;
            }
            return DefaultStyle;
        }

    }
}
