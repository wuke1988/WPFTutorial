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
    /// DataGridRowDetails.xaml 的交互逻辑
    /// 使用DataGrid.RowDetailsTemplate模板，显示行数据详细信息
    /// </summary>
    public partial class DataGridRowDetails : Window
    {
        public DataGridRowDetails()
        {
            InitializeComponent();
            gridProducts.ItemsSource = App.StoreDb.GetProducts();
        }
    }
}
