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
    /// EditProductObject.xaml 的交互逻辑
    /// </summary>
    public partial class EditProductObject : Window
    {
        private Product product;
        public EditProductObject()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int productID;
            if (int.TryParse(textBox.Text.ToString().Trim(), out productID))
            {
                product = App.StoreDb.GetProduct(productID);
                this.DataContext = product;
            }
            else
            {
                MessageBox.Show("输入ID必须是数字");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            product.UnitCost *= 1.1M;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string message;
            if (!FormHasErrors(out message))
                MessageBox.Show(product.UnitCost.ToString());
            else
                MessageBox.Show(message);
        }
        private bool FormHasErrors(out string message)
        {
            StringBuilder builder = new StringBuilder();
            bool hasError = false;
            GetError(builder, gridProductDetail);
            message = builder.ToString();
            hasError = String.IsNullOrEmpty(message.Trim()) ? false : true;
            return hasError;
            
        }
        //递归实现检查子控件树是否有校验错误
        private void GetError(StringBuilder builder,DependencyObject obj)
        {
            foreach (var element in LogicalTreeHelper.GetChildren(obj))
            {
                TextBox textBox = element as TextBox;
                if (textBox != null)
                {
                    if (Validation.GetHasError(textBox))
                    {
                        builder.Append($"{textBox.Text} Errors:");
                        foreach (ValidationError error in Validation.GetErrors(textBox))
                        {
                            builder.Append(error.ErrorContent.ToString());
                            builder.Append("\r\n");
                        }
                    }
                }
                GetError(builder,textBox);

            }
        }
        /// <summary>
        /// 响应验证错误，提示错误详细内容信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtModelNumber_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                //因Product继承INotifyDataErrorInfo接口，e.Error.ErrorContent返回实际为调用GetError返回List<String>
                //所以要加强制转换
                MessageBox.Show((e.Error.ErrorContent as List<string>)[0].ToString());
            }
        }
        /// <summary>
        /// 响应验证错误，提示错误详细信息
        /// （两种提示详细信息的方法：1种 在ErrorTemplate中显示；1种 通过引发附加属性Validation.Error事件来显示）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                MessageBox.Show(e.Error.ErrorContent.ToString());
            }
        }
    }   
}
