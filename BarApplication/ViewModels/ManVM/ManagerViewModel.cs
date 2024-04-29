using DB_Coursework;
using DB_Coursework.Models.BaseClasses;
using DB_Coursework.Models.Products;
using System.Windows;
using System.Windows.Input;

namespace BarApplication.ViewModels.ManVM
{
    public class ManagerViewModel : ObservableObject
    {
        private BarContext _context = new();
        private List<Product> _products;
        private List<Snack> _snacks;
        private List<AlcoholDrink> _alcoholDrinks;

        private Product _selectedProduct;
        // Addition of products
        #region
        private string _productName;
        private string _productPrice;
        private string _productSpecialization;
        private string _productType;
        private string _labelProductType;
        private Visibility _isVisible;
        public ICommand AddDrinkButton { get; }
        public ICommand AddSnackButton { get; }
        public ICommand AddProductButton { get; }
        #endregion
        // Deleting product
        public ICommand DeleteProductButton { get; }

        public ManagerViewModel()
        {
            _products = GetProductsList();
            IsVisible = Visibility.Collapsed;
            DeleteProductButton = new RelayCommand(DeleteProductCommand);
            AddDrinkButton = new RelayCommand(AddDrinkCommand);
            AddSnackButton = new RelayCommand(AddSnackCommand);
            AddProductButton = new RelayCommand(AddProductCommand);
        }
        // List Products
        #region
        public List<Product> Products
        {
            get { return _products; }
            set { _products = value; }
        }
        private List<Product> GetProductsList()
        {
            return _context.Products.ToList();
        }
        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set { _selectedProduct = value; }
        }
        #endregion
        // Delete product
        #region
        private void DeleteProductCommand()
        {
            if (SelectedProduct == null)
            {
                MessageBox.Show("Choose the product to delete!");
                return;
            }
            _context.Products.Remove(_selectedProduct);
            MessageBox.Show($"Product {_selectedProduct.Name} deleted");
            _context.SaveChanges();
            _products = GetProductsList();
            OnPropertyChanged(nameof(Products));
        }
        #endregion
        // Add product
        #region
        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }
        public string ProductPrice
        {
            get { return _productPrice; }
            set
            {
                if (decimal.TryParse(value, out var price))
                    _productPrice = value;
            }
        }
        public string ProductSpecialization
        {
            get { return _productSpecialization; }
            set { _productSpecialization = value; }
        }
        public string ProductType
        {
            get { return _productType; }
            set { _productType = value; }
        }
        public Visibility IsVisible
        {
            get { return _isVisible; }
            set { _isVisible = value; }
        }
        public string LabelProductType
        {
            get { return _labelProductType; }
            set { _labelProductType = value; }
        }
        private void AddDrinkCommand()
        {
            IsVisible = Visibility.Visible;
            OnPropertyChanged(nameof(IsVisible));
            LabelProductType = "ABV:";
            OnPropertyChanged(nameof(LabelProductType));
            ProductType = "Drink";
            OnPropertyChanged(nameof(ProductType));
        }
        private void AddSnackCommand()
        {
            IsVisible = Visibility.Visible;
            OnPropertyChanged(nameof(IsVisible));
            LabelProductType = "Snack type:";
            OnPropertyChanged(nameof(LabelProductType));
            ProductType = "Snack";
            OnPropertyChanged(nameof(ProductType));
        }
        private void AddProductCommand()
        {
            if (string.IsNullOrWhiteSpace(ProductName)
                || string.IsNullOrWhiteSpace(ProductPrice)
                || string.IsNullOrWhiteSpace(ProductSpecialization))
            {
                MessageBox.Show("Please fill out all fields!");
                return;
            }
            if (ProductType == "Drink")
            {
                if (!double.TryParse(ProductSpecialization, out var abv))
                {
                    MessageBox.Show("Wrong ABV value\nTry again!");
                    return;
                }
                _context.AlcoholDrinks
                    .Add(new AlcoholDrink(ProductName, decimal.Parse(ProductPrice), double.Parse(ProductSpecialization)));
            }
            else
            {
                _context.Snacks
                    .Add(new Snack(ProductName, decimal.Parse(ProductPrice), ProductSpecialization));
            }

            _context.SaveChanges();
            _products = GetProductsList();
            OnPropertyChanged(nameof(Products));
            IsVisible = Visibility.Collapsed;
            OnPropertyChanged(nameof(IsVisible));
        }
        #endregion
    }
}
