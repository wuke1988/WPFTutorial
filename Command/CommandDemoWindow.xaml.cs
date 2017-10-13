using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Command
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// 实现最简单的命令绑定功能：两种方式（xaml绑定和后台绑定）
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //后台绑定
            //CommandBinding binding = new CommandBinding(ApplicationCommands.New);
            //binding.Executed += NewCommand_Executed;

            //this.CommandBindings.Add(binding);
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show($"New Command triggered by {e.Source.ToString()}");
        }
    }
}
