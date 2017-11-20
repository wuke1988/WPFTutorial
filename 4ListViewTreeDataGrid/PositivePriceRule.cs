using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace _4ListViewTreeDataGrid
{
    public class PositivePriceRule : ValidationRule
    {
        public decimal Min { get; set; }
        public decimal Max { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            decimal price = 0;
            try
            {
                price = decimal.Parse(value.ToString(),NumberStyles.Any);
            }
            catch (Exception ex)
            {
                return new ValidationResult(false, "Illegal characters.");
            }
            if (price < Min || price > Max)
                return new ValidationResult(false, $"Not in {Min} to {Max}.");
            else
                return new ValidationResult(true, null);
        }
    }
}
