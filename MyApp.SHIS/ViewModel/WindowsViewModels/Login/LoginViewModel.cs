using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MyApp.SHIS.Models;
using MyApp.SHIS.Repository.Repository;
using MyApp.SHIS.Services.Services;
using MyApp.SHIS.ViewModel.Common;
using MyApp.SHIS.Commom;

namespace MyApp.SHIS.ViewModel.WindowsViewModels.Login
{
    public class LoginViewModel: NotificationObject
    {
        private readonly LoginModel _loginModel = new LoginModel();
        

        private ICommand _noLogin;
        private ICommand _login;
        private ICommand _register;
        private ICommand _retrievePassword;
        private ICommand _switchUserType;

        
        # region 属性
        public string UserName
        {
            get => _loginModel.UserName;
            set
            {
                _loginModel.UserName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        public string PassWord
        {
            get => _loginModel.PassWord;
            set
            {
                _loginModel.PassWord = value;
                OnPropertyChanged(nameof(PassWord));
            }
        }
        
        public ListBoxItem UserType
        {
            get => _loginModel.UserType;
            set
            {
                _loginModel.UserType = value;
                OnPropertyChanged(nameof(UserType));
            }
        }
        
        #endregion

        public ICommand NoLogin
        {
            get
            {
                return _noLogin ?? (_noLogin = new RelayCommand(
                    () =>
                    {
                        Messenger.Default.Send("", "noLogin");
                    }
                ));
            }
            set => _noLogin = value;
        }


        #region 命令

        public ICommand Login
        {
            get
            {
                return _login ?? (_login = new RelayCommand(
                    () =>
                    {
                        LoginAdjust(_loginModel.UserName, _loginModel.UserType.Content.ToString());
                    }
                ));
            }
            set => _login = value;
        }

        public ICommand Register
        {
            get
            {
                return _register ?? (_register = new RelayCommand(
                    () =>
                    {
                        Messenger.Default.Send("", "register");
                    }
                ));
            }
            set => _register = value;
        }
        
        public ICommand RetrievePassword
        {
            get
            {
                return _retrievePassword ?? (_retrievePassword = new RelayCommand(
                    () =>
                    {
                        Messenger.Default.Send("", "retrievePassword");
                    }
                ));
            }
            set => _retrievePassword = value;
        }

        public ICommand SwitchUserType
        {
            get => _switchUserType ?? (_switchUserType = new RelayCommand(
                () =>
                {
                    _loginModel.UserType.Focus();
                }
            ));
            set => _switchUserType = value;
        }

        #endregion
        
        
        
        
        
        #region 帐号登录判断
        public async void LoginAdjust(string userName, string userType)
        {
            UserService userService = new UserService(new UserRepository());
            StaffUserService staffUserService = new StaffUserService(new StaffUserRepository());
            int type = -1;

            switch (userType)
            {
                case "管理员": type = 0; break;
                case "普通用户": type = 1; break;
                case "患者": type = 2; break;
                case "职工":
                    var staff = await staffUserService.QueryAsync(it => it.UserName == userName);
                    if (staff != null && staff.Count > 0)
                        type = staff[0].StafType;
                    break;
            }

            var users = await userService.QueryAsync(it => it.UserName == userName);
            if (users != null && users.Count > 0)
            {
                if (users[0].UserPwd == _loginModel.PassWord)
                {
                    bool loginFlag = AuthAdjust(users, type);
                    if (loginFlag)
                    {
                        switch (type)
                        {
                            case 0: userType = "管理员"; break;
                            case 1: userType = "普通用户"; break;
                            case 2: userType = "患者"; break;
                            case 3: userType = "医生"; break;
                            case 4: userType = "药师"; break;
                            case 5: userType = "挂号员"; break;
                            case 6: userType = "收费员"; break;
                            case 7: userType = "护士"; break;
                        }
                        MessageBox.Show($"登录成功，欢迎{userType} {userName}");
                        Messenger.Default.Send($"{userName}, {type}", "login");
                        RemindPwd.UpdateSettingString("userName", userName);
                    }
                    else
                        MessageBox.Show($"登录失败，您的账号并不是{userType}，请切换账号类型或者输入正确的帐号密码");
                }
                else
                {
                    MessageBox.Show("密码错误，登录失败");
                }
            }
            else
            {
                MessageBox.Show("帐号不存在，登录失败");
            }
        }
        #endregion
        
        
                
        #region 根据选择的登陆帐号类型和数据库中的账号类型判断用户是否有权限登录
        public bool AuthAdjust(List<user> users, int type)
        {
            int usertype = users[0].UserType;
            bool flag = false;
            if (type == 1)
            {
                flag = true;
            }
            else if (type == 2)
            {
                if (usertype != 1)
                {
                    flag = true;
                }
            }
            else
            {
                if (type == usertype)
                {
                    flag = true;
                }
            }
            return flag;
        }
        #endregion



    }
}