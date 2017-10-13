using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ApplicationDemo
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// 目标：1 实践操作Appliction的常见事件
    /// </summary>
    public partial class App : Application
    {
        //用来模拟程序有未保存的数据，由此判断程序是否可以关闭
        private bool unsavedData;
        public bool UnsavedData
        {
            get;set;
        }
       

        /// <summary>
        /// 引发Startup事件
        /// Startup事件 发生在Application.Run方法之后，并在主窗口显示之前
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            unsavedData = true;
        }
        /// <summary>
        /// 引发SessionEnding事件
        /// SessionEnding事件发生在Windows对话结束时（如：用户注销或关闭计算机）
        /// 可通过SessionEndingCancelEventArgs.Cancel为true来取消关闭应用程序
        /// 否则 当事件处理结束时，WPF将调用Application.shutdown方法
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSessionEnding(SessionEndingCancelEventArgs e)
        {
            base.OnSessionEnding(e);
            if (unsavedData)
            {
                e.Cancel = true;
                MessageBox.Show($@"The application attempted to be closed as a result
of {e.ReasonSessionEnding.ToString()}.This is not allowed,as you have unsaved data.");
            }
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {

        }
        /// <summary>
        /// 可通过事件Application_Startup，来获取启动参数
        /// 字符串数组 StartupEventArgs.Args 为 启动参数列表、
        /// Startup事件 发生在Application.Run方法之后，并在主窗口显示之前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MessageBox.Show("Startup");
        }
    }
}
