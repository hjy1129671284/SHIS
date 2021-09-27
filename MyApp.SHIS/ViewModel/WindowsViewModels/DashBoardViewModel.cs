using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using MyApp.SHIS.Annotations;
using MyApp.SHIS.View.Windows;

namespace MyApp.SHIS.ViewModel.WindowsViewModels
{
    public sealed class DashBoardViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _userType;
        private string _userName;
        private string _userLoginButtonContent;
        private Visibility _settingButtonVisibility;
        private Visibility _buttonOpenMenuVisibility;
        private Visibility _buttonCloseMenuVisibility;

        public DashBoardViewModel()
        {
            
        }

        public string UserType
        {
            get => _userType;
            set
            {
                switch (value)
                {
                    case "0": _userType = "管理员 "; break;
                    case "1": _userType = "用户 "; break;
                    case "2": _userType = "患者 "; break;
                    case "3": _userType = "医生 "; break;
                    case "4": _userType = "药师 "; break;
                    case "5": _userType = "挂号员 "; break;
                    case "6": _userType = "收费员 "; break;
                    case "7": _userType = "护士 "; break;
                }
                OnPropertyChanged(nameof(UserType));
            }
        }

        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
            } 
        }

        public string UserLoginButtonContent
        {
            get => _userLoginButtonContent;
            set
            {
                _userLoginButtonContent = value;
                OnPropertyChanged(nameof(_userLoginButtonContent));
            }
        }

        public Visibility SettingButtonVisibility
        {
            get => _settingButtonVisibility;
            set
            {
                _settingButtonVisibility = value;
                OnPropertyChanged(nameof(SettingButtonVisibility));
            }
        }

        public Visibility ButtonOpenMenuVisibility
        {
            get => _buttonOpenMenuVisibility;
            set
            {
                _buttonOpenMenuVisibility = value;
                OnPropertyChanged(nameof(ButtonOpenMenuVisibility));
            }
        }
        
        public Visibility ButtonCloseMenuVisibility
        {
            get => _buttonCloseMenuVisibility;
            set
            {
                _buttonCloseMenuVisibility = value;
                OnPropertyChanged(nameof(ButtonCloseMenuVisibility));
            }
        }
    }
}