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
    /// DataGridEditing.xaml 的交互逻辑
    /// 实现DataGrid的编辑功能
    /// 对特殊的列（数据列）进行编辑校验功能
    /// 主要使用binding.ValidationRules属性
    /// </summary>
    public partial class DataGridEditing : Window
    {
        public DataGridEditing()
        {
            InitializeComponent();
            categoryColumn.ItemsSource = App.StoreDb.GetCategories();
            gridProducts.ItemsSource = App.StoreDb.GetProducts();          
        }
    }
}
