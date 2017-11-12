﻿using _0StoreDatabase;
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
    /// DataTemplateImages.xaml 的交互逻辑
    /// </summary>
    public partial class DataTemplateImages : Window
    {
        public DataTemplateImages()
        {
            InitializeComponent();
        }
        private ICollection<Product> products;
        private void cmdGetProducts_Click(object sender, RoutedEventArgs e)
        {
            products = App.StoreDb.GetProducts();
            lstProducts.ItemsSource = products;
        }
    }
}
