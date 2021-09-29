using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MyApp.SHIS.Repository.Repository;
using MyApp.SHIS.Services.Services;
using MyApp.SHIS.ViewModel.Common;

namespace MyApp.SHIS.ViewModel.WindowsViewModels.RetrPwd
{
    public class RetrPwdViewModel : NotificationObject
    {
        private readonly RetrPwdModel _retrPwdModel = new RetrPwdModel();

        public string UserName
        {
            get => _retrPwdModel.UserName;
            set
            {
                _retrPwdModel.UserName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        private ICommand _back2DashBoard;
        public ICommand Back2DashBoard
        {
            get
            {
                return _back2DashBoard ?? new RelayCommand(
                    () => Messenger.Default.Send("", "retrievePassword2DashBoard")
                );
            }
            set => _back2DashBoard = value;
        }
        
        private ICommand _back2Login;
        public ICommand Back2Login
        {
            get
            {
                return _back2Login ?? new RelayCommand(
                    () => Messenger.Default.Send("", "retrievePassword2Login")
                );
            }
            set => _back2Login = value;
        }

        private ICommand _retrievePwd;
        public ICommand RetrievePwd
        {
            get
            {
                return _retrievePwd ?? new RelayCommand(
                    () => RetrPwd(_retrPwdModel.UserName)
                );
            }
            set => _retrievePwd = value;
        }


        public async void RetrPwd(string userName)
        {
            UserService userService = new UserService(new UserRepository());

            var result = await userService.QueryAsync(it => it.UserName == userName);


            if (result != null && result.Count > 0)
            {
                MessageBox.Show($"用户{userName},您好,您的密码可能是{result[0].UserPwd}");
            }
            else
            {
                MessageBox.Show("此账号不存在，请尝试注册账号");
            }

                
            
            
        }
    }
}