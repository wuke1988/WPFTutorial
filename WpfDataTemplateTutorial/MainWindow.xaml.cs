using SDKSample;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfDataTemplateTutorial
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            LoadData();
            InitializeComponent();
        }
        public ObservableCollection<MyTask> MyTaskCollections
        {
            set;
            get;
        }

        //public List<MyTask> MyTasks
        //{
        //    set { SetValue(MyTasksProperty, value); }
        //    get { return (List<MyTask>)GetValue(MyTasksProperty); }
        //}
        //public static readonly DependencyProperty MyTasksProperty = DependencyProperty.Register("MyTasks", typeof(List<MyTask>),typeof(MainWindow));

        public void LoadData()
        {
            MyTaskCollections = new ObservableCollection<MyTask>();
            MyTaskCollections.Add(new MyTask { TaskName="Shopping", Description="Pick up Groceries and Detergent", Priority=3, TaskType=TASKType.Home});
            MyTaskCollections.Add(new MyTask { TaskName="Email",Description="Email client", Priority=2, TaskType = TASKType.Work});
            MyTaskCollections.Add(new MyTask { TaskName="Code",Description="Complete my code Task", Priority=1, TaskType = TASKType.Work});
            MyTaskCollections.Add(new MyTask { TaskName="Dinner",Description="Dinner with family", Priority=2,TaskType= TASKType.Home});

        } 
    }
}
