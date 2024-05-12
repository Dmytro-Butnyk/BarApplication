using BarApplication.ViewModels;
using BarApplication.ViewModels.ManVM;
using System.Windows;
using System.Windows.Controls;

namespace BarApplication.Views
{
    /// <summary>
    /// Логика взаимодействия для ManagerView.xaml
    /// </summary>
    public partial class ManagerView : Page
    {
        public ManagerView(NavigationDataServiceMan nbvm)
        {
            InitializeComponent();
            DataContext = new ManagerViewModel(nbvm);
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
