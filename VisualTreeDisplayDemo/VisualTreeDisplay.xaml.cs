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

namespace VisualTreeDisplayDemo
{
    /// <summary>
    /// VisualTreeDisplay.xaml 的交互逻辑
    /// </summary>
    public partial class VisualTreeDisplay : Window
    {
        public VisualTreeDisplay()
        {
            InitializeComponent();
        }

        public void ShowVisualTree(DependencyObject dependencyObject)
        {
            ProcessElement(dependencyObject,null);
        }
        /// <summary>
        /// 获取当前元素的信息，并分别递归当前元素的嵌套子元素信息（深度优先）
        /// @element 当前元素
        /// @previousItem 之前的元素（父元素）
        /// </summary>
        /// <param name="element"></param>
        /// <param name="previousItem"></param>
        private void ProcessElement(DependencyObject element, TreeViewItem previousItem)
        {
            TreeViewItem item = new TreeViewItem();
            item.Header = element.GetType().Name;
            item.IsExpanded = true;

            //检查当前元素是否为顶层元素
            //如果是 将item直接加入到TreeView控件中
            //如果不是 将item加入到previousItem的Items中
            if (previousItem == null)
            {
                treeElements.Items.Add(item);
            }
            else
            {
                previousItem.Items.Add(item);
            }

            //检查当前元素是否含有子元素，如果有 递归
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
            {
               ProcessElement(VisualTreeHelper.GetChild(element,i), item);
            }
        }
    }
}
