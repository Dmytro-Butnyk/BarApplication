using BarApplication.ViewModels;
using BarApplication.ViewModels.ManVM;
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

namespace BarApplication.Views
{
    /// <summary>
    /// Логика взаимодействия для ManagerSuppliesView.xaml
    /// </summary>
    public partial class ManagerSuppliesView : Page
    {
        public ManagerSuppliesView(NavigationDataServiceMan nbvm)
        {
            InitializeComponent();
            DataContext = new ManagerSuppliesViewModel(nbvm);
        }
        public void Open_Grid(object sender, RoutedEventArgs e)
        {
            Animatic.SetElement(DropDownMenu);
            Animatic.Show(55, 220, 0.4f);

            OpenB.Visibility = Visibility.Hidden;
            HideB.Visibility = Visibility.Visible;
        }
        public void Hide_Grid(object sender, RoutedEventArgs e)
        {
            Animatic.Show(220, 55, 0.2f);

            OpenB.Visibility = Visibility.Visible;
            HideB.Visibility = Visibility.Hidden;
        }
    }
}
