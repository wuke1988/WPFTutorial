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

namespace _1DataBinding
{
    /// <summary>
    /// BindProductObject.xaml 的交互逻辑
    /// </summary>
    public partial class BindProductObject : Window
    {
        public BindProductObject()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int productID;
            if (int.TryParse(textBox.Text.ToString().Trim(), out productID))
            {
                Product product =  App.StoreDb.GetProduct(productID);
                this.DataContext = product;
            }
            else
            {
                MessageBox.Show("输入ID必须是数字");
            }            
        }
    }
}
