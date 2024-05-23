using BarApplication.Views;
using BarApplication.Views.SellV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace BarApplication.ViewModels.SellVM.Servises
{
    public class NavigationDataServiceSell : ObservableObject
    {
        private WorkWindow _workWindow;
        
        public ICommand GoToOrdersCommand { get; }
        public ICommand GoToOrderDetailCommand { get; }
        public ICommand GoToAuthorizationWindowCommand { get; }

        public NavigationDataServiceSell(WorkWindow workWindow)
        {
            _workWindow = workWindow;
            GoToOrdersCommand = new RelayCommand(OrdersNavigation);
            GoToOrderDetailCommand = new RelayCommand(OrderDetailsNavigation);
            GoToAuthorizationWindowCommand = new RelayCommand(AuthorizationNavigation);
        }
        private async void OrdersNavigation()
        {
            _workWindow.Content = new SellerView(this);
        }
        private async void OrderDetailsNavigation()
        {
            _workWindow.Content = new SellerOrderDetailsView(this);
        }
        private void AuthorizationNavigation()
        {
            new MainWindow().Show();
            _workWindow.Content = new();
            _workWindow.Close();
        }
    }
}
