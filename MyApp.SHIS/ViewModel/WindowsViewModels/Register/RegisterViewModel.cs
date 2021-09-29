using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MyApp.SHIS.Models;
using MyApp.SHIS.Repository.Repository;
using MyApp.SHIS.Services.Services;
using MyApp.SHIS.ViewModel.Common;

namespace MyApp.SHIS.ViewModel.WindowsViewModels.Register
{
    public class RegisterViewModel : NotificationObject
    {
        private readonly RegisterModel _registerModel = new RegisterModel();

        public string UserName
        {
            get => _registerModel.UserName;
            set
            {
                _registerModel.UserName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }
        
        public string PassWord1
        {
            get => _registerModel.PassWord1;
            set
            {
                _registerModel.PassWord1 = value;
                OnPropertyChanged(nameof(PassWord1));
            }
        }
        
        public string PassWord2
        {
            get => _registerModel.PassWord2;
            set
            {
                _registerModel.PassWord2 = value;
                OnPropertyChanged(nameof(PassWord2));
            }
        }

        private ICommand _register;
        public ICommand Register
        {
            get
            {
                return _register ?? new RelayCommand(
                    () => { UserRegister(_registerModel.UserName, _registerModel.PassWord1, _registerModel.PassWord2); }
                );
            }
            set => _register = value;
        }
        
        private ICommand _back2DashBoard;
        public ICommand Back2DashBoard
        {
            get
            {
                return _back2DashBoard ?? new RelayCommand(
                    () => { Messenger.Default.Send("", "register2DashBoard"); }
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
                    () => { Messenger.Default.Send("", "register2Login"); }
                );
            }
            set => _back2Login = value;
        }


        public async void UserRegister(string userName, string pwd1, string pwd2)
        {
            UserService userService = new UserService(new UserRepository());
            NormUserService normUserService = new NormUserService(new NormUserRepository());

            var result = userService.QueryAsync(it => it.UserName == userName).Result;

            if (result != null && result.Count > 0)
            {
                MessageBox.Show("帐号已存在，注册失败");
            }
            else
            {
                if (pwd1 == pwd2)
                {
                    // 插入数据
                    await userService.CreateAsync(new user() { UserName = userName, UserPwd = pwd1, UserType = 1});
                    await normUserService.CreateAsync(new norm_user() {UserName = userName});
                    MessageBox.Show("注册成功");
                }
                else
                {
                    MessageBox.Show("两次输入密码不同，注册失败");
                }
                
            }
        }
    }
}