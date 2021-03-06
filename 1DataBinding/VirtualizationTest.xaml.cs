﻿using System;
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
    /// VirtualizationTest.xaml 的交互逻辑
    /// </summary>
    public partial class VirtualizationTest : Window
    {
        public VirtualizationTest()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10000; i++)
            {
                lstFast.Items.Add(i.ToString());
                lstSlow.Items.Add(i.ToString());
                listBox.Items.Add(i.ToString());
            }
        }
    }
}
