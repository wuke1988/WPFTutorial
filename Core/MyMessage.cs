using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class MyMessage
    {
        public string Str { get; set; }
        public override string ToString()
        {
            return Str;
        }
    }
}
