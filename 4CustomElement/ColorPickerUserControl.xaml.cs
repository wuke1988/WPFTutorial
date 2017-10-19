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

namespace _4CustomElement
{
    /// <summary>
    /// UserControl.xaml 的交互逻辑
    /// </summary>
    public partial class ColorPickerUserControl : UserControl
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

        static ColorPickerUserControl()
        {
            ColorProperty = DependencyProperty.Register("Color", typeof(Color), typeof(ColorPickerUserControl),
                new PropertyMetadata(Colors.Black, new PropertyChangedCallback(OnColorChanged)));

            RedProperty = DependencyProperty.Register("Red", typeof(byte), typeof(ColorPickerUserControl),
                new PropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));

            BlueProperty = DependencyProperty.Register("Blue", typeof(byte), typeof(ColorPickerUserControl),
                new PropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));

            GreenProperty = DependencyProperty.Register("Green", typeof(byte), typeof(ColorPickerUserControl),
                new PropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));

            ColorChangedEvent = EventManager.RegisterRoutedEvent("ColorChanged", RoutingStrategy.Bubble,
                typeof(RoutedPropertyChangedEventHandler<Color>), typeof(ColorPickerUserControl));
        }

        public ColorPickerUserControl()
        {
            InitializeComponent();
        }

        private static void OnColorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ColorPickerUserControl colorPicker = (ColorPickerUserControl)sender;
            colorPicker.Color = (Color)e.NewValue;

            colorPicker.Red = ((Color)e.NewValue).R;
            colorPicker.Green = ((Color)e.NewValue).G;
            colorPicker.Blue = ((Color)e.NewValue).B;

            RoutedPropertyChangedEventArgs<Color> arg =
                new RoutedPropertyChangedEventArgs<Color>((Color)e.OldValue, colorPicker.Color);
            arg.RoutedEvent = ColorChangedEvent;

            colorPicker.RaiseEvent(arg);
        }

        private static void OnColorRGBChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ColorPickerUserControl colorPicker = (ColorPickerUserControl)sender;
            Color color = colorPicker.Color;

            if (e.Property == RedProperty)
                color.R = (byte)e.NewValue;
            if (e.Property == BlueProperty)
                color.B = (byte)e.NewValue;
            if (e.Property == GreenProperty)
                color.G = (byte)e.NewValue;

            colorPicker.Color = color;
        }

    }
}
