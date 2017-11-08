﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace _2FormatDataBinding
{
    public class PriceToBackgroundConverter : IValueConverter
    {
        public decimal MinimumPriceToHighlight
        {
            get;set;
        }
        public Brush HeighBrush
        {
            get;set;
        }
        public Brush DefaultBrush
        {
            get;set;
        }
            
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal price = (decimal)value;
            if (price > MinimumPriceToHighlight)
                return HeighBrush;
            return DefaultBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
