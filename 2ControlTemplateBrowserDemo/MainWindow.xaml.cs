using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace _2ControlTemplateBrowserDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Type controlType = typeof(Control);

            List<Type> derivedTypes = new List<Type>();

            //检索（control）程序集中所有的类型
            //将Control的子类型放入列表
            Assembly assembly = Assembly.GetAssembly(typeof(Control));
            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsSubclassOf(controlType) && type.IsPublic && !type.IsAbstract)
                {
                    derivedTypes.Add(type);
                }
            }
            derivedTypes.Sort(new TypeComparer());

            this.listBox.ItemsSource = derivedTypes;
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.listBox.SelectedItem != null)
            {
                try
                {
                    //第一步：通过反射 创建出Control对象，从而读取模板内容
                    Type type = (Type)this.listBox.SelectedItem;
                    ConstructorInfo info = type.GetConstructor(System.Type.EmptyTypes);

                    Control control = (Control)info.Invoke(null);
                    //可将控件显示改为Collapsed
                    control.Visibility = Visibility.Collapsed;
                    grid.Children.Add(control);

                    ControlTemplate template = control.Template;

                    //第二步：将读取的模板对象转换为XAML标记

                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;

                    StringBuilder stringBuilder = new StringBuilder();
                    XmlWriter xmlWriter = XmlWriter.Create(stringBuilder, settings);
                    //通过XamlWriter.Save 方法将 模板对象作为Source转给xmlWriter对象，xmlWriter输出即为序列化后的对象
                    XamlWriter.Save(template, xmlWriter);

                    scrollViewer.Content = stringBuilder.ToString();

                    grid.Children.Remove(control);
                }
                catch (Exception ex)
                {
                    scrollViewer.Content = $"<< Error generate template :{ex.Message} >>";
                }
            }
        }
    }

    //实现类型 Type 比较器
    public class TypeComparer : IComparer<Type>
    {
        public int Compare(Type x, Type y)
        {
           return x.Name.CompareTo(y.Name);
        }
    }

}
