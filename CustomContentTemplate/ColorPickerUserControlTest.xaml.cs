using _4CustomElement;
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

namespace CustomContentTemplate
{
    /// <summary>
    /// CustomElement1.xaml 的交互逻辑
    /// </summary>
    public partial class ColorPickerUserControlTest : Window
    {

        public ColorPickerUserControlTest()
        {
            InitializeComponent();
            
        }

        private void colorPicker_ColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {
            if(txtBlock!=null)
                 this.txtBlock.Text = $"the new color is {e.NewValue.ToString()}";
        }
    }
}
