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
    /// ValueConverter.xaml 的交互逻辑
    /// </summary>
    public partial class ValueConverter : Window
    {
        private Product product;
        public ValueConverter()
        {
            InitializeComponent();
        }
        private void cmdGetProduct_Click(object sender,RoutedEventArgs e)
        {
            int productID;
            if (int.TryParse(txtID.Text.Trim(), out productID))
                try
                {
                    product = App.StoreDb.GetProduct(productID);
                    gridProductDetails.DataContext = product;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error contacting database.");
                }
            else
            {
                MessageBox.Show("Invalid ID.");
            }
        }
        private void cmdUpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            // Make sure update has taken place.
            FocusManager.SetFocusedElement(this, (Button)sender);

            MessageBox.Show(product.UnitCost.ToString());
        }
    }
}
