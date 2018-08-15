using Caliburn.Micro;
using Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _2Actions.ViewModels
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
                NotifyOfPropertyChange(() => CanMyClick);
            }
        }
        /// <summary>
        /// 命名规则：自动对应到绑定到MyClick处理方法的Button的Enable属性上，实现按钮是否有效
        /// </summary>
        public bool CanMyClick
        {
            get { return !string.IsNullOrEmpty(Name); }
        }
        public void MyClick(object sender,string str)
        {
            MessageBox.Show($"{sender.ToString()}    {str}");
        }
        public void MyClick()
        {
            MessageBox.Show("No Params");
        }
    }
}
