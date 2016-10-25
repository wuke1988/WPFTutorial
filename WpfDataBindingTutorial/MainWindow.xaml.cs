using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WpfDataBindingTutorial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ICollectionView dataview = CollectionViewSource.GetDefaultView(lv.ItemsSource);                    
            //dataview.Filter += new FilterEventHandler(ShowOnlyBargainsFilter);                      
            //dataview.Filter += new Predicate<object>(YearPredicate);
            PropertyGroupDescription description = new PropertyGroupDescription("Year");

            dataview.GroupDescriptions.Add(description);


        }
        private bool YearPredicate( object obj)
        {
            DateTime date = (DateTime)obj;
            if (date.Year > 2000)
                return true;
            return false;
        }
        private void ShowOnlyBargainsFilter(object sender, FilterEventArgs e)
        {
            DateTime date = (DateTime)e.Item ;
            if (date.Year > 2000)
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }

        GridViewColumnHeader _lastHeaderClicked = null;
        ListSortDirection _lastDirection = ListSortDirection.Ascending;

        public void GridViewColumnHeaderClickedHandler(object sender, RoutedEventArgs e)
        {


            ListSortDirection direction;
            GridViewColumnHeader _headerClicked = e.OriginalSource as GridViewColumnHeader;

            if (_headerClicked != null)
            {
                if (_headerClicked.Role != GridViewColumnHeaderRole.Padding)
                {
                    if (_headerClicked != _lastHeaderClicked)
                    {
                        direction = ListSortDirection.Ascending;
                    }
                    else
                    {
                        if (_lastDirection == ListSortDirection.Ascending)
                        {
                            direction = ListSortDirection.Descending;
                        }
                        else
                        {
                            direction = ListSortDirection.Ascending;
                        }
                    }
                    string header = _headerClicked.Column.Header as string;
                    Sort(header, direction);


                    if (direction == ListSortDirection.Ascending)
                    {
                        _headerClicked.Column.HeaderTemplate =
                          Resources["HeaderTemplateArrowUp"] as DataTemplate;
                    }
                    else
                    {
                        _headerClicked.Column.HeaderTemplate =
                          Resources["HeaderTemplateArrowDown"] as DataTemplate;
                    }
                    _lastHeaderClicked = _headerClicked;
                    _lastDirection = direction;

                }
            }



            //if (direction == ListSortDirection.Ascending)
            //{
            //    headerClicked.Column.HeaderTemplate =
            //      Resources["HeaderTemplateArrowUp"] as DataTemplate;
            //}
            //else
            //{
            //    headerClicked.Column.HeaderTemplate =
            //      Resources["HeaderTemplateArrowDown"] as DataTemplate;
            //}

            //// Remove arrow from previously sorted header
            //if (_lastHeaderClicked != null && _lastHeaderClicked != headerClicked)
            //{
            //    _lastHeaderClicked.Column.HeaderTemplate = null;
            //}


            //_lastHeaderClicked = headerClicked;
            //_lastDirection = direction;



        }

        private void Sort(string SortBy,ListSortDirection direction)
        {
            ICollectionView dataview = CollectionViewSource.GetDefaultView(lv.ItemsSource);
            dataview.SortDescriptions.Clear();

            dataview.SortDescriptions.Add(new SortDescription(SortBy,direction));
            dataview.Refresh();

        }

    }
}
