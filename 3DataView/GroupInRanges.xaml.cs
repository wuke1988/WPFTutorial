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
    /// GroupInRanges.xaml 的交互逻辑
    /// 基于数据视图view实现自定义分组条件
    /// 两种实现方式：1. 用代码实现；2. 用配置实现；
    /// </summary>
    public partial class GroupInRanges : Window
    {
        private ICollection<Product> products;
        private ListCollectionView view;

        public GroupInRanges()
        {
            InitializeComponent();
        }
        private void cmdGetProducts_Click(object sender, RoutedEventArgs e)
        {
            products = App.StoreDb.GetProducts();
            //lstProducts.ItemsSource = products;

            var viewsource = this.FindResource("GroupByRangeView") as CollectionViewSource;
            viewsource.Source = products;
            //代码设置分组
            //view = (ListCollectionView)CollectionViewSource.GetDefaultView(lstProducts.ItemsSource);
            //if (view != null)
            //{
            //    //先对分组进行排序
            //    view.SortDescriptions.Add(new System.ComponentModel.SortDescription("UnitCost", System.ComponentModel.ListSortDirection.Ascending));

            //    PriceRangeProductGrouper grouper = new PriceRangeProductGrouper();
            //    grouper.GroupInterval = 50;

            //    view.GroupDescriptions.Add(new PropertyGroupDescription("UnitCost",grouper));
            //}
        }
    }
    
}
