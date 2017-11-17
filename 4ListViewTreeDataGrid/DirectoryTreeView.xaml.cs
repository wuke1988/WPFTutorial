using System;
using System.Collections.Generic;
using System.IO;
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

namespace _4ListViewTreeDataGrid
{
    /// <summary>
    /// DirectoryTreeView.xaml 的交互逻辑
    /// </summary>
    public partial class DirectoryTreeView : Window
    {
        public DirectoryTreeView()
        {
            InitializeComponent();

            InitialTreeViewItemSource();
        }
        private void InitialTreeViewItemSource()
        {
            foreach (DriveInfo info in DriveInfo.GetDrives())
            {
                TreeViewItem item = new TreeViewItem();
                item.Tag = info;
                item.Header = info.ToString();

                //添加占位符
                item.Items.Add("*");

                treeFileSystem.Items.Add(item);
            }
        }

        private void treeFileSystem_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = e.OriginalSource as TreeViewItem;
            //此处先清空所有子项目
            item.Items.Clear();

            DirectoryInfo currentDir;
            if (item.Tag is DriveInfo)
            {
                DriveInfo info = item.Tag as DriveInfo;
                currentDir = info.RootDirectory;              
            }
            else
            {
                currentDir = item.Tag as DirectoryInfo;
            }
            //检索该项的子目录
            foreach (DirectoryInfo subDir in currentDir.GetDirectories())
            {
                TreeViewItem subItem = new TreeViewItem();
                subItem.Tag = subDir;
                subItem.Header = subDir.ToString();
                subItem.Items.Add("*");

                item.Items.Add(subItem);
            }
        }
    }
}
