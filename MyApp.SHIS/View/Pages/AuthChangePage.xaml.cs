using System.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using MyApp.SHIS.Models;
using MyApp.SHIS.Repository.Repository;
using MyApp.SHIS.Services.Services;
using MyApp.SHIS.ViewModel.PagesViewModels.AuthChangePage;

namespace MyApp.SHIS.View.Pages
{
    public partial class AuthChangePage : Page
    {
        private readonly AuthChangePageViewModel _authChangePageViewModelmodel = new AuthChangePageViewModel();
        public AuthChangePage()
        {
            
            InitializeComponent();
            this.DataContext = _authChangePageViewModelmodel;
            
        }
    }
}