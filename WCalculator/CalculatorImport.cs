using CalculatorContract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCalculator
{
    public class CalculatorImport
    {
        public event EventHandler<ImportEventArgs> ImportsSatisfied;
        [Import(typeof(ICalculator))]
        public Lazy<ICalculator> Calculators { get; set; }

        public void OnImportsSatisfied()
        {
            if (ImportsSatisfied != null)
            {
                ImportsSatisfied(this,new ImportEventArgs() { StatusMessage= "ICalculator import successful" });
            }
        }
    }
    public class ImportEventArgs : EventArgs
    {
        public string StatusMessage { get; set; }
    }
}
