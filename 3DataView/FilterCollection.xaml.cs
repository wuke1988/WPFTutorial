using _0StoreDatabase;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// FilterCollection.xaml 的交互逻辑
    /// 实现源自集合的view上进行Filter过滤
    /// </summary>
    public partial class FilterCollection : Window
    {
        private ICollection<Product> products;
        private ListCollectionView view;
        private ProductByPriceFilterer filter;

        public FilterCollection()
        {
            InitializeComponent();
           
        }

        private void cmdGetProducts_Click(object sender, RoutedEventArgs e)
        {
            products = App.StoreDb.GetProducts();
            lstProducts.ItemsSource = products;

            ICollectionView view1 = CollectionViewSource.GetDefaultView(lstProducts.ItemsSource);

            view1.SortDescriptions.Add(new SortDescription("ModelName", ListSortDirection.Ascending));

            view = CollectionViewSource.GetDefaultView(lstProducts.ItemsSource) as ListCollectionView;
            //此时设置IsLiveFiltering = true 指示设置的值是否进行实时过滤
            //view.IsLiveFiltering = true;
            //view.LiveFilteringProperties.Add("UnitCost");

            view.IsLiveGrouping = true;
            view.LiveGroupingProperties.Add("CategoryName");

            //可使用自定义的比较方法（需实现IComparer接口）
            view.CustomSort = new SortByModelNameLength();
        }

        private void cmdRemoveFilter_Click(object sender, RoutedEventArgs e)
        {
            view = CollectionViewSource.GetDefaultView(lstProducts.ItemsSource) as ListCollectionView;
            if (view != null)
            {
                view.Filter = null;
            }
        }
        private void cmdFilter_Click(object sender, RoutedEventArgs e)
        {
            decimal minimumPrice;
            if (decimal.TryParse(txtMinPrice.Text, out minimumPrice))
            {
                view = CollectionViewSource.GetDefaultView(lstProducts.ItemsSource) as ListCollectionView;
                if (view != null)
                {
                    filter = new ProductByPriceFilterer(minimumPrice);
                    view.Filter = filter.FilterItem;
                    //view.Refresh();
                }
            }
        }
        private void txtMinPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListCollectionView view = CollectionViewSource.GetDefaultView(lstProducts.ItemsSource) as ListCollectionView;
            if (view != null)
            {
                decimal minimumPrice;
                if (Decimal.TryParse(txtMinPrice.Text, out minimumPrice) && (filter != null))
                {
                    filter.MinimumPrice = minimumPrice;
                    //view.Refresh();
                }
            }
        }

    }
    public class ProductByPriceFilterer
    {
        public decimal MinimumPrice
        { get; set; }

        public ProductByPriceFilterer(decimal minimumPrice)
        {
            MinimumPrice = minimumPrice;
        }

        public bool FilterItem(object item)
        {
            Product product = item as Product;
            if (product != null)
            {
                return product.UnitCost > MinimumPrice;
            }
            return false;
        }

    }
    public class SortByModelNameLength : IComparer
    {
        int IComparer.Compare(object x, object y)
        {
            Product productX = (Product)x;
            Product productY = (Product)y;
            return productX.ModelName.Length.CompareTo(productY.ModelName.Length);
        }
    }
}
