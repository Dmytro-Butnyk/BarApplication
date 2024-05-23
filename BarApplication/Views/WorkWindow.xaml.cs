using BarApplication.ViewModels.ManVM;
using BarApplication.ViewModels.SellVM;
using BarApplication.ViewModels.SellVM.Servises;
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
            NavigationDataServiceMan nbvm = new(this, user);
            NavigationDataServiceSell ndss = new(this);

            if (user.Position == "Manager")
            {
                var frame = new ManagerView(nbvm);
                Content = frame;
            }
            else
            {
                var frame = new SellerView(ndss);
                Content = frame;
            }
            Application.Current.MainWindow.Close();
        }
    }
}
