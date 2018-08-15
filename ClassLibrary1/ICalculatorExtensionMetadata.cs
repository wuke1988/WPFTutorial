using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorContract
{
    public interface ICalculatorExtensionMetadata
    {
        string Title { get; }
        string Description { get; }

        string ImageUri { get; }
    }
}
