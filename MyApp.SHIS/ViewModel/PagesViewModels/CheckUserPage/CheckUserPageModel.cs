using System.Collections.ObjectModel;
using System.Windows;
using MyApp.SHIS.Models;

namespace MyApp.SHIS.ViewModel.PagesViewModels.CheckUserPage
{
    public class CheckUserPageModel
    {
        public CheckUserPageModel()
        {
            Users = new ObservableCollection<user>();
            NormUsers = new ObservableCollection<norm_user>();
            PatiUsers = new ObservableCollection<pati_user>();
            StaffUsers = new ObservableCollection<staff_user>();
            DoctUsers = new ObservableCollection<doct_user>();
        }
        
        public Visibility UsersGridVisibility { get; set; }
        public Visibility NormUsersGridVisibility { get; set; }
        public Visibility PatiUsersGridVisibility { get; set; }
        public Visibility StaffUsersGridVisibility { get; set; }
        public Visibility DoctUsersGridVisibility { get; set; }
        public ObservableCollection<user> Users { get; set; }
        public ObservableCollection<norm_user> NormUsers { get; set; }
        public ObservableCollection<pati_user> PatiUsers { get; set; }
        public ObservableCollection<staff_user> StaffUsers { get; set; }
        public ObservableCollection<doct_user> DoctUsers { get; set; }
    }
}