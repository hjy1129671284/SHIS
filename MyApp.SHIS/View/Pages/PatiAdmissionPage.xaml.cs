using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using MyApp.SHIS.View.Windows;
using MyApp.SHIS.ViewModel.PagesViewModels.PatiAdmissionPage;

namespace MyApp.SHIS.View.Pages
{
    public partial class PatiAdmissionPage : Page
    {
        private readonly PatiAdmissionPageViewModel _patiAdmissionPageViewModel;
        private readonly DashBoardView _dashBoardView;
        private readonly string _userName;
        public PatiAdmissionPage(DashBoardView dashBoardView, string userName)
        {
            _dashBoardView = dashBoardView;
            _userName = userName;
            _patiAdmissionPageViewModel = new PatiAdmissionPageViewModel(userName);
            InitializeComponent();
            this.DataContext = _patiAdmissionPageViewModel;
            
            Messenger.Default.Register<int>(this, "patiAdmission2Diagnosis", Switch2Diag);
            
        }

        public void Switch2Diag(int msg)
        {
            _dashBoardView.SwitchPages(new DiagnosisPage(_dashBoardView, _userName, msg));
        }
    }
}