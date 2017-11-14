using _0StoreDatabase;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// FilterDataSet.xaml 的交互逻辑
    /// 实现源自DataTable的view上进行Filter过滤
    /// </summary>
    public partial class FilterDataSet : Window
    {
        private DataTable products;
        private BindingListCollectionView view;
        public FilterDataSet()
        {
            InitializeComponent();
        }
        private void cmdGetProducts_Click(object sender, RoutedEventArgs e)
        {
            products = App.StoreDbDataSet.GetProducts();
            lstProducts.ItemsSource = products.DefaultView;

            view = CollectionViewSource.GetDefaultView(lstProducts.ItemsSource) as BindingListCollectionView;
            view.SortDescriptions.Add(new System.ComponentModel.SortDescription("ModelName", System.ComponentModel.ListSortDirection.Ascending));
        }
        private void cmdFilter_Click(object sender, RoutedEventArgs e)
        {
            decimal minimumPrice;
            if (Decimal.TryParse(txtMinPrice.Text, out minimumPrice))
            {
                view = CollectionViewSource.GetDefaultView(lstProducts.ItemsSource) as BindingListCollectionView;
                if (view != null)
                {
                    view.CustomFilter = "UnitCost > " + minimumPrice.ToString();
                }
            }
        }
        private void cmdRemoveFilter_Click(object sender, RoutedEventArgs e)
        {
            view = CollectionViewSource.GetDefaultView(lstProducts.ItemsSource) as BindingListCollectionView;
            if (view != null)
            {
                view.Filter = null;
            }
        }
    }
}
