using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelCalculator
{
    public class FuelEconomyType
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string DistanceText { get; set; }
        public string FuelText { get; set; }

        public override string ToString()
        {
            return Text;
        }

    }
}
