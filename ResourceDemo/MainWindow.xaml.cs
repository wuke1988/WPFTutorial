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

namespace ResourceDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// 实践动态资源和静态资源的区别
    /// 实践使用系统资源的方法（xaml）
    /// 实践使用资源字典的方法（xaml）
    /// 实践使用其它项目的资源的方法 ComponentResourceKey（xaml）
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //对于动态资源，每次在需要对象时 都会从资源集合中查找对象，而静态资源则只加载一次对象
            //this.Resources["TileBrush"] = new SolidColorBrush(Colors.LightBlue);

            //静态资源 加载的对象发生变化时，也会自动更新；
            ImageBrush brush = (ImageBrush)this.Resources["TileBrush"];
            brush.Viewbox = new Rect(0,0,5,5);



        }
    }
}
