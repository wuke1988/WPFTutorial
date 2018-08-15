using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCalculatorUtils
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method)]
    [MetadataAttribute]
    public class CalculatorExtensionExportAttribute:ExportAttribute
    {
        public CalculatorExtensionExportAttribute(Type contractType)
            :base(contractType)
        {            
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUri { get; set; }
    }
}
