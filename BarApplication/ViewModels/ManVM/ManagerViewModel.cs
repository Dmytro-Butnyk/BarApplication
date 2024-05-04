using DB_Coursework;
using DB_Coursework.Models.BaseClasses;
using DB_Coursework.Models.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace BarApplication.ViewModels.ManVM
{
    public class ManagerViewModel : ObservableObject
    {
        private readonly BarContext _context = new();

        private Visibility _isVisibleAdditionPoles = Visibility.Collapsed;
        private Visibility _isVisibleProducts = Visibility.Collapsed;
        private Visibility _isVisibleAlcoholDrinks = Visibility.Collapsed;
        private Visibility _isVisibleSnacks = Visibility.Collapsed;

        private string _labelProductType;
        private string[] _pRegistration = new string[3];
        private string _productType;
        private Product _selectedProduct;

        private List<Product> _products;
        private List<AlcoholDrink> _alcoholDrinks;
        private List<Snack> _snacks;

        public ICommand DeleteProductButton { get; }
        public ICommand AddDrinkButton { get; }
        public ICommand AddSnackButton { get; }
        public ICommand AddProductButton { get; }
        public ICommand ShowProductsButton { get; }
        public ICommand ShowAlcoholDrinksButton { get; }
        public ICommand ShowSnacksButton { get; }
        public ICommand GoToSuppliesCommand { get; }
        public ICommand GoToUsersCommand { get; }

        public ManagerViewModel(NavigationDataService nbvm)
        {
            GoToSuppliesCommand = nbvm.GoToSuppliesPageCommand;
            GoToUsersCommand = nbvm.GoToUsersPageCommand;

            DeleteProductButton = new RelayCommand(async () => await DeleteProductCommandAsync());
            AddProductButton = new RelayCommand(AddProduct);
            AddDrinkButton = new RelayCommand(() => SetProductType("Drink", "ABV:"));
            AddSnackButton = new RelayCommand(() => SetProductType("Snack", "Snack type:"));

            ShowProductsButton = new RelayCommand(async () => await ShowCategoryAsync(LoadProducts, "Products"));
            ShowAlcoholDrinksButton = new RelayCommand(async () => await ShowCategoryAsync(LoadAlcoholDrinks, "AlcoholDrinks"));
            ShowSnacksButton = new RelayCommand(async () => await ShowCategoryAsync(LoadSnacks, "Snacks"));
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
        public List<AlcoholDrink> AlcoholDrinks
        {
            get => _alcoholDrinks;
            set
            {
                _alcoholDrinks = value;
                OnPropertyChanged(nameof(AlcoholDrinks));
            }
        }
        public List<Snack> Snacks
        {
            get => _snacks;
            set
            {
                _snacks = value;
                OnPropertyChanged(nameof(Snacks));
            }
        }

        public Product SelectedProduct
        {
            get => _selectedProduct;
            set { _selectedProduct = value; OnPropertyChanged(nameof(SelectedProduct)); }
        }

        public string ProductName
        {
            get => _pRegistration[0];
            set { _pRegistration[0] = value; OnPropertyChanged(nameof(ProductName)); }
        }

        public string ProductPrice
        {
            get => _pRegistration[1];
            set
            {
                if (decimal.TryParse(value, out decimal price) && price > 0)
                    _pRegistration[1] = value;
                else
                    MessageBox.Show("Invalid price format");
                OnPropertyChanged(nameof(ProductPrice));
            }
        }

        public string ProductSpecialization
        {
            get => _pRegistration[2];
            set { _pRegistration[2] = value; OnPropertyChanged(nameof(ProductSpecialization)); }
        }

        public string ProductType
        {
            get => _productType;
            set { _productType = value; OnPropertyChanged(nameof(ProductType)); }
        }

        public Visibility IsVisibleAdditionPoles
        {
            get => _isVisibleAdditionPoles;
            set { _isVisibleAdditionPoles = value; OnPropertyChanged(nameof(IsVisibleAdditionPoles)); }
        }

        public Visibility IsVisibleProducts
        {
            get => _isVisibleProducts;
            set { _isVisibleProducts = value; OnPropertyChanged(nameof(IsVisibleProducts)); }
        }

        public Visibility IsVisibleAlcoholDrinks
        {
            get => _isVisibleAlcoholDrinks;
            set { _isVisibleAlcoholDrinks = value; OnPropertyChanged(nameof(IsVisibleAlcoholDrinks)); }
        }

        public Visibility IsVisibleSnacks
        {
            get => _isVisibleSnacks;
            set { _isVisibleSnacks = value; OnPropertyChanged(nameof(IsVisibleSnacks)); }
        }

        public string LabelProductType
        {
            get => _labelProductType;
            set { _labelProductType = value; OnPropertyChanged(nameof(LabelProductType)); }
        }

        private async Task LoadProducts() => Products = await _context.Products.ToListAsync();
        private async Task LoadAlcoholDrinks() => AlcoholDrinks = await _context.AlcoholDrinks.ToListAsync();
        private async Task LoadSnacks() => Snacks = await _context.Snacks.ToListAsync();

        private async Task DeleteProductCommandAsync()
        {
            if (SelectedProduct == null)
            {
                MessageBox.Show("Choose the product to delete!");
                return;
            }

            _context.Products.Remove(SelectedProduct);
            MessageBox.Show($"Product {SelectedProduct.Name} deleted");

            try
            {
                await _context.SaveChangesAsync();
                await LoadProducts();
                await LoadAlcoholDrinks();
                await LoadSnacks();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the product: {ex.Message}");
            }
        }

        private async void AddProduct()
        {
            if (string.IsNullOrWhiteSpace(ProductName) || string.IsNullOrWhiteSpace(ProductPrice) || string.IsNullOrWhiteSpace(ProductSpecialization))
            {
                MessageBox.Show("Please fill out all fields!");
                return;
            }

            if (ProductType == "Drink")
            {
                if (!decimal.TryParse(ProductSpecialization, out decimal abv))
                {
                    MessageBox.Show("Wrong ABV value\nTry again!");
                    return;
                }

                _context.AlcoholDrinks.Add(new AlcoholDrink(ProductName, decimal.Parse(ProductPrice), (double)abv));
            }
            else
            {
                _context.Snacks.Add(new Snack(ProductName, decimal.Parse(ProductPrice), ProductSpecialization));
            }

            ProductName = "";
            ProductPrice = "0";
            ProductSpecialization = "";

            try
            {
                await _context.SaveChangesAsync();
                await LoadProducts();
                await LoadAlcoholDrinks();
                await LoadSnacks();
                IsVisibleAdditionPoles = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the product: {ex.Message}");
            }
        }

        private void SetProductType(string productType, string labelProductType)
        {
            IsVisibleAdditionPoles = Visibility.Visible;
            LabelProductType = labelProductType;
            ProductType = productType;
        }

        private async Task ShowCategoryAsync(Func<Task> loadCategory, string category)
        {
            HideAllCategories();

            switch (category)
            {
                case "Products":
                    IsVisibleProducts = Visibility.Visible;
                    break;
                case "AlcoholDrinks":
                    IsVisibleAlcoholDrinks = Visibility.Visible;
                    break;
                case "Snacks":
                    IsVisibleSnacks = Visibility.Visible;
                    break;
            }

            OnPropertyChanged(nameof(IsVisibleProducts));
            OnPropertyChanged(nameof(IsVisibleAlcoholDrinks));
            OnPropertyChanged(nameof(IsVisibleSnacks));

            await loadCategory();

        }

        private void HideAllCategories()
        {
            IsVisibleProducts = Visibility.Collapsed;
            IsVisibleAlcoholDrinks = Visibility.Collapsed;
            IsVisibleSnacks = Visibility.Collapsed;
        }
    }
}
