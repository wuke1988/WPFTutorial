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
using System.Windows.Shapes;

namespace Command
{
    /// <summary>
    /// Window2.xaml 的交互逻辑
    /// 自定义命令Demo
    /// </summary>
    public partial class Window2 : Window
    {
        private bool IsDirty = false;
        public Window2()
        {
            InitializeComponent();
        }
        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show($"New Command triggered by {e.Source.ToString()}");
        }

        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show($"Open Command triggered by {e.Source.ToString()}");
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show($"Save Command triggered by {e.Source.ToString()}");
            IsDirty = false;
        }
        private void SaveCommand_CanExecuted(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = IsDirty;
        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsDirty = true;
        }

        private void RequeryCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show($"Requery Command triggered by {e.Source.ToString()}");
        }
    }
}
