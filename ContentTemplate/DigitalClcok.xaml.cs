using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Speech.Synthesis;
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
using System.Windows.Threading;

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
            CommandBinding binding = new CommandBinding(SpeakCommand, (ExecuteSpeak), new CanExecuteRoutedEventHandler(CanExecuteSpeak));
            InputBinding input = new InputBinding(SpeakCommand, new MouseGesture(MouseAction.LeftClick));

            CommandManager.RegisterClassCommandBinding(typeof(DigitalClcok), binding);
            CommandManager.RegisterClassInputBinding(typeof(DigitalClcok), input);

        }
        //static DigitalClcok()
        //{
        //    //CommandBinding binding = new CommandBinding(SpeakCommand,new ExecutedRoutedEventHandler(ExecuteSpeak), new CanExecuteRoutedEventHandler(CanExecuteSpeak));
        //    //InputBinding input = new InputBinding(SpeakCommand, new MouseGesture(MouseAction.LeftClick));

        //    //CommandManager.RegisterClassCommandBinding(typeof(DigitalClcok), binding);
        //    //CommandManager.RegisterClassInputBinding(typeof(DigitalClcok), input);
        //}
        public SpeechSynthesizer speaker => new SpeechSynthesizer();


        #region DP
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

        #endregion

        #region routedEvent
        public static readonly RoutedEvent TimeUpdatedEvent = EventManager.RegisterRoutedEvent("TimeUpdated",RoutingStrategy.Bubble,
            typeof(RoutedPropertyChangedEventHandler<DateTime>),typeof(DigitalClcok));

        public event RoutedPropertyChangedEventHandler<DateTime> TimeUpdated
        {
            add { AddHandler(TimeUpdatedEvent, value); }
            remove { RemoveHandler(TimeUpdatedEvent,value); }
        }

        #endregion


        public readonly static RoutedUICommand SpeakCommand = new RoutedUICommand("Speak", "Speak", typeof(DigitalClcok));


        private  void ExecuteSpeak(object sender, ExecutedRoutedEventArgs e)
        {
            DigitalClcok digital = (DigitalClcok)sender;

            digital.SpeakTheTime(digital.Time);
        }
        private void SpeakTheTime(DateTime Time)
        {
            DateTime time = Time.ToLocalTime();
            string content = "今天是" + time.Date.ToShortDateString() + " " + time.DayOfWeek + " " + time.ToShortTimeString();
            speaker.SpeakAsync(content);
        }
        private  void CanExecuteSpeak(object sender, CanExecuteRoutedEventArgs e)
        {
            DigitalClcok digital = (DigitalClcok)sender;

            if (digital.Time != null)
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }        
    }

    public class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                DateTime datetime = (DateTime)value;
                return datetime.ToLocalTime().DayOfWeek.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class TimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                DateTime datetime = (DateTime)value;
                return datetime.ToLocalTime().TimeOfDay.ToString(@"hh\:mm\:ss");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
