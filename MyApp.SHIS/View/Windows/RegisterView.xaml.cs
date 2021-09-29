using System.Windows;
using MyApp.SHIS.Commom;
using GalaSoft.MvvmLight.Messaging;
using MyApp.SHIS.Models;
using MyApp.SHIS.Repository.Repository;
using MyApp.SHIS.Services.Services;
using MyApp.SHIS.ViewModel.WindowsViewModels.Register;

namespace MyApp.SHIS.View.Windows
{
    public partial class RegisterView
    {
        private readonly RegisterViewModel _registerViewModel = new RegisterViewModel();
        public RegisterView()
        {
            Messenger.Default.Register<string>(this, "register2Login", s =>  
                ViewManage.ChangeView(this, new LoginView()));
            Messenger.Default.Register<string>(this, "register2DashBoard", s => 
                ViewManage.ChangeView(this, new DashBoardView()));
            
            InitializeComponent();
            this.DataContext = _registerViewModel;
            
            Unloaded += (sender, e) => Messenger.Default.Unregister(this);

        }
        
    }
}