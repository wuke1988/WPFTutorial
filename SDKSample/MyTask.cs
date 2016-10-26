using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKSample
{
    public enum  TASKType
    {
        Work = 0,
        Home=1
    };

    public class MyTask
    {
        public string TaskName { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }

        public TASKType TaskType { get; set; }
    }
}
