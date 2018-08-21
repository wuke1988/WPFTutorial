using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4IHandlerForLanguageChange.Resource
{
    public interface IResource
    {
        CultureInfo CultureInfo { set; get; }
        string GetString(string key);
    }
}
