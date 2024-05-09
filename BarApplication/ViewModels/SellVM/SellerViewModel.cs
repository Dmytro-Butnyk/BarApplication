using BarApplication.ViewModels.SellVM.Servises;
using DB_Coursework;
using DB_Coursework.Models.Orders;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace BarApplication.ViewModels.SellVM
{
    public class SellerViewModel : ObservableObject
    {
        private readonly BarContext _context;
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
            _context = new BarContext();
            GoToOrderDetails = ndss.GoToOrderDetailCommand;
            AddOrderCommand = new RelayCommand(async () => await AddOrderAsync());
            CloseOrderCommand = new RelayCommand(async () => await CloseOrderAsync());
            ShowClosedCommand = new RelayCommand(async () => await LoadOrdersAsync(false));
            ShowOpenedCommand = new RelayCommand(async () => await LoadOrdersAsync(true));
            LoadTablesAsync(); // Load tables initially
            UpdateOrderDateAsync();
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

            var tableExists = await _context.Tables.AnyAsync(x => x.Number == SelectedTable.Number);
            if (!tableExists)
            {
                MessageBox.Show("Selected table does not exist!");
                return;
            }

            var orderExists = await _context.Orders.AnyAsync(x => x.Table.Number == SelectedTable.Number && !x.IsOpened);
            if (orderExists)
            {
                MessageBox.Show($"Order for table {SelectedTable.Number} is already opened!");
                return;
            }

            var newOrder = new Order(OrderDate, SelectedTable, false);
            _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();
            await LoadOrdersAsync(true);
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

        private async Task LoadTablesAsync()
        {
            Tables = new ObservableCollection<Table>(await _context.Tables.ToListAsync());
        }

        private async Task CloseOrderAsync()
        {
            if (SelectedOrder == null)
                return;

            if (SelectedOrder.IsOpened)
            {
                MessageBox.Show("Order is already closed!");
                return;
            }

            SelectedOrder.IsOpened = true;
            await _context.SaveChangesAsync();
            MessageBox.Show("Order closed!");
            await LoadOrdersAsync(true);
        }

        private async Task LoadOrdersAsync(bool isOpened)
        {
            Orders = new ObservableCollection<Order>(await _context.Orders.Where(x => x.IsOpened == !isOpened).ToListAsync());
            UpdateButtonColors(!isOpened ? Colors.White : Colors.Aqua, !isOpened ? Colors.Aqua : Colors.White);
        }

        private void UpdateButtonColors(Color openedColor, Color closedColor)
        {
            IsOpenedButtonSelected = new SolidColorBrush(openedColor);
            IsClosedButtonSelected = new SolidColorBrush(closedColor);
        }
    }
}