using System.Windows.Controls;
using MyApp.SHIS.ViewModel.PagesViewModels.OrderListPage;

namespace MyApp.SHIS.View.Pages
{
    public partial class OrderListPage : Page
    {
        private readonly OrderListPageViewModel _orderListPageViewModel = new OrderListPageViewModel();
        public OrderListPage()
        {
            InitializeComponent();
            this.DataContext = _orderListPageViewModel;
        }
    }
}