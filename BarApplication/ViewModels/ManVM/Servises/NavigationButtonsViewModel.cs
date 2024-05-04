using BarApplication.Views;
using DB_Coursework.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BarApplication.ViewModels.ManVM
{
    public class NavigationDataService : ObservableObject
    {
        private WorkWindow _workWindow;
        private User _activeUser;
        public ICommand GoToSuppliesPageCommand { get; }
        public ICommand GoToProductsPageCommand { get; }
        public ICommand GoToUsersPageCommand { get; }

        public NavigationDataService(WorkWindow workWindow, User activeUser)
        {
            _workWindow = workWindow;
            _activeUser = activeUser;
            GoToSuppliesPageCommand = new RelayCommand(SuppliesNavigation);
            GoToProductsPageCommand = new RelayCommand(ProductsNavigation);
            GoToUsersPageCommand = new RelayCommand(UsersNavigation);
        }
        public User ActiveUser
        {
            get => _activeUser;
            set
            {
                _activeUser = value;
                OnPropertyChanged(nameof(ActiveUser));
            }
        }

        private async void SuppliesNavigation()
        {
            _workWindow.Content = new ManagerSuppliesView(this);
        }
        private void ProductsNavigation()
        {
            _workWindow.Content = new ManagerView(this);
        }

        private void UsersNavigation()
        {
            _workWindow.Content = new ManagerUsersView(this);
        }
    }
}
