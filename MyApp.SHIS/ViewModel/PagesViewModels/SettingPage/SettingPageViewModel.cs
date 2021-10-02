using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using MyApp.SHIS.Repository.Repository;
using MyApp.SHIS.Services.Services;
using MyApp.SHIS.ViewModel.Common;

namespace MyApp.SHIS.ViewModel.PagesViewModels.SettingPage
{
    public class SettingPageViewModel : NotificationObject
    {
        private readonly SettingPageModel _settingPageModel = new SettingPageModel();

        public ICommand _changePwd;
        
        #region 属性

        public string UserName
        {
            get => _settingPageModel.UserName;
            set
            {
                _settingPageModel.UserName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        public decimal Balance
        {
            get => _settingPageModel.Balance;
            set
            {
                _settingPageModel.Balance = value;
                OnPropertyChanged(nameof(Balance));
            }
        }

        public string OldPwd
        {
            get => _settingPageModel.OldPwd;
            set
            {
                _settingPageModel.OldPwd = value;
                OnPropertyChanged(nameof(OldPwd));
            }
        }

        public string NewPwd1
        {
            get => _settingPageModel.NewPwd1;
            set
            {
                _settingPageModel.NewPwd1 = value;
                OnPropertyChanged(nameof(NewPwd1));
            }
        }

        public string NewPwd2
        {
            get => _settingPageModel.NewPwd2;
            set
            {
                _settingPageModel.NewPwd2 = value;
                OnPropertyChanged(nameof(NewPwd2));
            }
        }
        
        #endregion

        #region 命令

        public ICommand ChangePwd
        {
            get => _changePwd ?? (_changePwd = new RelayCommand(EditPwd));
            set => _changePwd = value;
        }

        #endregion

        #region 命令方法

        public async void EditPwd()
        {
            UserService userService = new UserService(new UserRepository());
            var result = await userService.QueryAsync(it => it.UserName == _settingPageModel.UserName);

            var user = result[0];
            string userPwd = user.UserPwd;

            if (userPwd == _settingPageModel.OldPwd)
            {
                if (_settingPageModel.NewPwd1 == _settingPageModel.NewPwd2)
                {
                    user.UserPwd = NewPwd1;
                    bool isEdit = await userService.EditAsync(user);
                    
                    MessageBox.Show(isEdit? "修改成功" : "修改失败");
                }
            }
            else
            {
                MessageBox.Show("原密码错误，请重试");
            }
            
        }

        #endregion
        
    }
}