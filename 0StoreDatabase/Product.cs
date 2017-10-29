using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0StoreDatabase
{
    public class Product : INotifyPropertyChanged
    {
        private string modelNumber;
        public string ModelNumber
        {
            get { return modelNumber; }
            set
            {
                modelNumber = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(ModelNumber)));
            }
        }
        private string modelName;
        public string ModelName
        {
            get { return modelName; }
            set
            {
                modelName = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ModelName"));
            }
        }

        private decimal unitCost;
        public decimal UnitCost
        {
            get { return unitCost; }
            set
            {
                unitCost = value;
                OnPropertyChanged(new PropertyChangedEventArgs("UnitCost"));
            }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Description"));
            }
        }

        private string categoryName;
        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; }
        }

        // For DataGridComboBoxColumn example.
        private int categoryID;
        public int CategoryID
        {
            get { return categoryID; }
            set { categoryID = value; }
        }

        private string productImagePath;
        public string ProductImagePath
        {
            get { return productImagePath; }
            set { productImagePath = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if(PropertyChanged!=null)
                PropertyChanged.Invoke(this,e);
        }

        // This for testing date editing. The value isn't actually stored in the database.
        private DateTime dateAdded = DateTime.Today;
        public DateTime DateAdded
        {
            get { return dateAdded; }
            set { dateAdded = value; }
        }

        /// <summary>
        /// 构造函数1
        /// </summary>
        /// <param name="modelNumber"></param>
        /// <param name="modelName"></param>
        /// <param name="unitCost"></param>
        /// <param name="description"></param>
        public Product(string modelNumber, string modelName,
            decimal unitCost, string description)
        {
            ModelNumber = modelNumber;
            ModelName = modelName;
            UnitCost = unitCost;
            Description = description;
        }

        /// <summary>
        /// 构造函数2
        /// </summary>
        /// <param name="modelNumber"></param>
        /// <param name="modelName"></param>
        /// <param name="unitCost"></param>
        /// <param name="description"></param>
        /// <param name="productImagePath"></param>
        public Product(string modelNumber, string modelName,
        decimal unitCost, string description,
        string productImagePath)
         :
        this(modelNumber, modelName, unitCost, description)
        {
            ProductImagePath = productImagePath;
        }

        /// <summary>
        /// 构造函数3
        /// </summary>
        /// <param name="modelNumber"></param>
        /// <param name="modelName"></param>
        /// <param name="unitCost"></param>
        /// <param name="description"></param>
        /// <param name="categoryID"></param>
        /// <param name="categoryName"></param>
        /// <param name="productImagePath"></param>
        public Product(string modelNumber, string modelName,
           decimal unitCost, string description, int categoryID,
           string categoryName, string productImagePath) :
           this(modelNumber, modelName, unitCost, description)
        {
            CategoryName = categoryName;
            ProductImagePath = productImagePath;
            CategoryID = categoryID;
        }

        public override string ToString()
        {
            return ModelName + " (" + ModelNumber + ")";
        }
    }
}
