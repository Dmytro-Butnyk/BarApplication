using DB_Coursework;
using DB_Coursework.Models.Orders;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace BarApplication.ViewModels.SellVM
{
    public class SellerViewModel : ObservableObject
    {
        private readonly BarContext _context = new();
        private List<Order> _orders;
        private Order _selectedOrder;
        private int _tableNumber;
        private DateTime _orderDate;
        private bool _isOpenedOrder;

        public ICommand AddOrderCommand { get; }
        public ICommand CloseOrderCommand { get; }
        public ICommand ShowOpenedCommand { get; }
        public ICommand ShowClosedCommand { get; }
        public SellerViewModel()
        {
            AddOrderCommand = new RelayCommand(async () => await AddOrderAsync());
            CloseOrderCommand = new RelayCommand(async () => await CloseOrder());
            ShowClosedCommand = new RelayCommand(async () => await LoadClosedOrders());
            ShowOpenedCommand = new RelayCommand(async () => await LoadOpenedOrders());
            Task.Run(UpdateOrderDateAsync);
        }

        public List<Order> Orders
        {
            get => _orders;
            set
            {
                _orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }
        public Order SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                _selectedOrder = value;
                OnPropertyChanged(nameof(SelectedOrder));
            }
        }
        public int TableNumber
        {
            get => _tableNumber;
            set
            {
                if (value >= 0)
                {
                    _tableNumber = value;
                    OnPropertyChanged(nameof(TableNumber));
                }
                else
                {
                    MessageBox.Show("Wrong table number!");
                }
            }
        }
        public DateTime OrderDate
        {
            get => _orderDate;
            set
            {
                _orderDate = value;
                OnPropertyChanged(nameof(OrderDate));
            }
        }
        public bool IsOpenedOrder
        {
            get => _isOpenedOrder;
            set
            {
                _isOpenedOrder = value;
                OnPropertyChanged(nameof(IsOpenedOrder));
            }
        }
        private async Task AddOrderAsync()
        {
            if (TableNumber == 0)
            {
                MessageBox.Show("Please, fill the fields!");
                return;
            }

            if (_context.Tables.Any(x => x.Number == TableNumber))
            {
                if (_context.Orders.Any(x => x.Table.Number == TableNumber
                && x.IsOpened == false))
                {
                    MessageBox.Show($"Order with table {TableNumber} is already opened!");
                    return;
                }
                _context.Orders.Add(new Order(OrderDate,
                    _context.Tables.FirstOrDefault(x => x.Number == TableNumber),
                    false));
                _context.SaveChanges();
                await LoadOpenedOrders();
                TableNumber = 0;
            }
            else
                MessageBox.Show("Table is not exists");
        }
        private async Task UpdateOrderDateAsync()
        {
            while (true)
            {
                OrderDate = DateTime.Now;
                await Task.Delay(1000); // Update the date every second
            }
        }

        private async Task CloseOrder()
        {
            if (SelectedOrder == null)
                return;
            if (SelectedOrder.IsOpened == false)
            {
                SelectedOrder.IsOpened = true;
                _context.SaveChanges();
                MessageBox.Show("Order closed!");
                await LoadOpenedOrders();
            }
            else
                MessageBox.Show("Order already closed!");
        }
        private async Task LoadOpenedOrders()
        {
            if (_context.Orders == null)
                return;
            Orders = _context.Orders
                .Where(x => x.IsOpened == false)
                .ToList();
        }
        private async Task LoadClosedOrders()
        {
            if (_context.Orders == null)
                return;
            Orders = _context.Orders
                .Where(x => x.IsOpened == true)
                .ToList();
        }
    }
}
