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

namespace CustomContentTemplate
{
    /// <summary>
    /// ListBoxDemo.xaml 的交互逻辑
    /// </summary>
    public partial class ListBoxDemo : Window
    {
        public ListBoxDemo()
        {
            InitializeComponent();
        }

        private void listBox_Loaded(object sender, RoutedEventArgs e)
        {
            listBox.ItemsSource = new List<String> {"One","Two","Three","Four","Five","Six","Seven","Eight","Nine","Ten" };
        }
    }
}
