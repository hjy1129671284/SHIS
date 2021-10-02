using System.Windows;
using System.Windows.Controls;
using MyApp.SHIS.ViewModel.PagesViewModels.AuthChangePage;

namespace MyApp.SHIS.View.Pages
{
    public partial class AuthChangePage : Page
    {
        private readonly AuthChangePageViewModel _authChangePageViewModel = new AuthChangePageViewModel();
        public AuthChangePage()
        {
            
            InitializeComponent();
            this.DataContext = _authChangePageViewModel;
            _authChangePageViewModel.PatiVisibility = Visibility.Collapsed;
            _authChangePageViewModel.StaffVisibility = Visibility.Collapsed;
            _authChangePageViewModel.DoctVisibility = Visibility.Collapsed;
        }
    }
}