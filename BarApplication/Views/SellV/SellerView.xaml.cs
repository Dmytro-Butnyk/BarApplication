using BarApplication.ViewModels;
using BarApplication.ViewModels.SellVM;
using BarApplication.ViewModels.SellVM.Servises;
using System.IO.Packaging;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace BarApplication.Views
{
    /// <summary>
    /// Логика взаимодействия для SellerView.xaml
    /// </summary>
    public partial class SellerView : Page
    {
        public SellerView(NavigationDataServiceSell ndss)
        {
            InitializeComponent();
            DataContext = new SellerViewModel(ndss);
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
