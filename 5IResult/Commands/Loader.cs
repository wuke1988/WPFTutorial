using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _5IResult.Commands
{
    public class Loader : IResult
    {
        private string _str;
        public Loader(string str)
        {
            _str = str;
        }
        public event EventHandler<ResultCompletionEventArgs> Completed =
            (sender,args)=> MessageBox.Show(((Loader)sender)._str);
     

        public void Execute(CoroutineExecutionContext context)
        {
            MessageBox.Show(_str+context.View);
            Completed(this, new ResultCompletionEventArgs());
        }
    }
}
