using _5IResult.Commands;
using Caliburn.Micro;
using Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5IResult.ViewModels
{
    [Export(typeof(IShell))]
    public class MyViewModel:IShell
    {
        public IEnumerable<IResult> MyIResultClick()
        {
            yield return new Loader("Loading......");
            yield return new Loader("OK!");
        }
    }
}
