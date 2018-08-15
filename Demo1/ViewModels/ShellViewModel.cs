using Caliburn.Micro;
using Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BootstrapperAndConvention.ViewModels
{
    [Export(typeof(IShell))]
    public class ShellViewModel:PropertyChangedBase,IShell
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange(nameof(Name));
                NotifyOfPropertyChange(() => CanSayHello);
            }                
        }
        /// <summary>
        /// 命名规则，自动关联到名为SayHello的Button对应的Enable属性上
        /// </summary>
        public bool CanSayHello
        {
            get { return !string.IsNullOrEmpty(Name); }
        }
        /// <summary>
        /// 命名规则，自动关联到名为SayHello的Button的click事件
        /// </summary>
        public void SayHello()
        {
            MessageBox.Show($"Hello {Name}!");
        }
    }
}
