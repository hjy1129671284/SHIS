using System.Windows.Controls;
using MyApp.SHIS.ViewModel.PagesViewModels.OrderWritePage;

namespace MyApp.SHIS.View.Pages
{
    public partial class OrderWritePage : Page
    {
        private readonly OrderWritePageViewModel _orderWritePageViewModel;
        public OrderWritePage(string userName, int? serialNumber = null)
        {
            _orderWritePageViewModel = new OrderWritePageViewModel(userName, serialNumber);
            InitializeComponent();
            this.DataContext = _orderWritePageViewModel;
        }
    }
}