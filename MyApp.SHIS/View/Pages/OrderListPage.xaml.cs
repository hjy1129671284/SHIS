using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using MyApp.SHIS.Models;
using MyApp.SHIS.View.Windows;
using MyApp.SHIS.ViewModel.PagesViewModels.OrderListPage;

namespace MyApp.SHIS.View.Pages
{
    public partial class OrderListPage : Page
    {
        private readonly OrderListPageViewModel _orderListPageViewModel= new OrderListPageViewModel();
        private readonly DashBoardView _dashBoardView;
        private readonly string _userName;
        public OrderListPage(DashBoardView dashBoardView, string userName)
        {
            _dashBoardView = dashBoardView;
            _userName = userName;
            InitializeComponent();
            this.DataContext = _orderListPageViewModel;
            
            Messenger.Default.Register<int>(this, "switch2OrderExec", Switch2OrderExec);
            
        }

        public void Switch2OrderExec(int msg)
        {
            _dashBoardView.SwitchPages(new OrderExecPage(_dashBoardView, _userName, msg));
        }
    }
}