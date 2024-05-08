using BarApplication.ViewModels.SellVM.Servises;
using DB_Coursework;
using DB_Coursework.Models.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace BarApplication.ViewModels.SellVM
{
    public class SellerViewModel : ObservableObject
    {
        private readonly BarContext _context = new();

        private ObservableCollection<Order> _orders;
        private Order _selectedOrder;
        private ObservableCollection<Table> _tables;
        private Table _selectedTable;
        private DateTime _orderDate;
        private Brush _isOpenedButtonSelected;
        private Brush _isClosedButtonSelected;

        public ICommand AddOrderCommand { get; }
        public ICommand CloseOrderCommand { get; }
        public ICommand ShowOpenedCommand { get; }
        public ICommand ShowClosedCommand { get; }
        public ICommand GoToOrderDetails { get; }

        public SellerViewModel(NavigationDataServiceSell ndss)
        {
            GoToOrderDetails = ndss.GoToOrderDetailCommand;
            AddOrderCommand = new RelayCommand(async () => await AddOrderAsync());
            CloseOrderCommand = new RelayCommand(async () => await CloseOrder());
            ShowClosedCommand = new RelayCommand(async () => await LoadClosedOrders());
            ShowOpenedCommand = new RelayCommand(async () => await LoadOpenedOrders());

            Task.Run(UpdateOrderDateAsync);
            LoadTables(); // Load tables initially
        }

        public ObservableCollection<Order> Orders
        {
            get => _orders;
            set { _orders = value; OnPropertyChanged(nameof(Orders)); }
        }

        public Order SelectedOrder
        {
            get => _selectedOrder;
            set { _selectedOrder = value; OnPropertyChanged(nameof(SelectedOrder)); }
        }

        public ObservableCollection<Table> Tables
        {
            get => _tables;
            set { _tables = value; OnPropertyChanged(nameof(Tables)); }
        }
        public Table SelectedTable
        {
            get => _selectedTable;
            set
            {
                _selectedTable = value;
                OnPropertyChanged(nameof(SelectedTable));
            }
        }
        public DateTime OrderDate
        {
            get => _orderDate;
            set { _orderDate = value; OnPropertyChanged(nameof(OrderDate)); }
        }

        public Brush IsOpenedButtonSelected
        {
            get => _isOpenedButtonSelected;
            set { _isOpenedButtonSelected = value; OnPropertyChanged(nameof(IsOpenedButtonSelected)); }
        }

        public Brush IsClosedButtonSelected
        {
            get => _isClosedButtonSelected;
            set { _isClosedButtonSelected = value; OnPropertyChanged(nameof(IsClosedButtonSelected)); }
        }



        private async Task AddOrderAsync()
        {
            if (SelectedTable == null || SelectedTable.Number == 0)
            {
                MessageBox.Show("Please, select a table!");
                return;
            }

            var tableExists = _context.Tables.Any(x => x.Number == SelectedTable.Number);
            if (!tableExists)
            {
                MessageBox.Show("Selected table does not exist!");
                return;
            }

            var orderExists = _context.Orders.Any(x => x.Table.Number == SelectedTable.Number && !x.IsOpened);
            if (orderExists)
            {
                MessageBox.Show($"Order for table {SelectedTable.Number} is already opened!");
                return;
            }

            var newOrder = new Order(OrderDate, SelectedTable, false);
            _context.Orders.Add(newOrder);
            _context.SaveChanges();
            await LoadOpenedOrders();
            SelectedTable = null; // Reset selected table
        }

        private async Task UpdateOrderDateAsync()
        {
            while (true)
            {
                OrderDate = DateTime.Now;
                await Task.Delay(1000); // Update the date every second
            }
        }

        private async void LoadTables()
        {
            Tables = new ObservableCollection<Table>(await _context.Tables.ToListAsync());
        }

        private async Task CloseOrder()
        {
            if (SelectedOrder == null)
                return;

            if (!SelectedOrder.IsOpened)
            {
                SelectedOrder.IsOpened = true;
                _context.SaveChanges();
                MessageBox.Show("Order closed!");
                await LoadOpenedOrders();
            }
            else
            {
                MessageBox.Show("Order is already closed!");
            }
        }

        private async Task LoadOpenedOrders()
        {
            Orders = new ObservableCollection<Order>(_context.Orders.Where(x => !x.IsOpened).ToList());
            UpdateButtonColors(Colors.Aqua, Colors.White);
        }

        private async Task LoadClosedOrders()
        {
            Orders = new ObservableCollection<Order>(_context.Orders.Where(x => x.IsOpened).ToList());
            UpdateButtonColors(Colors.White, Colors.Aqua);
        }

        private void UpdateButtonColors(Color openedColor, Color closedColor)
        {
            IsOpenedButtonSelected = new SolidColorBrush(openedColor);
            IsClosedButtonSelected = new SolidColorBrush(closedColor);
        }
    }
}
