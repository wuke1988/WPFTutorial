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

namespace _3DataView
{
    /// <summary>
    /// GroupList.xaml 的交互逻辑
    /// 基于数据视图view实现简单属性的分组
    /// </summary>
    public partial class GroupList : Window
    {
        private ICollection<Product> products;
        private ListCollectionView view;
        public GroupList()
        {
            InitializeComponent();
        }
        private void cmdGetProducts_Click(object sender, RoutedEventArgs e)
        {
            products = App.StoreDb.GetProducts();
            lstProducts.ItemsSource = products;

            view = (ListCollectionView)CollectionViewSource.GetDefaultView(lstProducts.ItemsSource);
            if (view != null)
            {
                //先对分组进行排序
                view.SortDescriptions.Add(new System.ComponentModel.SortDescription("CategoryName", System.ComponentModel.ListSortDirection.Ascending));
                //再进行组内排序
                view.SortDescriptions.Add(new System.ComponentModel.SortDescription("ModelName", System.ComponentModel.ListSortDirection.Ascending));

                view.GroupDescriptions.Add(new PropertyGroupDescription("CategoryName"));
            }
        }

    }
}
