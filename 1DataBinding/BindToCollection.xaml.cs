using _0StoreDatabase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace _1DataBinding
{
    /// <summary>
    /// BindToCollection.xaml 的交互逻辑
    /// </summary>
    public partial class BindToCollection : Window
    {
        private ICollection<Product> products;
        public BindToCollection()
        {
            InitializeComponent();          
        }
        private void GetProductList()
        {
            products = App.StoreDb.GetProducts();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GetProductList();
            listBox1.ItemsSource = products;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //因为products本身为ObservableCollection类型,故当发生更改时绑定的界面会自动刷新
            Product product = listBox1.SelectedItem as Product;
            products.Remove(product);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            products.Add(new Product(txtModelNumber.Text, txtModelName.Text, decimal.Parse(txtUnitCost.Text), txtDescription.Text));
        }
    }
}
