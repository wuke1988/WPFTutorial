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

namespace ContentTemplate
{
    /// <summary>
    /// 按照步骤 1a 或 1b 操作，然后执行步骤 2 以在 XAML 文件中使用此自定义控件。
    ///
    /// 步骤 1a) 在当前项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根 
    /// 元素中: 
    ///
    ///     xmlns:MyNamespace="clr-namespace:ContentTemplate"
    ///
    ///
    /// 步骤 1b) 在其他项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根 
    /// 元素中: 
    ///
    ///     xmlns:MyNamespace="clr-namespace:ContentTemplate;assembly=ContentTemplate"
    ///
    /// 您还需要添加一个从 XAML 文件所在的项目到此项目的项目引用，
    /// 并重新生成以避免编译错误: 
    ///
    ///     在解决方案资源管理器中右击目标项目，然后依次单击
    ///     “添加引用”->“项目”->[浏览查找并选择此项目]
    ///
    ///
    /// 步骤 2)
    /// 继续操作并在 XAML 文件中使用控件。
    ///
    ///     <MyNamespace:Clock1/>
    ///
    /// </summary>
    [TemplatePart(Name ="PART_HourTransform",Type =typeof(RotateTransform))]
    [TemplatePart(Name = "PART_MinuteTransform", Type = typeof(RotateTransform))]
    [TemplatePart(Name = "PART_SecondTransform", Type = typeof(RotateTransform))]
    public class Clock1 : Control
    {
        public static DependencyProperty TimeProperty = DependencyProperty.Register("Time",typeof(TimeSpan),typeof(Clock1),
            new PropertyMetadata(TimeSpan.Zero, OnTimePropertyChanged));
        public static DependencyProperty HourNeedleBrushProperty = DependencyProperty.Register("HourNeedleBrush",typeof(Brush),typeof(Clock1),
            new PropertyMetadata(Brushes.Black));
        public TimeSpan time
        {
            get {return (TimeSpan)GetValue(TimeProperty); }
            set { SetValue(TimeProperty,value); }
        }
        public Brush HourNeedleBrush
        {
            get { return (Brush)GetValue(HourNeedleBrushProperty); }
            set { SetValue(HourNeedleBrushProperty,value); }
        }


        static Clock1()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Clock1), new FrameworkPropertyMetadata(typeof(Clock1)));
        }
        private static void OnTimePropertyChanged(DependencyObject d ,DependencyPropertyChangedEventArgs e)
        {
            ((Clock1)d).UpdateNeedles((TimeSpan)e.NewValue);
        }
        public override void OnApplyTemplate()
        {
            _hour = (RotateTransform)Template.FindName("PART_HourTransform", this);
            _minute = (RotateTransform)Template.FindName("PART_MinuteTransform",this);
            _second = (RotateTransform)Template.FindName("PART_SecondTransform",this);

            UpdateNeedles(time);
            base.OnApplyTemplate();
        }

        private RotateTransform _hour, _minute, _second;

        private void UpdateNeedles(TimeSpan time)
        {
            if (_hour != null)
                _hour.Angle = time.Hours / 12.0 *360;
            if (_minute != null)
                _minute.Angle = time.Minutes / 60.0 * 360;
            if (_second != null)
                _second.Angle = time.Seconds / 60.0 * 360;   
        }
    }
}
