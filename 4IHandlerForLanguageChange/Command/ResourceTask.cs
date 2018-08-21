using _4IHandlerForLanguageChange.Resource;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _4IHandlerForLanguageChange.Command
{
    public class ResourceTask : IResourceTask
    {
        [ImportMany(typeof(IResource))]
        public IResource[] Resources { get; set; }

        public ResourceTask()
        {
           
        }

        public void ChangeLanguage(string language)
        {
            CultureInfo cultureInfo = new CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            Thread.CurrentThread.CurrentCulture = cultureInfo;

            Resources.Apply(item=>item.CultureInfo = cultureInfo);


            IEventAggregator eventAggregator = IoC.Get<IEventAggregator>();
            eventAggregator.PublishOnUIThread(new LanguageChangedMessage());
        }
        public string GetString(string key)
        {
            string str = null;

            if (Resources.Any())
                str = Resources.First().GetString(key);
            return str;
        }
    }
}
