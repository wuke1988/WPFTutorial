using _4IHandlerForLanguageChange.Command;
using Caliburn.Micro;
using Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4IHandlerForLanguageChange.ViewModels
{
    [Export(typeof(IShell))]
    public class MyViewModel:Screen
    {
        public void ChanguageLanguage(string str)
        {
            IResourceTask resourceTask = IoC.Get<IResourceTask>();

            switch (str)
            {
                case "zh":
                    resourceTask.ChangeLanguage("zh-CN");
                    break;
                case "en":
                    resourceTask.ChangeLanguage("en-US");
                    break;
            }
        }
    }
}
