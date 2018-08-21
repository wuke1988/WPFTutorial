using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace _4IHandlerForLanguageChange.Command
{
    public class MyResourceExtension : MarkupExtension, INotifyPropertyChanged, IHandle<LanguageChangedMessage>
    {
        public string Key { get; set; }
        public string Value
        {
            get
            {
                if (Key == null)
                    return null;
                IResourceTask resourceTask = IoC.Get<IResourceTask>();
                return resourceTask.GetString(Key);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public MyResourceExtension()
        {
            if (!Execute.InDesignMode)
                IoC.Get<IEventAggregator>().Subscribe(this);
        }
        public void Handle(LanguageChangedMessage message)
        {
            if (PropertyChanged != null)
                PropertyChanged(this,new PropertyChangedEventArgs("Value"));
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            IProvideValueTarget target = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
            Binding binding = new Binding("Value") { Source = this, Mode = BindingMode.OneWay };
            return binding.ProvideValue(serviceProvider) as BindingExpression;
        }
    }
}
