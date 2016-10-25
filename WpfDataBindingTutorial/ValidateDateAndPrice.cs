using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfDataBindingTutorial
{
    public class ValidateDateAndPrice : ValidationRule
    {
        // Ensure that an item over $100 is available for at least 7 days.
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            BindingGroup bg = value as BindingGroup;

            // Get the source object.
            PurchaseItem item = bg.Items[0] as PurchaseItem;

            object doubleValue;
            object dateTimeValue;

            // Get the proposed values for Price and OfferExpires.
            bool priceResult = bg.TryGetValue(item, "Price", out doubleValue);
            bool dateResult = bg.TryGetValue(item, "OfferExpires", out dateTimeValue);

            if (!priceResult || !dateResult)
            {
                return new ValidationResult(false, "Properties not found");
            }

            double price = (double)doubleValue;
            DateTime offerExpires = (DateTime)dateTimeValue;

            // Check that an item over $100 is available for at least 7 days.
            if (price > 100)
            {
                if (offerExpires < DateTime.Today + new TimeSpan(7, 0, 0, 0))
                {
                    return new ValidationResult(false, "Items over $100 must be available for at least 7 days.");
                }
            }

            return ValidationResult.ValidResult;

        }
    }
}
