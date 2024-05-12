using BarApplication.ViewModels;
using BarApplication.ViewModels.SellVM;
using BarApplication.ViewModels.SellVM.Servises;
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

namespace BarApplication.Views.SellV
{
    /// <summary>
    /// Логика взаимодействия для SellerOrderDetailsViewModel.xaml
    /// </summary>
    public partial class SellerOrderDetailsView : Page
    {
        public SellerOrderDetailsView(NavigationDataServiceSell ndss)
        {
            InitializeComponent();
            DataContext = new SellerOrderDetailsViewModel(ndss);
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
