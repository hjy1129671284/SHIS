using System.Diagnostics;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using MyApp.SHIS.Commom;
using MyApp.SHIS.Models;
using MyApp.SHIS.ViewModel.WindowsViewModels.RetrPwd;
using SqlSugar;

namespace MyApp.SHIS.View.Windows
{
    public partial class RetrPwdView
    {
        private readonly RetrPwdViewModel _retrPwdViewModel = new RetrPwdViewModel();

        public RetrPwdView()
        {
            
            Messenger.Default.Register<string>(this, "retrievePassword2DashBoard", s => ViewManage.ChangeView(this, new DashBoardView()));
            Messenger.Default.Register<string>(this, "retrievePassword2Login", s => ViewManage.ChangeView(this, new LoginView()));
            
            InitializeComponent();
            this.DataContext = _retrPwdViewModel;
            
            Unloaded += (sender, e) => Messenger.Default.Unregister(this);
        }
        
    }
}