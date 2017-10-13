using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Command
{
    /// <summary>
    /// 自定义命令
    /// </summary>
    public class DataCommands
    {
        private static RoutedUICommand requery;

        static DataCommands()
        {
            //创建命令
            InputGestureCollection inputs = new InputGestureCollection();
            inputs.Add(new KeyGesture(Key.R, ModifierKeys.Control, "Ctrl-R"));
            requery = new RoutedUICommand("Requery", "Requery", typeof(DataCommands), inputs);
        }

        public static RoutedUICommand Requery
        {
            get
            {
                return requery;
            }
        }
    }
}
