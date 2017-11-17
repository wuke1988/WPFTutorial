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

namespace _4ListViewTreeDataGrid
{
    /// <summary>
    /// CustomListViewTest.xaml 的交互逻辑
    /// </summary>
    public partial class CustomListViewTest : Window
    {
        public CustomListViewTest()
        {
            InitializeComponent();
            lstProducts.ItemsSource = App.StoreDb.GetProducts();
        }

        private void lstView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = lstView.SelectedItem as ComboBoxItem;
            lstProducts.View = (ViewBase)this.FindResource(item.Content);
            
        }
    }
}
