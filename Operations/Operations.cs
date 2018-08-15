using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations
{    
    public class Operations
    {
        [Export("Add",typeof(Func<double, double, double>))]
        public double Add(double x, double y)
        {
            return x + y;
        }
        [Export("Subtract",typeof(Func<double,double,double>))]
        public double Subtract(double x, double y)
        {
            return x - y;
        }
    }
}
