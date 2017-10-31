using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace _0StoreDatabase
{
    public class PositivePriceRule : ValidationRule
    {
        private decimal min = 0;
        private decimal max = decimal.MaxValue;

        public decimal Min
        {
            get { return min; }
            set { min = value; }
        }
        public decimal Max
        {
            get { return max; }
            set { max = value; }
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            decimal price = 0;
            try
            {
                price = decimal.Parse(value.ToString());
            }
            catch (Exception ex)
            {
                return new ValidationResult(false,"Illegal characters."); 
            }
            if (price < min || price > max)
                return new ValidationResult(false, $"Not in {min} to {max}.");
            else
                return new ValidationResult(true,null);
        }
    }
}
