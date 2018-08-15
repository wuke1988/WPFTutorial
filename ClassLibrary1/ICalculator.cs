using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  CalculatorContract
{
    public interface ICalculator
    {
        IList<IOperation> GetOperations();

        double Operate(IOperation operation,double[] operands);
    }
}
    