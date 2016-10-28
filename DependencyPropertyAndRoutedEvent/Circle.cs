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

        public event EventHandler<FillChangedRoutedEventArgs> FillChanged
        {
            add { AddHandler(FillChangedEvent,value); }
            remove { RemoveHandler(FillChangedEvent, value); }
        }


        public static readonly DependencyProperty FillProperty = DependencyProperty.Register("FillProperty",typeof(Brush),typeof(Circle),
            new FrameworkPropertyMetadata(Brushes.Red,FrameworkPropertyMetadataOptions.AffectsRender,OnFillPropertyChanged));

        public static readonly RoutedEvent FillChangedEvent = EventManager.RegisterRoutedEvent("FillChanged", RoutingStrategy.Bubble,
            typeof(EventHandler<FillChangedRoutedEventArgs>), typeof(Circle));

        private static void OnFillPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((UIElement)d).RaiseEvent(new FillChangedRoutedEventArgs((Brush)e.NewValue)
            {
                Source = d,
                RoutedEvent = FillChangedEvent               
            });                
        }
    }
}
