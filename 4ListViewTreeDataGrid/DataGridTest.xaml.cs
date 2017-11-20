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

namespace _4ListViewTreeDataGrid
{
    /// <summary>
    /// DataGridTest.xaml 的交互逻辑
    /// 1. 实现自定义的DataGrid控件：text列，下拉框列，自定义模板列
    /// 2. 使用事件：gridProducts_LoadingRow（加载行的事件）根据数值更改行样式
    /// </summary>
    public partial class DataGridTest : Window
    {
        public DataGridTest()
        {
            InitializeComponent();
            gridProducts.ItemsSource = App.StoreDb.GetProducts();
        }

        private SolidColorBrush highlightBrush=new SolidColorBrush(Colors.Orange);
        private SolidColorBrush normalBrush = new SolidColorBrush(Colors.White);

        private void gridProducts_LoadingRow(object sender, DataGridRowEventArgs e)
        {
           Product product =  e.Row.DataContext as Product;
            if (product.UnitCost > 100)
                e.Row.Background = highlightBrush;
            else
                e.Row.Background = normalBrush;
        }
    }
}
