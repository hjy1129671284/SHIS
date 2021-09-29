using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using MyApp.SHIS.Commom;
using MyApp.SHIS.ViewModel.WindowsViewModels.Login;

namespace MyApp.SHIS.View.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginView
    {
        private readonly LoginViewModel _loginViewModel = new LoginViewModel();
        public LoginView()
        {
            InitializeComponent();
            this.DataContext = _loginViewModel;
            if (_loginViewModel.UserType == null)
                _loginViewModel.UserType = NormUser;
            
            Messenger.Default.Register<string>(this, "noLogin", SwitchDashBoardView);
            Messenger.Default.Register<string>(this, "login", SwitchDashBoardView);
            Messenger.Default.Register<string>(this, "register", s => ViewManage.ChangeView(this, new RegisterView()));
            Messenger.Default.Register<string>(this, "retrievePassword", s => ViewManage.ChangeView(this, new RetrPwdView()));
            
            Unloaded += (sender, e) => Messenger.Default.Unregister(this);
        }

        public void SwitchDashBoardView(string msg)
        {
            if (msg == "")
            {
                ViewManage.ChangeView(this, new DashBoardView());
            }
            else
            {
                string[] user = msg.Split(',');
                string userName = user[0];
                int.TryParse(user[1], out int userType);

                ViewManage.ChangeView(this, new DashBoardView(userName, userType));
            }
            
        }

    }
}