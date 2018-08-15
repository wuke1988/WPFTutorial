using CalculatorContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WCalculatorUtils;

namespace FuelCalculator
{
    [CalculatorExtensionExport(typeof(ICalculatorExtension),
        Title = "Fuel Economy",
        ImageUri = "Calculate fuel economy",
        Description = "Fuel.png")]
    public class FuelCalculatorExtension : ICalculatorExtension
    {
        private FrameworkElement control;

        public FrameworkElement UI
        {
            get { return control??(control=new FuelEconomyUserControl()); }
        }
    }
}
