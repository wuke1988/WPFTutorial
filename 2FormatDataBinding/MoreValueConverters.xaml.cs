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
    /// MoreValueConverters.xaml 的交互逻辑
    /// </summary>
    public partial class MoreValueConverters : Window
    {
        public MoreValueConverters()
        {
            InitializeComponent();
        }
        private void cmdGetProducts_Click(object sender, RoutedEventArgs e)
        {
            var products = App.StoreDb.GetProducts();
            lstProducts.ItemsSource = products;
        }
    }
}
