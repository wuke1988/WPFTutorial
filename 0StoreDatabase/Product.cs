using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0StoreDatabase
{
    public class Product : INotifyPropertyChanged,INotifyDataErrorInfo
    {
        private string modelNumber;
        public string ModelNumber
        {
            get { return modelNumber; }
            set
            {
                modelNumber = value;

                bool valid = true;
                foreach (char c in modelNumber)
                {
                    if (!Char.IsLetterOrDigit(c))
                    {
                        valid = false;
                        break;
                    }
                }
                if (!valid)
                {
                    List<String> error = new List<String>();
                    error.Add("ModelNumber Can only contain letters and numbers");
                    SetErrors("ModelNumber", error);
                }
                else
                {
                    ClearErrors("ModelNumber");
                }

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
                if (value < 0)
                    throw new ArgumentException("UnitCost can not be negative.");
                else
                {
                    unitCost = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("UnitCost"));
                }
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
        #region 实现INotifyDataErrorInfo接口
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        private Dictionary<string, List<String>> errors = new Dictionary<string, List<string>>();

        public bool HasErrors
        {
            get
            {
                return errors.Count>0;
            }
        }

        public IEnumerable GetErrors(string propertyName)
        {
            if (!string.IsNullOrEmpty(propertyName))
                return errors.Values;
            else
            {
                if (errors.ContainsKey(propertyName))
                    return errors[propertyName];
            }
            return null;
        }
        private void SetErrors(string propertyName,List<String> error)
        {
            errors.Remove(propertyName);
           
            errors.Add(propertyName, error);
            
            ErrorsChanged?.Invoke(this,new DataErrorsChangedEventArgs(propertyName));
        }
        private void ClearErrors(string propertyName)
        {
            if (errors.ContainsKey(propertyName))
                errors.Remove(propertyName);
        }

        #endregion
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
