using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace _4ListViewTreeDataGrid
{
    /// <summary>
    /// Menu.xaml 的交互逻辑
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }
        private void ButtonClick(object sender,RoutedEventArgs e)
        {
            Button button = e.Source as Button;
            Type type = this.GetType();
            Assembly assembly = Assembly.GetExecutingAssembly();

            Window window = assembly.CreateInstance($"{type.Namespace}." + button.Content.ToString()) as Window;
            window.Show();
        }
    }
}
