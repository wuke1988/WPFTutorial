using _0StoreDatabase;
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

namespace _2FormatDataBinding
{
    /// <summary>
    /// StylesSelector.xaml 的交互逻辑
    /// </summary>
    public partial class StylesSelector : Window
    {
        public StylesSelector()
        {
            InitializeComponent();
        }
        private ICollection<Product> products;
        private void cmdGetProducts_Click(object sender, RoutedEventArgs e)
        {
            products = App.StoreDb.GetProducts();
            lstProducts.ItemsSource = products;
        }
        /// <summary>
        /// 业务功能：实现更新所选项的CategoryName属性
        /// 并通过强制刷新方式来更新ItemContainerStyleSelector
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdApplyChange_Click(object sender, RoutedEventArgs e)
        {
            Product product = lstProducts.SelectedItem as Product;
            product.CategoryName = "Travel";

            StyleSelector styleSelector= lstProducts.ItemContainerStyleSelector;
            lstProducts.ItemContainerStyleSelector = null;
            lstProducts.ItemContainerStyleSelector = styleSelector;
        }
    }
}
