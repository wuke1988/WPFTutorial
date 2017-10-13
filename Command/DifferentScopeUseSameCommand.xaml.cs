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
    /// DifferentScopeUseSameCommand.xaml 的交互逻辑
    /// </summary>
    public partial class DifferentScopeUseSameCommand : Window
    {
        public DifferentScopeUseSameCommand()
        {
            InitializeComponent();
        }
        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show($"Save Command triggered by {((Control)sender).Name.ToString()}");
        }
    }
}
