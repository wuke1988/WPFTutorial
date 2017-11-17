using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _4ListViewTreeDataGrid
{
    public class TileView:ViewBase
    {
        
        public DataTemplate ItemTemplate
        {
            get;set;
        }
        private Brush selectedBackground = Brushes.Transparent;
        public Brush SelectedBackground
        {
            get { return selectedBackground; }
            set { selectedBackground = value; }
        }

        private Brush selectedBorderBrush = Brushes.Black;
        public Brush SelectedBorderBrush
        {
            get { return selectedBorderBrush; }
            set { selectedBorderBrush = value; }
        }

        protected override object DefaultStyleKey
        {
            get { return new ComponentResourceKey(GetType(), "TileView"); }
        }
        protected override object ItemContainerDefaultStyleKey
        {
            get { return new ComponentResourceKey(GetType(), "TileViewItem"); }
        }
    }
}
