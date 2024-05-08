using BarApplication.ViewModels.SellVM.Servises;
using DB_Coursework;
using DB_Coursework.Models.BaseClasses;
using DB_Coursework.Models.Orders;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BarApplication.ViewModels.SellVM
{
    public class SellerOrderDetailsViewModel : ObservableObject
    {
        private readonly BarContext _context = new();
        private double _quantity;
        private ObservableCollection<Order> _openedOrders;
        private Order _selectedOrder;
        private ObservableCollection<Product> _products;
        private Product _selectedProduct;
        private ObservableCollection<OrderDetail> _orderDetails;
        private OrderDetail _selectedOrderDetail;

        public ICommand AddOrderDetail { get; }
        public ICommand DeleteOrderDetail { get; }

        public ICommand GoToOrders { get; }

        public SellerOrderDetailsViewModel(NavigationDataServiceSell ndss)
        {
            GoToOrders = ndss.GoToOrdersCommand;

            AddOrderDetail = new RelayCommand(async () => await AddOrderDetailAsync());
            DeleteOrderDetail = new RelayCommand(async () => await DeleteOrderDetailAsync());
            Task.Run(async () => await LoadDataAsync());
        }

        #region PROPERTIES
        public double Quantity
        {
            get => _quantity;
            set
            {
                if (value >= 0)
                    _quantity = value;
                else
                {
                    MessageBox.Show("Wrong quantity value!");
                    _quantity = 0;
                }
                OnPropertyChanged(nameof(Quantity));
            }
        }
        public ObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }
        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }
        public ObservableCollection<Order> OpenedOrders
        {
            get => _openedOrders;
            set
            {
                _openedOrders = value;
                OnPropertyChanged(nameof(OpenedOrders));
            }
        }
        public Order SelectedOrder
        {
            get => _selectedOrder
                ;
            set
            {
                _selectedOrder = value;
                OnPropertyChanged(nameof(SelectedOrder));
                Task.Run(LoadOrderDetailsAsync);
            }
        }
        public ObservableCollection<OrderDetail> OrderDetails
        {
            get => _orderDetails;
            set
            {
                _orderDetails = value;
                OnPropertyChanged(nameof(OrderDetails));
            }
        }
        public OrderDetail SelectedOrderDetail
        {
            get => _selectedOrderDetail;
            set
            {
                _selectedOrderDetail = value;
                OnPropertyChanged(nameof(SelectedOrderDetail));
            }
        }
        #endregion

        #region METHODS
        private async Task LoadOpenedOrdersAsync()
        {
            try
            {
                var orders = await _context.Orders
                    .Include(o => o.Table)
                    .Where(o => o.IsOpened == false)
                    .ToListAsync();

                OpenedOrders = new ObservableCollection<Order>(orders);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading opened orders: {ex.Message}");
            }
        }
        private async Task LoadProductsAsync()
        {
            try
            {
                var products = await _context.Products
                    .ToListAsync();

                Products = new ObservableCollection<Product>(products);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}");
            }
        }
        private async Task LoadOrderDetailsAsync()
        {
            try
            {
                if (SelectedOrder == null)
                    return;

                var orderDetails = await _context.OrderDetails.Include(od => od.Order)
                    .Where(od => od.Order.Id == SelectedOrder.Id)
                    .ToListAsync();

                OrderDetails = new ObservableCollection<OrderDetail>(orderDetails);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading order details: {ex.Message}");
            }
        }
        private async Task LoadDataAsync()
        {
            await LoadOpenedOrdersAsync();
            await LoadProductsAsync();
            await LoadOrderDetailsAsync();
        }

        private void ClearFields()
        {
            SelectedProduct = null;
            Quantity = 0;
        }

        private async Task AddOrderDetailAsync()
        {
            try
            {
                if (Quantity == 0 || SelectedOrder == null || SelectedProduct == null)
                {
                    MessageBox.Show("Please, fill all fields!");
                    ClearFields();
                    return;
                }

                // Check if there is enough quantity of the selected product
                if (SelectedProduct.Quantity < Quantity)
                {
                    MessageBox.Show("Not enough quantity of the selected product!");
                    return;
                }

                var newOrderDetail = new OrderDetail(SelectedProduct, Quantity, SelectedOrder);
                _context.Products.FirstOrDefault(x => x.Id == newOrderDetail.Product.Id).Quantity -= newOrderDetail.Quantity;
                _context.OrderDetails.Add(newOrderDetail);
                await _context.SaveChangesAsync();
                MessageBox.Show("Order detail added!");
                await LoadDataAsync();
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqlException innerException && (innerException.Number == 50000 || innerException.Number == 50001))
                {
                    MessageBox.Show(innerException.Message);
                }
                else
                {
                    MessageBox.Show("An error occurred while adding the order detail.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the order detail: {ex.Message}");
            }
            finally
            {
                ClearFields();
            }
        }

        private async Task DeleteOrderDetailAsync()
        {
            try
            {
                if (SelectedOrderDetail != null)
                {
                    _context.Products.FirstOrDefault(x => x.Id == SelectedOrderDetail.Product.Id).Quantity += SelectedOrderDetail.Quantity;
                    _context.Remove(SelectedOrderDetail);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    MessageBox.Show("Select order detail to delete!");
                }

                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting order detail: {ex.Message}");
            }
        }
        #endregion
    }
}
