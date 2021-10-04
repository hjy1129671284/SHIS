using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GalaSoft.MvvmLight.Messaging;
using MyApp.SHIS.View.Windows;
using MyApp.SHIS.ViewModel.PagesViewModels.PatiInfoPage;

namespace MyApp.SHIS.View.Pages
{
    public partial class PatiInfoPage : Page
    {
        private readonly DashBoardView _dashBoardView;
        private readonly PatiInfoPageViewModel _patiInfoPageViewModel = new PatiInfoPageViewModel();
        public PatiInfoPage(DashBoardView dashBoardView)
        {
            _dashBoardView = dashBoardView;
            InitializeComponent();
            this.DataContext = _patiInfoPageViewModel;
            
            _patiInfoPageViewModel.IDCardComBoxVisibility = Visibility.Visible;
            _patiInfoPageViewModel.IDCardTextBoxVisibility = Visibility.Collapsed;
            _patiInfoPageViewModel.IDCardText = "证件类型";
            _patiInfoPageViewModel.IDCardTextColor = new SolidColorBrush(Colors.Black);
            
            Messenger.Default.Register<int>(this, "patiInfo2Register", PatiRegisterPage);

            Unloaded += (sender, e) => Messenger.Default.Unregister(this);

        }
        
        private void PatiRegisterPage(int medCardNum)
        {
            _dashBoardView.SwitchPages(new RegisterPage(medCardNum));
        }
    }
}