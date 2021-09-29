using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MyApp.SHIS.ViewModel.Common;

namespace MyApp.SHIS.ViewModel.WindowsViewModels.DashBoard
{
    public sealed class DashBoardViewModel : NotificationObject
    {
        private readonly DashBoardModel _dashBoardModel = new DashBoardModel();

        public string UserType
        {
            get => _dashBoardModel.UserType;
            set
            {
                switch (value)
                {
                    case "0": _dashBoardModel.UserType = "管理员 "; Messenger.Default.Send("管理员", "generateMenu"); break;
                    case "1": _dashBoardModel.UserType = "用户 "; Messenger.Default.Send("用户", "generateMenu");break;
                    case "2": _dashBoardModel.UserType = "患者 "; Messenger.Default.Send("患者", "generateMenu");break;
                    case "3": _dashBoardModel.UserType = "医生 "; Messenger.Default.Send("医生", "generateMenu");break;
                    case "4": _dashBoardModel.UserType = "药师 "; Messenger.Default.Send("药师", "generateMenu");break;
                    case "5": _dashBoardModel.UserType = "挂号员 "; Messenger.Default.Send("挂号员", "generateMenu");break;
                    case "6": _dashBoardModel.UserType = "收费员 "; Messenger.Default.Send("收费员", "generateMenu");break;
                    case "7": _dashBoardModel.UserType = "护士 "; Messenger.Default.Send("护士", "generateMenu");break;
                    default: Messenger.Default.Send("  ", "generateMenu");break;
                }
                OnPropertyChanged(nameof(UserType));
            }
        }

        public string UserName
        {
            get => _dashBoardModel.UserName;
            set
            {
                _dashBoardModel.UserName = value;
                OnPropertyChanged(nameof(UserName));
            } 
        }

        public string UserLoginButtonContent
        {
            get => _dashBoardModel.UserLoginButtonContent;
            set
            {
                _dashBoardModel.UserLoginButtonContent = value;
                OnPropertyChanged(nameof(_dashBoardModel.UserLoginButtonContent));
            }
        }

        public Visibility SettingButtonVisibility
        {
            get => _dashBoardModel.SettingButtonVisibility;
            set
            {
                _dashBoardModel.SettingButtonVisibility = value;
                OnPropertyChanged(nameof(SettingButtonVisibility));
            }
        }

        public Visibility ButtonOpenMenuVisibility
        {
            get => _dashBoardModel.ButtonOpenMenuVisibility;
            set
            {
                _dashBoardModel.ButtonOpenMenuVisibility = value;
                OnPropertyChanged(nameof(ButtonOpenMenuVisibility));
            }
        }
        
        public Visibility ButtonCloseMenuVisibility
        {
            get => _dashBoardModel.ButtonCloseMenuVisibility;
            set
            {
                _dashBoardModel.ButtonCloseMenuVisibility = value;
                OnPropertyChanged(nameof(ButtonCloseMenuVisibility));
            }
        }

        private ICommand _closeWindow;
        public ICommand  CloseWindow
        {
            get
            {
                return _closeWindow ?? (_closeWindow = new RelayCommand(
                    () => { Messenger.Default.Send("", "closeWindow"); }));
            }
            set => _closeWindow = value;
        }

        private ICommand _openMenu;
        public ICommand OpenMenu
        {
            get
            {
                return _openMenu ?? (_openMenu = new RelayCommand(
                    () => { Messenger.Default.Send("", "openMenu"); }));
            }
            set => _openMenu = value;
        }
        
        private ICommand _closenMenu;
        public ICommand CloseMenu
        {
            get
            {
                return _closenMenu ?? (_closenMenu = new RelayCommand(
                    () => { Messenger.Default.Send("", "closeMenu"); }));
            }
            set => _closenMenu = value;
        }
    }
}