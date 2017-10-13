using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleInstanceApplicationDemo
{
    public class Startup
    {
        [STAThread]
        public static void Main(string[] args)
        {
            SingleInstanceApplicationWrapper wrapper = new SingleInstanceApplicationWrapper();
            wrapper.Run(args);
        }
    }
}
