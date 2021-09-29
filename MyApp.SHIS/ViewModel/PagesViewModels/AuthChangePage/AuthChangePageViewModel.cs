using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using MyApp.SHIS.Models;
using MyApp.SHIS.Repository.Repository;
using MyApp.SHIS.Services.Services;
using MyApp.SHIS.ViewModel.Common;

namespace MyApp.SHIS.ViewModel.PagesViewModels.AuthChangePage
{
    public class AuthChangePageViewModel : NotificationObject
    {
        private readonly AuthChangePageModel _authChangePageModel = new AuthChangePageModel();

        public AuthChangePageViewModel()
        {

        }
        
        public string UserName
        {
            get => _authChangePageModel.UserName;
            set
            {
                _authChangePageModel.UserName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        public ComboBoxItem UserType
        {
            get => _authChangePageModel.UserType;
            set
            {
                _authChangePageModel.UserType = value;
                OnPropertyChanged(nameof(UserType));
            }
        }

        public ObservableCollection<user> UserList
        {
            get => _authChangePageModel.UserList;
            set
            {
                _authChangePageModel.UserList = value;
                OnPropertyChanged(nameof(UserList));
            }
        }

        private ICommand _findUser;

        public ICommand FindUser
        {
            get => _findUser ?? new RelayCommand(() => Find(_authChangePageModel.UserName));
            set => _findUser = value;
        }

        public async void Find(string userName)
        {
            _authChangePageModel.UserList.Clear();
            UserService userService = new UserService(new UserRepository());
            var result = await userService.QueryAsync(it => it.UserName == userName);
            if (result != null && result.Count > 0)
            {
                _authChangePageModel.UserList.Add(result[0]);
            }
            else
            {
                MessageBox.Show($"没找到{userName}");
                
            }
        }

        private ICommand _changAuth;

        public ICommand ChangeAuth
        {
            get
            {
                return _changAuth ?? new RelayCommand(
                    () => ChangUserAuth(_authChangePageModel.UserName, _authChangePageModel.UserType.Content.ToString())
                );
            }
            set => _changAuth = value;
        }

        public async void ChangUserAuth(string userName, string type)
        {
            int userType = -1;
            switch (type)
            {
                case "管理员": userType = 0; break;
                case "普通用户":  userType = 1; break;
                case "病人":   userType = 2; break;
                case "医生":   userType = 3; break;
                case "药师": userType = 4; break;
                case "挂号员":  userType = 5; break;
                case "收费员":  userType = 6; break;
                case "护士":  userType = 7; break;
            }
            UserService userService = new UserService(new UserRepository());
            var user = await userService.QueryAsync(it => it.UserName == userName);
            user[0].UserType = userType;
            
            await userService.EditAsync(user[0]);
            MessageBox.Show($"改变成功,目前 {userName} 用户的权限为 {type}");
        }

    }    
    
}