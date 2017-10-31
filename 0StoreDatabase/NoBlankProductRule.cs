using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace _0StoreDatabase
{
    public class NoBlankProductRule1 : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            BindingGroup bindingGroup = (BindingGroup)value;
            Product product = bindingGroup.Items[0] as Product;
            //多重属性验证逻辑.....

            return new ValidationResult(true,null);
        }
    }
}
