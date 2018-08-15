using Operations;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorContract;

namespace SimpleCalculator
{
    [Export(typeof(ICalculator))]
    public class Calculator : ICalculator
    {
        [Import("Add",typeof(Func<double,double,double>))]
        public Func<double, double, double> AddMethods { get; set; }

        [Import("Subtract", typeof(Func<double, double, double>))]
        public Func<double, double, double> SubtractMethods { get; set; }

        public IList<IOperation> GetOperations()
        {
            return new List<IOperation>()
            {
                new Operation { Name="+", NumberOperands=2},
                new Operation { Name="-", NumberOperands=2},
                new Operation { Name="/", NumberOperands=2},
                new Operation { Name="*", NumberOperands=2}
            };
        }

        public double Operate(IOperation operation, double[] operands)
        {
            double result = 0;
            switch (operation.Name)
            {
                case "+":
                    result = AddMethods(operands[0], operands[1]);
                    break;
                case "-":
                    result = SubtractMethods(operands[0], operands[1]);
                    break;
                case "*":
                    result = operands[0] * operands[1];
                    break;
                case "/":
                    result = operands[0] / operands[1];
                    break;
                default:
                    throw new InvalidOperationException($"Invalid Operation {operation.Name}");
            }
            return result;
        }
    }
}
