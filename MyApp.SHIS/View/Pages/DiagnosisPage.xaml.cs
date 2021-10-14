using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using MyApp.SHIS.View.Windows;
using MyApp.SHIS.ViewModel.PagesViewModels.DiagnosisPage;

namespace MyApp.SHIS.View.Pages
{
    public partial class DiagnosisPage : Page
    {
        private readonly DashBoardView _dashBoardView;
        private readonly string _userName;
        private readonly DiagnosisPageViewModel _diagnosisPageViewModel;
        public DiagnosisPage(DashBoardView dashBoardView, string userName, int? serialNumber = null)
        {
            _dashBoardView = dashBoardView;
            _userName = userName;
            _diagnosisPageViewModel = new DiagnosisPageViewModel(userName, serialNumber);
            InitializeComponent();
            this.DataContext = _diagnosisPageViewModel;
            
            Messenger.Default.Register<int>(this, "diagnosis2OrderWrite", Switch2Order);
        }

        public void Switch2Order(int msg)
        {
            _dashBoardView.SwitchPages(new OrderWritePage(_userName, msg));
        }
        
    }
}