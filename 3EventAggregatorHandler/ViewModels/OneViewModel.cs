using Caliburn.Micro;
using Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3EventAggregatorHandler.ViewModels
{
    [Export(typeof(OneViewModel))]
    public class OneViewModel : PropertyChangedBase, IHandle<string>
    {
        private readonly IEventAggregator _event;
        private string _oneMessage;
        public string OneMessage
        {
            get { return _oneMessage; }
            set
            {
                _oneMessage = value;
                NotifyOfPropertyChange(()=>OneMessage);
            }
        }
        [ImportingConstructor]
        public OneViewModel()
        {
            _event = IoC.Get<IEventAggregator>();
            _event.Subscribe(this);
        }
        public void Handle(string message)
        {
            OneMessage = message;
        }
        public void Publish()
        {
            _event.PublishOnUIThread(new MyMessage { Str = $"{OneMessage} One!" });
        }
    }
}
