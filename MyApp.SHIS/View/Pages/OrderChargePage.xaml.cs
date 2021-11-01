using System.Windows.Controls;
using MyApp.SHIS.ViewModel.PagesViewModels.OrderChargePage;

namespace MyApp.SHIS.View.Pages
{
    public partial class OrderChargePage : Page
    {
        private readonly OrderChargePageViewModel _orderChargePageViewModel;
        public OrderChargePage(string userName)
        {
            _orderChargePageViewModel = new OrderChargePageViewModel(userName);
            InitializeComponent();
            this.DataContext = _orderChargePageViewModel;
        }
    }
}