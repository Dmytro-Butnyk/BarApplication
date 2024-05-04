using BarApplication.ViewModels.SellVM;
using System.Windows.Controls;

namespace BarApplication.Views
{
    /// <summary>
    /// Логика взаимодействия для SellerView.xaml
    /// </summary>
    public partial class SellerView : Page
    {
        public SellerView()
        {
            InitializeComponent();
            DataContext = new SellerViewModel();
        }
    }
}
