using CalculatorContract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WCalculator.ViewModel;

namespace WCalculator
{
    public class CalculatorManager : IDisposable
    {
        private DirectoryCatalog catalog;
        private CompositionContainer container;
        public CalculatorViewModel viewModel;
        public CalculatorImport calImport;
        private CalculatorExtensionImport calcExtensionImport;

        public CalculatorManager(CalculatorViewModel viewModel)
        {
            this.viewModel = viewModel;

        }
        public void InitializeContainer()
        {
            catalog = new DirectoryCatalog(Properties.Settings.Default.AddInDirectory);

            container = new CompositionContainer(catalog);

            calImport = new CalculatorImport();

            calcExtensionImport = new CalculatorExtensionImport();

            container.ComposeParts(calImport);

            catalog.Refresh();
            container.ComposeParts(calcExtensionImport);

            InitializeOperations();


            InitializeCalculatorExtensions();
        }
        public void InitializeOperations()
        {
            var operators = calImport.Calculators.Value.GetOperations();
            //var operators = container.GetExportedValues<ICalculator>(AttributedModelServices.GetContractName(typeof(ICalculator))).FirstOrDefault().GetOperations();
            viewModel.CalcAddInOperators.Clear();
            foreach (var op in operators)
            {
                viewModel.CalcAddInOperators.Add(op);
            }
        }
        public void InitializeCalculatorExtensions()
        {
           
            var calculatorExtensions = calcExtensionImport.CalculatorExtensions;
            viewModel.ActivatedExtensions.Clear();
            foreach (var op in calculatorExtensions)
            {
                viewModel.ActivatedExtensions.Add(op);
            }
        }

        public void InvokeCalculator(IOperation operation,double[] operands)
        {
           var calculator = calImport.Calculators.Value;
           viewModel.Result = calculator.Operate(operation,operands).ToString();
           viewModel.Input = "";
        }

        public void Dispose()
        {
            catalog.Dispose();
            container.Dispose();
        }
    }
}
