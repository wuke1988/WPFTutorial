using CalculatorContract;
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
using WCalculator.ViewModel;

namespace WCalculator
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private CalculatorViewModel viewModel = new CalculatorViewModel();
        private CalculatorManager containerManager;
        private IOperation currentOperation;
        private double[] currentOperands;

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = viewModel;
            containerManager = new CalculatorManager(viewModel);
            containerManager.InitializeContainer();
        }
        private void Button_Click(object sender,EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                currentOperation = button.Tag as IOperation;
                currentOperands = new double[currentOperation.NumberOperands];
                currentOperands[0] = double.Parse(viewModel.Input);
                viewModel.Input += $" {currentOperation.Name} ";
            }
        }
        private void OnNumberButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = e.OriginalSource as Button;
            viewModel.Input += button.Content.ToString();
        }

        private void CalculatorButtonClick(object sender, RoutedEventArgs e)
        {
            if (currentOperands.Length == 2)
            {
                var inputs = viewModel.Input.Split(' ');
                currentOperands[1] = double.Parse(inputs[2]);
                containerManager.InvokeCalculator(currentOperation,currentOperands);
            }
        }
    }
}
