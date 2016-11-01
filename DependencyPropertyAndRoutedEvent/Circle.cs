using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace DependencyPropertyAndRoutedEvent
{

    public class FillChangedRoutedEventArgs : RoutedEventArgs
    {
        public Brush Fill { get; set; }
        public FillChangedRoutedEventArgs(Brush fill)
        {
            this.Fill = fill;
        }
    }
    public  class Circle:FrameworkElement
    {
        public Brush Fill
        {
            get { return (Brush)GetValue(FillProperty); }
            set { SetValue(FillProperty, value); }
        }
        public static readonly DependencyProperty FillProperty = DependencyProperty.Register("FillProperty", typeof(Brush), typeof(Circle),
            new FrameworkPropertyMetadata(Brushes.Red, FrameworkPropertyMetadataOptions.AffectsRender, OnFillPropertyChanged));

        private static void OnFillPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((UIElement)d).RaiseEvent(new FillChangedRoutedEventArgs((Brush)e.NewValue)
            {
                Source = d,
                RoutedEvent = FillChangedEvent
            });
        }



        public event EventHandler<FillChangedRoutedEventArgs> FillChanged
        {
            add { AddHandler(FillChangedEvent,value); }
            remove { RemoveHandler(FillChangedEvent, value); }
        }
        public static readonly RoutedEvent FillChangedEvent = EventManager.RegisterRoutedEvent("FillChanged", RoutingStrategy.Bubble,
            typeof(EventHandler<FillChangedRoutedEventArgs>), typeof(Circle));


        public double Thickness
        {
            set { SetValue(ThicknessProperty, value); }
            get { return (double)GetValue(ThicknessProperty); }
        }
        public static readonly DependencyProperty ThicknessProperty = DependencyProperty.Register("ThicknessProperty",typeof(Circle),
            new FrameworkPropertyMetadata(1.0,FrameworkPropertyMetadataOptions.AffectsRender,null, coerceValueCallBack),validateValueCallback);

        public static object coerceValueCallBack(DependencyObject d, object baseValue)
        {
            int value = (int)baseValue;
            if (value > 0)
                return Math.Min(value, 2);
            return baseValue;
        }
        public static object validateValueCallback(DependencyObject d, object baseValue)
        {

        }

    protected override void OnRender(DrawingContext drawingContext)
        {
            var radius = Math.Min(ActualWidth, ActualHeight) / 2;
            drawingContext.DrawEllipse(Fill,new Pen(), new Point(ActualWidth / 2, ActualHeight / 2),radius,radius);
        }
    }
}
