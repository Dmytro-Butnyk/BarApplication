using BarApplication.ViewModels.SellVM;
using BarApplication.ViewModels.SellVM.Servises;
using System.Windows.Controls;

namespace BarApplication.Views
{
    /// <summary>
    /// Логика взаимодействия для SellerView.xaml
    /// </summary>
    public partial class SellerView : Page
    {
        public SellerView(NavigationDataServiceSell ndss)
        {
            InitializeComponent();
            DataContext = new SellerViewModel(ndss);
        }
    }
}
