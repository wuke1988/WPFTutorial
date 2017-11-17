using _0StoreDatabase;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace _4ListViewTreeDataGrid
{
    public class PriceToBackgroundConverter : IValueConverter
    {
        public Brush HighlightBrush
        { get; set; }
        public decimal MinPrice
        { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Product product = (Product)value;

            if (product.UnitCost >= MinPrice)
            {
                return HighlightBrush;
            }
            else
            {
                return Brushes.Transparent;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
