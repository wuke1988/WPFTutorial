using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _4CustomElement
{
    /// <summary>
    /// 按照步骤 1a 或 1b 操作，然后执行步骤 2 以在 XAML 文件中使用此自定义控件。
    ///
    /// 步骤 1a) 在当前项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根 
    /// 元素中: 
    ///
    ///     xmlns:MyNamespace="clr-namespace:_4CustomElement"
    ///
    ///
    /// 步骤 1b) 在其他项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根 
    /// 元素中: 
    ///
    ///     xmlns:MyNamespace="clr-namespace:_4CustomElement;assembly=_4CustomElement"
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
    ///     <MyNamespace:ColorPicker/>
    ///
    /// </summary>
    [TemplatePart(Name = "PART_RedSlider", Type =typeof(RangeBase))]
    [TemplatePart(Name = "PART_BlueSlider", Type = typeof(RangeBase))]
    [TemplatePart(Name = "PART_GreenSlider", Type = typeof(RangeBase))]
    [TemplatePart(Name = "PART_PreviewBrush", Type = typeof(FrameworkElement))]
    public class ColorPicker : Control
    {
        public static DependencyProperty ColorProperty;

        public Color Color
        {
            set { SetValue(ColorProperty, value); }
            get { return (Color)GetValue(ColorProperty); }
        }

        public static DependencyProperty RedProperty;

        public byte Red
        {
            set { SetValue(RedProperty, value); }
            get { return (byte)GetValue(RedProperty); }
        }

        public static DependencyProperty BlueProperty;

        public byte Blue
        {
            set { SetValue(BlueProperty, value); }
            get { return (byte)GetValue(BlueProperty); }
        }

        public static DependencyProperty GreenProperty;

        public byte Green
        {
            set { SetValue(GreenProperty, value); }
            get { return (byte)GetValue(GreenProperty); }
        }

        public static readonly RoutedEvent ColorChangedEvent;

        public event RoutedPropertyChangedEventHandler<Color> ColorChanged
        {
            add { AddHandler(ColorChangedEvent, value); }
            remove { RemoveHandler(ColorChangedEvent, value); }
        }

        private static Color? previousColor;

        static ColorPicker()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorPicker), new FrameworkPropertyMetadata(typeof(ColorPicker)));

            ColorProperty = DependencyProperty.Register("Color", typeof(Color), typeof(ColorPicker),
                new PropertyMetadata(Colors.Black, new PropertyChangedCallback(OnColorChanged)));

            RedProperty = DependencyProperty.Register("Red", typeof(byte), typeof(ColorPicker),
                new PropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));

            BlueProperty = DependencyProperty.Register("Blue", typeof(byte), typeof(ColorPicker),
                new PropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));

            GreenProperty = DependencyProperty.Register("Green", typeof(byte), typeof(ColorPicker),
                new PropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));

            ColorChangedEvent = EventManager.RegisterRoutedEvent("ColorChanged", RoutingStrategy.Bubble,
                typeof(RoutedPropertyChangedEventHandler<Color>), typeof(ColorPicker));
        }
        private static void OnColorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ColorPicker colorPicker = (ColorPicker)sender;
            colorPicker.Color = (Color)e.NewValue;

            colorPicker.Red = ((Color)e.NewValue).R;
            colorPicker.Green = ((Color)e.NewValue).G;
            colorPicker.Blue = ((Color)e.NewValue).B;

            RoutedPropertyChangedEventArgs<Color> arg =
                new RoutedPropertyChangedEventArgs<Color>((Color)e.OldValue, colorPicker.Color);
            arg.RoutedEvent = ColorChangedEvent;

            previousColor = (Color?)e.OldValue ?? null;

            colorPicker.RaiseEvent(arg);
        }

        private static void OnColorRGBChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ColorPicker colorPicker = (ColorPicker)sender;
            Color color = colorPicker.Color;

            if (e.Property == RedProperty)
                color.R = (byte)e.NewValue;
            if (e.Property == BlueProperty)
                color.B = (byte)e.NewValue;
            if (e.Property == GreenProperty)
                color.G = (byte)e.NewValue;

            colorPicker.Color = color;
        }
        /// <summary>
        /// 在此方法内可以在模板内查找元素(使用GetTemplateChild())并关联事件或添加数据绑定表达式
        /// </summary>
        //public override void OnApplyTemplate()
        //{
        //    base.OnApplyTemplate();

        //    //手工设置控件绑定
        //    RangeBase slider = GetTemplateChild("PART_RedSlider") as RangeBase;
        //    if (slider != null)
        //    {
        //        Binding binding = new Binding("Red");
        //        binding.Source = this;
        //        binding.Mode = BindingMode.TwoWay;

        //        slider.SetBinding(RangeBase.ValueProperty,binding);
        //    }
        //}

    }
}
