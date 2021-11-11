using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using MyApp.SHIS.Models;
using MyApp.SHIS.Repository.Repository;
using MyApp.SHIS.Services.Services;
using MyApp.SHIS.ViewModel.Common;

namespace MyApp.SHIS.ViewModel.PagesViewModels.CheckUserPage
{
    public class CheckUserPageViewModel : NotificationObject
    {
        private readonly CheckUserPageModel _checkUserPageModel = new CheckUserPageModel();

        public CheckUserPageViewModel()
        {
            _checkUserPageModel.UsersGridVisibility = Visibility.Collapsed;
            _checkUserPageModel.DoctUsersGridVisibility = Visibility.Collapsed;
            _checkUserPageModel.NormUsersGridVisibility = Visibility.Collapsed;
            _checkUserPageModel.PatiUsersGridVisibility = Visibility.Collapsed;
            _checkUserPageModel.StaffUsersGridVisibility = Visibility.Collapsed;
        }

        private ICommand _allUser;
        private ICommand _normUser;
        private ICommand _staffUser;
        private ICommand _patiUser;
        private ICommand _doctUser;
        private ICommand _phstUser;
        private ICommand _rgstUser;
        private ICommand _tollUser;
        private ICommand _nurseUser;


        #region 属性

        public Visibility UsersGridVisibility
        {
            get => _checkUserPageModel.UsersGridVisibility;
            set
            {
                _checkUserPageModel.UsersGridVisibility = value;
                OnPropertyChanged(nameof(UsersGridVisibility));
            }
        }
        
        public Visibility NormUsersGridVisibility
        {
            get => _checkUserPageModel.NormUsersGridVisibility;
            set
            {
                _checkUserPageModel.NormUsersGridVisibility = value;
                OnPropertyChanged(nameof(NormUsersGridVisibility));
            }
        }

        public Visibility PatiUsersGridVisibility
        {
            get => _checkUserPageModel.PatiUsersGridVisibility;
            set
            {
                _checkUserPageModel.PatiUsersGridVisibility = value;
                OnPropertyChanged(nameof(PatiUsersGridVisibility));
            }
        }

        public Visibility StaffUsersGridVisibility
        {
            get => _checkUserPageModel.StaffUsersGridVisibility;
            set
            {
                _checkUserPageModel.StaffUsersGridVisibility = value;
                OnPropertyChanged(nameof(StaffUsersGridVisibility));
            }
        }

        public Visibility DoctUsersGridVisibility
        {
            get => _checkUserPageModel.DoctUsersGridVisibility;
            set
            {
                _checkUserPageModel.DoctUsersGridVisibility = value;
                OnPropertyChanged(nameof(DoctUsersGridVisibility));
            }
        }

        public ObservableCollection<user> Users
        {
            get => _checkUserPageModel.Users;
            set
            {
                _checkUserPageModel.Users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        public ObservableCollection<norm_user> NormUsers
        {
            get => _checkUserPageModel.NormUsers;
            set
            {
                _checkUserPageModel.NormUsers = value;
                OnPropertyChanged(nameof(NormUsers));
            }
        }

        public ObservableCollection<pati_user> PatiUsers
        {
            get => _checkUserPageModel.PatiUsers;
            set
            {
                _checkUserPageModel.PatiUsers = value;
                OnPropertyChanged(nameof(PatiUsers));
            }
        }

        public ObservableCollection<staff_user> StaffUsers
        {
            get => _checkUserPageModel.StaffUsers;
            set
            {
                _checkUserPageModel.StaffUsers = value;
                OnPropertyChanged(nameof(StaffUsers));
            }
        }

        public ObservableCollection<doct_user> DoctUsers
        {
            get => _checkUserPageModel.DoctUsers;
            set
            {
                _checkUserPageModel.DoctUsers = value;
                OnPropertyChanged(nameof(DoctUsers));
            }
        }

        #endregion


        #region 命令

        public ICommand AllUser
        {
            get => _allUser ?? (_allUser = new RelayCommand(FindAllUser));
            set => _allUser = value;
        }

        public ICommand NormUser
        {
            get => _normUser ?? (_normUser = new RelayCommand(FindNormUser));
            set => _normUser = value;
        }

        public ICommand StaffUser
        {
            get => _staffUser ?? ( _staffUser = new RelayCommand(FindStaffUser));
            set => _staffUser = value;
        }

        public ICommand PatiUser
        {
            get => _patiUser ?? (_patiUser = new RelayCommand(FindPatiUser));
            set => _patiUser = value;
        }

        public ICommand DoctUser
        {
            get => _doctUser ?? (_doctUser = new RelayCommand(FindDoctUser));
            set => _doctUser = value;
        }

        public ICommand PhstUser
        {
            get => _phstUser ?? (_phstUser = new RelayCommand(FindPhstUser));
            set => _phstUser = value;
        }

        public ICommand RgstUser
        {
            get => _rgstUser ?? (_rgstUser = new RelayCommand(FindRgstUser));
            set => _rgstUser = value;
        }

        public ICommand TollUser
        {
            get => _tollUser ?? (_tollUser = new RelayCommand(FindTollUser));
            set => _tollUser = value;
        }

        public ICommand NurseUser
        {
            get => _nurseUser ?? (_nurseUser = new RelayCommand(FindNurseUser));
            set => _nurseUser = value;
        }

        #endregion

        #region 命令方法

        public async void FindAllUser()
        {
            Users.Clear();
            UsersGridVisibility = Visibility.Visible;
            DoctUsersGridVisibility = Visibility.Collapsed;
            NormUsersGridVisibility = Visibility.Collapsed;
            PatiUsersGridVisibility = Visibility.Collapsed;
            StaffUsersGridVisibility = Visibility.Collapsed;

            UserService userService = new UserService(new UserRepository());
            var result = await userService.QueryAsync();
            result.ForEach(user => Users.Add(user));
        }
        
        public async void FindNormUser()
        {
            NormUsers.Clear();
            UsersGridVisibility = Visibility.Collapsed;
            DoctUsersGridVisibility = Visibility.Collapsed;
            NormUsersGridVisibility = Visibility.Visible;
            PatiUsersGridVisibility = Visibility.Collapsed;
            StaffUsersGridVisibility = Visibility.Collapsed;

            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = await normUserService.QueryAsync();
            result.ForEach(user => NormUsers.Add(user));
        }
        
        public async void FindStaffUser()
        {
            StaffUsers.Clear();
            UsersGridVisibility = Visibility.Collapsed;
            DoctUsersGridVisibility = Visibility.Collapsed;
            NormUsersGridVisibility = Visibility.Collapsed;
            PatiUsersGridVisibility = Visibility.Collapsed;
            StaffUsersGridVisibility = Visibility.Visible;
            
            StaffUserService staffUserService = new StaffUserService(new StaffUserRepository());
            var result = await staffUserService.QueryAsync();
            
            result.ForEach(user => StaffUsers.Add(user));
        }
        
        public async void FindPatiUser()
        {
            PatiUsers.Clear();
            UsersGridVisibility = Visibility.Collapsed;
            DoctUsersGridVisibility = Visibility.Collapsed;
            NormUsersGridVisibility = Visibility.Collapsed;
            PatiUsersGridVisibility = Visibility.Visible;
            StaffUsersGridVisibility = Visibility.Collapsed;

            PatiUserService patiUserService = new PatiUserService(new PatiUserRepository());
            var result = await patiUserService.QueryAsync();

            result.ForEach(user => PatiUsers.Add(user));
        }
        
        public async void FindDoctUser()
        {
            DoctUsers.Clear();
            UsersGridVisibility = Visibility.Collapsed;
            DoctUsersGridVisibility = Visibility.Visible;
            NormUsersGridVisibility = Visibility.Collapsed;
            PatiUsersGridVisibility = Visibility.Collapsed;
            StaffUsersGridVisibility = Visibility.Collapsed;
            
            DoctUserService doctUserService = new DoctUserService(new DoctUserRepository());
            var result = await doctUserService.QueryAsync();
            
            result.ForEach(user => DoctUsers.Add(user));
        }
        
        public async void FindPhstUser()
        {
            StaffUsers.Clear();
            UsersGridVisibility = Visibility.Collapsed;
            DoctUsersGridVisibility = Visibility.Collapsed;
            NormUsersGridVisibility = Visibility.Collapsed;
            PatiUsersGridVisibility = Visibility.Collapsed;
            StaffUsersGridVisibility = Visibility.Visible;

            StaffUserService staffUserService = new StaffUserService(new StaffUserRepository());
            var result = await staffUserService.QueryAsync(it => it.StafType==4);
            result.ForEach(user => StaffUsers.Add(user));
        }
        
        public async void FindRgstUser()
        {
            StaffUsers.Clear();
            UsersGridVisibility = Visibility.Collapsed;
            DoctUsersGridVisibility = Visibility.Collapsed;
            NormUsersGridVisibility = Visibility.Collapsed;
            PatiUsersGridVisibility = Visibility.Collapsed;
            StaffUsersGridVisibility = Visibility.Visible;

            StaffUserService staffUserService = new StaffUserService(new StaffUserRepository());
            var result = await staffUserService.QueryAsync(it => it.StafType==5);
            result.ForEach(user => StaffUsers.Add(user));
        }
        
        public async void FindTollUser()
        {
            StaffUsers.Clear();
            UsersGridVisibility = Visibility.Collapsed;
            DoctUsersGridVisibility = Visibility.Collapsed;
            NormUsersGridVisibility = Visibility.Collapsed;
            PatiUsersGridVisibility = Visibility.Collapsed;
            StaffUsersGridVisibility = Visibility.Visible;

            StaffUserService staffUserService = new StaffUserService(new StaffUserRepository());
            var result = await staffUserService.QueryAsync(it => it.StafType==6);
            result.ForEach(user => StaffUsers.Add(user));
        }
        
        public async void FindNurseUser()
        {
            StaffUsers.Clear();
            UsersGridVisibility = Visibility.Collapsed;
            DoctUsersGridVisibility = Visibility.Collapsed;
            NormUsersGridVisibility = Visibility.Collapsed;
            PatiUsersGridVisibility = Visibility.Collapsed;
            StaffUsersGridVisibility = Visibility.Visible;

            StaffUserService staffUserService = new StaffUserService(new StaffUserRepository());
            var result = await staffUserService.QueryAsync(it => it.StafType==7);
            result.ForEach(user => StaffUsers.Add(user));
        }


    #endregion
    
    }
}