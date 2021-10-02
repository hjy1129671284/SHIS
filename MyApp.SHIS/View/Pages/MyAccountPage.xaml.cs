using System;
using MaterialDesignThemes.Wpf;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GalaSoft.MvvmLight.Messaging;
using MyApp.SHIS.Commom;
using MyApp.SHIS.Repository.Repository;
using MyApp.SHIS.Services.Services;
using MyApp.SHIS.View.Windows;
using MyApp.SHIS.ViewModel.PagesViewModels.MyAccountPage;

namespace MyApp.SHIS.View.Pages
{
    public partial class MyAccountPage : Page
    {
        private readonly string _userName;
        private readonly DashBoardView _context;
        private readonly MyAccountPageViewModel _myAccountPageViewModel = new MyAccountPageViewModel();
        public MyAccountPage(string userName, DashBoardView context)
        {
            _userName = userName;
            _context = context;
            InitializeComponent();
            _myAccountPageViewModel.UserName = userName;
            _myAccountPageViewModel.GenerateHint(_myAccountPageViewModel.UserName);
            this.DataContext = _myAccountPageViewModel;

            Messenger.Default.Register<string>(this, "MyAccount2IDAuth", msg => SwitchIDAuthView());
            
            _myAccountPageViewModel.IDCardComBoxVisibility = Visibility.Visible;
            _myAccountPageViewModel.IDCardTextBoxVisibility = Visibility.Collapsed;
            _myAccountPageViewModel.IDCardText = "证件类型";
            _myAccountPageViewModel.IDCardTextColor = new SolidColorBrush(Colors.Black);
            _myAccountPageViewModel.AuthTypeText = "去认证";
            _myAccountPageViewModel.IsAuth = false;

            Unloaded += (sender, e) => Messenger.Default.Unregister(this);

        }

        public void SwitchIDAuthView()
        {
            _context.ContentControl.Content = new Frame()
            {
                Content = new VerifiedPage()
            };
        }
    }
}