using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using MyApp.SHIS.View.Windows;
using MyApp.SHIS.ViewModel.PagesViewModels.OrderExecPage;

namespace MyApp.SHIS.View.Pages
{
    public partial class OrderExecPage : Page
    {
        private readonly OrderExecPageViewModel _orderExecPageViewModel;
        private readonly DashBoardView _dashBoardView;
        public OrderExecPage(DashBoardView dashBoardView, string userName, int? orderID = null)
        {
            _orderExecPageViewModel = new OrderExecPageViewModel(userName, orderID);
            _dashBoardView = dashBoardView;
            InitializeComponent();
            this.DataContext = _orderExecPageViewModel;
            
            Messenger.Default.Register<string>(this, "switch2OrderList", Switch2OrderList);

        }

        public void Switch2OrderList(string msg)
        {
            _dashBoardView.SwitchPages(new OrderListPage(_dashBoardView, msg));
        }
    }
}