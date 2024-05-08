using DB_Coursework;
using DB_Coursework.Models.BaseClasses;
using DB_Coursework.Models.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BarApplication.ViewModels.ManVM
{
    public class ManagerSuppliesViewModel : ObservableObject
    {
        private readonly BarContext _context = new();
        private List<Product> _products;
        private List<Supply> _supplies;
        private Product _selectedProduct;
        private double _quantity;
        private DateTime _supplyDate;

        public ICommand AddSupplyCommand { get; }

        public ICommand GoToProductsCommand { get; }
        public ICommand GoToUsersCommand { get; }

        public ManagerSuppliesViewModel(NavigationDataServiceMan nbvm)
        {
            GoToProductsCommand = nbvm.GoToProductsPageCommand;
            GoToUsersCommand = nbvm.GoToUsersPageCommand;
            Task.Run(() => UpdateSupplyDateAsync());
            LoadSupplies();
            LoadProducts();
            AddSupplyCommand = new RelayCommand(AddSupply);
        }

        public List<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }
        public List<Supply> Supplies
        {
            get => _supplies;
            set
            {
                _supplies = value;
                OnPropertyChanged(nameof(Supplies));
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
        public double Quantity
        {
            get => _quantity;
            set
            {
                if (value >= 0)
                {
                    _quantity = value;
                    OnPropertyChanged(nameof(Quantity));
                }
                else
                {
                    MessageBox.Show("Wrong quantity value!");
                }
            }
        }
        public DateTime SupplyDate
        {
            get => _supplyDate;
            set
            {
                _supplyDate = value;
                OnPropertyChanged(nameof(SupplyDate));
            }
        }

        private async Task UpdateSupplyDateAsync()
        {
            while (true)
            {
                SupplyDate = DateTime.Now;
                await Task.Delay(1000); // Update the date every second
            }
        }

        private void LoadProducts()
        {
            Products = _context.Products.ToList();
        }
        private void LoadSupplies()
        {
            Supplies = _context.Supplies.OrderByDescending(s => s.SupplyTime).Take(100).ToList();
        }

        private async void AddSupply()
        {
            if (SelectedProduct != null && Quantity != 0)
            {
                var supply = new Supply(_context.Products.FirstOrDefault(x => x.Id == SelectedProduct.Id), Quantity, SupplyDate);

                _context.Supplies.Add(supply);

                try
                {
                    await _context.SaveChangesAsync();
                    LoadSupplies();
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show("Could not save changes: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please check values!");
            }
            EreaseAddFields();
        }
        private void EreaseAddFields()
        {
            SelectedProduct = null;
            Quantity = 0;
        }
    }
}
