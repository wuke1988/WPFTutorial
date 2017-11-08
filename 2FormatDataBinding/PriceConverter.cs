using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace _2FormatDataBinding
{
    [ValueConversion(typeof(decimal),typeof(string))]
    public class PriceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal price = decimal.Parse(value.ToString());
            return price.ToString("C",culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string price = value.ToString();

            decimal result;
            if (Decimal.TryParse(price, NumberStyles.Any, culture, out result))
            {
                return result;
            }
            return value;
        }
    }
}
