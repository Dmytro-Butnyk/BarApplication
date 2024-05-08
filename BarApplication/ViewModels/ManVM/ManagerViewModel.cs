using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DB_Coursework;
using DB_Coursework.Models.BaseClasses;
using DB_Coursework.Models.Orders;
using DB_Coursework.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace BarApplication.ViewModels.ManVM
{
    public class ManagerViewModel : ObservableObject
    {
        private readonly BarContext _context = new BarContext();

        private Visibility _isVisibleAdditionPoles = Visibility.Collapsed;
        private Visibility _isVisibleNewTableFields = Visibility.Collapsed;
        private Visibility _isVisibleProducts = Visibility.Collapsed;
        private Visibility _isVisibleAlcoholDrinks = Visibility.Collapsed;
        private Visibility _isVisibleSnacks = Visibility.Collapsed;

        private string _labelProductType;
        private string[] _pRegistration = new string[3];
        private string _productType;
        private Product _selectedProduct;

        private ObservableCollection<Product> _products;
        private ObservableCollection<AlcoholDrink> _alcoholDrinks;
        private ObservableCollection<Snack> _snacks;
        private ObservableCollection<Table> _tables;

        public ICommand DeleteProductButton { get; set; }
        public ICommand AddDrinkButton { get; set; }
        public ICommand AddSnackButton { get; set; }
        public ICommand AddProductButton { get; set; }
        public ICommand ShowProductsButton { get; set; }
        public ICommand ShowAlcoholDrinksButton { get; set; }
        public ICommand ShowSnacksButton { get; set; }
        public ICommand GoToSuppliesCommand { get; set; }
        public ICommand GoToUsersCommand { get; set; }
        public ICommand AddTableCommand { get; set; }
        public ICommand ShowTableFields { get; set; }
        public ICommand DeleteTablesCommand { get; set; }

        public ManagerViewModel(NavigationDataServiceMan nbvm)
        {
            GoToSuppliesCommand = nbvm.GoToSuppliesPageCommand;
            GoToUsersCommand = nbvm.GoToUsersPageCommand;

            InitializeCommands();
            LoadData();
        }

        private void InitializeCommands()
        {
            DeleteProductButton = new RelayCommand(async () => await DeleteProductAsync());
            DeleteTablesCommand = new RelayCommand(async () => await DeleteTables());
            AddProductButton = new RelayCommand(AddProduct);
            AddTableCommand = new RelayCommand(async () => await AddNewTable());

            AddDrinkButton = new RelayCommand(() => SetProductType("Drink", "ABV:"));
            AddSnackButton = new RelayCommand(() => SetProductType("Snack", "Snack type:"));
            ShowTableFields = new RelayCommand(() => SetProductType("Table", string.Empty));

            ShowProductsButton = new RelayCommand(async () => await ShowCategoryAsync(LoadProducts, "Products"));
            ShowAlcoholDrinksButton = new RelayCommand(async () => await ShowCategoryAsync(LoadAlcoholDrinks, "AlcoholDrinks"));
            ShowSnacksButton = new RelayCommand(async () => await ShowCategoryAsync(LoadSnacks, "Snacks"));
        }

        private async Task LoadData()
        {
            await LoadTables();
            await LoadProducts();
            await LoadAlcoholDrinks();
            await LoadSnacks();
        }

        // Properties
        public ObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        public ObservableCollection<AlcoholDrink> AlcoholDrinks
        {
            get => _alcoholDrinks;
            set
            {
                _alcoholDrinks = value;
                OnPropertyChanged(nameof(AlcoholDrinks));
            }
        }

        public ObservableCollection<Snack> Snacks
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

        public ObservableCollection<Table> Tables
        {
            get => _tables;
            set
            {
                _tables = value;
                OnPropertyChanged(nameof(Tables));
            }
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

        public Visibility IsVisibleNewTableFields
        {
            get => _isVisibleNewTableFields;
            set
            {
                _isVisibleNewTableFields = value;
                OnPropertyChanged(nameof(IsVisibleNewTableFields));
            }
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

        public int NewTableNumber
        {
            get => _newTableNumber;
            set
            {
                if (value > 0)
                    _newTableNumber = value;
                else
                    MessageBox.Show("Wrong table number value!");
                OnPropertyChanged(nameof(NewTableNumber));
            }
        }

        private int _newTableNumber;

        // Methods
        private async Task LoadProducts() => Products = new ObservableCollection<Product>(await _context.Products.ToListAsync());

        private async Task LoadAlcoholDrinks() => AlcoholDrinks = new ObservableCollection<AlcoholDrink>(await _context.AlcoholDrinks.ToListAsync());

        private async Task LoadSnacks() => Snacks = new ObservableCollection<Snack>(await _context.Snacks.ToListAsync());

        private async Task LoadTables() => Tables = new ObservableCollection<Table>(await _context.Tables.ToListAsync());

        private async Task DeleteProductAsync()
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
            if (productType == "Drink" || productType == "Snack")
            {
                IsVisibleAdditionPoles = Visibility.Visible;
                IsVisibleNewTableFields = Visibility.Collapsed;
                LabelProductType = labelProductType;
                ProductType = productType;
            }
            else
            {
                IsVisibleAdditionPoles = Visibility.Collapsed;
                IsVisibleNewTableFields = Visibility.Visible;
            }
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

        private async Task AddNewTable()
        {
            if (Tables.Any(x => x.Number == NewTableNumber))
            {
                MessageBox.Show("This table number already exists");
                return;
            }
            if (NewTableNumber == 0)
                return;

            _context.Tables.Add(new Table { Number = NewTableNumber });
            _context.SaveChanges();
            MessageBox.Show($"New table number {NewTableNumber} added!");
            NewTableNumber = 1;
            await LoadTables();
        }

        private async Task DeleteTables()
        {
            _context.Tables.RemoveRange(Tables);
            _context.SaveChanges();
            MessageBox.Show("Tables deleted");
            await LoadTables();
        }
    }
}
