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
            NavigationDataService nbvm = new NavigationDataService(this, user);
            if (user.Position == "Manager")
            {
                var frame = new ManagerView(nbvm);
                Content = frame;
            }
            else
            {
                var frame = new SellerView();
                Content = frame;
            }

        }
    }
}
