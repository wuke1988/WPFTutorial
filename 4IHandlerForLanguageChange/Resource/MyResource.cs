using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace _4IHandlerForLanguageChange.Resource
{
    [Export(typeof(IResource))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MyResource : IResource
    {
        //ResourceManager用于从二进制资源文件中检索资源，通常用于语言资源文件的检索
        private ResourceManager _resourceManager;
        private CultureInfo _cultureInfo = new CultureInfo("zh-CN");
        public CultureInfo CultureInfo
        {
            get { return _cultureInfo; }
            set { _cultureInfo = value; }
        }
        public MyResource()
        {
            //ResourceManager构造器 参数一：资源名称（要求包含 命名空间，文件路径名，文件名（不包含语言和后缀名称））
            //参数二：资源所在的程序集
            _resourceManager = new ResourceManager("_4IHandlerForLanguageChange.Resource.MyLanguage", typeof(MyResource).Assembly);
            //对于默认语言资源，不用在资源中加语言后缀
        }
        public string GetString(string name)
        {
            return _resourceManager.GetString(name,_cultureInfo);
        }
    }
}
