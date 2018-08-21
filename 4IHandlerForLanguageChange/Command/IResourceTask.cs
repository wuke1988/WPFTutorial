using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4IHandlerForLanguageChange.Command
{
    public interface IResourceTask
    {
        void ChangeLanguage(string language);
        string GetString(string name);
    }
}
