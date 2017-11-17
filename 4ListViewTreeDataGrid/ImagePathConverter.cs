using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace _4ListViewTreeDataGrid
{
    public class ImagePathConverter : IValueConverter
    {
        private string imageDirectory = Directory.GetCurrentDirectory();
        public string ImageDirectory
        {
            get { return imageDirectory; }
            set
            {
                imageDirectory = value;
            }
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string uri =Path.Combine(imageDirectory, value.ToString());
            return new BitmapImage(new Uri(uri));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
