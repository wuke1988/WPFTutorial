using CalculatorContract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelCalculator
{
    public class FuelEconomyUserControlViewmodel : INotifyPropertyChanged
    {
        private List<FuelEconomyType> fuelEcoTypes;
        public List<FuelEconomyType> FuelEcoTypes { get { return fuelEcoTypes; } }

        private FuelEconomyType selectedFuelEconomyType;

        public FuelEconomyType SelectedFuelEconomyType
        {
            get { return selectedFuelEconomyType; }
            set
            {
                selectedFuelEconomyType = value;
                OnPropertyChanged(nameof(SelectedFuelEconomyType));
            }
        }
        private string fuel;
        public string Fuel
        {
            get { return fuel; }
            set
            {
                fuel = value;
                OnPropertyChanged(nameof(Fuel));
            }
        }

        private string distance;
        public string Distance
        {
            get { return distance; }
            set
            {
                distance = value;
                OnPropertyChanged(nameof(Distance));
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

        public event PropertyChangedEventHandler PropertyChanged;

        public FuelEconomyUserControlViewmodel()
        {
            InitializeFuelEcoTypes();
        }
        
        private void InitializeFuelEcoTypes()
        {
            var t1 = new FuelEconomyType()
            {
                Id= "lpk",
                Text = "L/100 km",
                DistanceText = "Distance (kilometers)",
                FuelText = "Fuel used (liters)"
            };
            var t2 = new FuelEconomyType()
            {
                Id = "mpg",
                Text = "Miles per gallon",
                DistanceText = "Distance (miles)",
                FuelText = "Fuel used (gallons)"
            };
            fuelEcoTypes = new List<FuelEconomyType>() { t1, t2 };
        }

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
