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
    [Export(typeof(IShell))]
    public class ShellViewModel:PropertyChangedBase,IShell,IHandle<string>,IHandle<MyMessage>
    {
        private IEventAggregator _eventAggregator;
        private IWindowManager _windowManager;
        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                NotifyOfPropertyChange(()=>Message);
            }
        }
        [ImportingConstructor]
        public ShellViewModel(IWindowManager manager,IEventAggregator aggregator)
        {
            _eventAggregator = aggregator;
            _windowManager = manager;
            _eventAggregator.Subscribe(this);
        }

        public void Handle(string message)
        {
            Message = message;
        }

        public void Handle(MyMessage message)
        {
            Message = message.Str;
        }

        public void Publish()
        {
            _eventAggregator.PublishOnUIThread(Message);
        }
        public void OpenOneWin()
        {
            OneViewModel one = new OneViewModel();
            _windowManager.ShowWindow(one);
        }
    }
}
