﻿using System;
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
    /// DigitalClcok.xaml 的交互逻辑
    /// </summary>
    public partial class DigitalClcok : UserControl
    {
        public DigitalClcok()
        {
            InitializeComponent();
        }


        public static readonly DependencyProperty TimeProperty = DependencyProperty.Register("Time",typeof(DateTime),typeof(DigitalClcok),
            new PropertyMetadata(DateTime.Now,new PropertyChangedCallback(TimePropertyChanged)));

        public DateTime Time
        {
            get { return (DateTime)GetValue(TimeProperty); }
            set { SetValue(TimeProperty,value); }
        }
        private static void TimePropertyChanged(DependencyObject d,DependencyPropertyChangedEventArgs args)
        {
            RoutedPropertyChangedEventArgs<DateTime> eventargs 
                = new RoutedPropertyChangedEventArgs<DateTime>((DateTime)args.OldValue, (DateTime)args.NewValue);
            ((DigitalClcok)d).RaiseEvent(new RoutedPropertyChangedEventArgs<DateTime>((DateTime)args.OldValue, (DateTime)args.NewValue)
            {
                RoutedEvent = TimeUpdatedEvent,
                Source = d
            });
        }

        public static readonly RoutedEvent TimeUpdatedEvent = EventManager.RegisterRoutedEvent("TimeUpdated",RoutingStrategy.Bubble,
            typeof(RoutedPropertyChangedEventHandler<DateTime>),typeof(DigitalClcok));

        public event RoutedPropertyChangedEventHandler<DateTime> TimeUpdated
        {
            add { AddHandler(TimeUpdatedEvent, value); }
            remove { RemoveHandler(TimeUpdatedEvent,value); }
        }


    }
}