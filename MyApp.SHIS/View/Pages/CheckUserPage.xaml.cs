using System.Windows;
using System.Windows.Controls;
using MyApp.SHIS.Repository.Repository;
using MyApp.SHIS.Services.Services;
using MyApp.SHIS.ViewModel.PagesViewModels.CheckUserPage;

namespace MyApp.SHIS.View.Pages
{
    public partial class CheckUserPage : Page
    {
        private readonly CheckUserPageViewModel _checkUserPageViewModel = new CheckUserPageViewModel();
        
        public CheckUserPage()
        {
            InitializeComponent();
            this.DataContext = _checkUserPageViewModel;
        }
        
    }
}