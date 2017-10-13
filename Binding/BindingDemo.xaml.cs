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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BindingDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// 目标：1 实现双向绑定示例-slider.value与labell.fontsize（xmal实现和代码实现）
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //SetBindingForLabel();
        }
        /// <summary>
        /// 代码实现双向绑定
        /// </summary>
        private void SetBindingForLabel()
        {
            System.Windows.Data.Binding binding = new System.Windows.Data.Binding();
            binding.Source = sliderFontSize;
            binding.Path = new PropertyPath("Value");
            binding.Mode = BindingMode.TwoWay;
            label1.SetBinding(Label.FontSizeProperty, binding);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            label1.FontSize = 10;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            label1.FontSize = 20;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            label1.FontSize = 30;
        }
    }
}
