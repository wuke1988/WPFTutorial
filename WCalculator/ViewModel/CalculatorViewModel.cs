using CalculatorContract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCalculator.ViewModel
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string input;
        public string Input
        {
            get { return input; }
            set
            {
                input = value;
                OnPropertyChanged(nameof(Input));
            }
        }
        private string result;
        public string Result
        {
            get { return result; }
            set
            {
                result = value;
                OnPropertyChanged(nameof(Result));
            }
        }

        private ObservableCollection<IOperation> calcAddInOperators = new ObservableCollection<IOperation>();
        public ObservableCollection<IOperation> CalcAddInOperators
        {
            get { return calcAddInOperators; }
        }

        private readonly ObservableCollection<Lazy<ICalculatorExtension>> calcExtensions = new ObservableCollection<Lazy<ICalculatorExtension>>();
        public ObservableCollection<Lazy<ICalculatorExtension>> CalcExtensions
        {
            get
            {
                return calcExtensions;
            }
        }

        private readonly ObservableCollection<Lazy<ICalculatorExtension>> activatedExtensions = new ObservableCollection<Lazy<ICalculatorExtension>>();
        public ObservableCollection<Lazy<ICalculatorExtension>> ActivatedExtensions
        {
            get
            {
                return activatedExtensions;
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
