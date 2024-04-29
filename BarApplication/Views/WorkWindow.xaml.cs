using BarApplication.ViewModels.ManVM;
using BarApplication.ViewModels.SellVM;
using DB_Coursework.Models.Users;
using System.Windows;

namespace BarApplication.Views
{
    /// <summary>
    /// Логика взаимодействия для WorkWindow.xaml
    /// </summary>
    public partial class WorkWindow : Window
    {
        public WorkWindow(User user)
        {
            InitializeComponent();
            if (user.Position == "Manager")
            {
                DataContext = new ManagerViewModel();
                var frame = new ManagerView();
                Content = frame;
            }
            else
            {
                DataContext = new SellerViewModel();
                var frame = new SellerView();
                Content = frame;
            }
        }
    }
}
