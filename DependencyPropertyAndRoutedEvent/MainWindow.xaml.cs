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

namespace DependencyPropertyAndRoutedEvent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void circle_FillChanged(object sender, FillChangedRoutedEventArgs e)
        {

        }

        private void circle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show($@" {sender.ToString()}  Mouse is down!");
            //e.Handled = true;
        }
    }
}
