using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.ApplicationServices;

namespace SingleInstanceApplicationDemo
{
    public class SingleInstanceApplicationWrapper:
        Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase
    {
        public SingleInstanceApplicationWrapper()
        {
            this.IsSingleInstance = true;
        }
        private App app;

        protected override bool OnStartup(StartupEventArgs eventArgs)
        {

            app = new App();
            app.Run();

            return false;
        }
        /// <summary>
        /// 存在问题：二次程序无法启动，不能测试是不是可以进入该函数
        /// </summary>
        /// <param name="eventArgs"></param>
        protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
        {
            if (eventArgs.CommandLine.Count > 0)
            {
                app.ShowDocument(eventArgs.CommandLine[0]);
            }
        }
    }
}
