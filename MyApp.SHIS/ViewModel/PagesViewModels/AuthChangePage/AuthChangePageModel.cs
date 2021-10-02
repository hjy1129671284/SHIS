using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using MyApp.SHIS.Models;

namespace MyApp.SHIS.ViewModel.PagesViewModels.AuthChangePage
{
    public class AuthChangePageModel
    {
        public AuthChangePageModel()
        {
            UserList = new ObservableCollection<user>();
        }
        public string UserName { get; set; }
        public int NewUserType { get; set; }
        public ComboBoxItem UserType { get; set; }
        public ObservableCollection<user> UserList { get; set; }
        public Visibility PatiVisibility { get; set; }
        public int? MedCardNum { get; set; }
        public int? MedCardNumHint { get; set; }
        public ComboBoxItem SecretGradeID { get; set; }
        public string SecretGradeIDHint { get; set; }
        public bool PatiIsExist { get; set; }
        public Visibility StaffVisibility { get; set; }
        public int? StaffUserID { get; set; }
        public string StaffUserIDHint { get; set; }
        public string StaffAuthName { get; set; }
        public string StaffAuthNameHint { get; set; }
        public ComboBoxItem StaffType { get; set; }
        public string StaffTypeHint { get; set; }
        public bool StaffIsExist { get; set; }
        public Visibility DoctVisibility { get; set; }
        public string DoctDept { get; set; }
        public string DoctDeptHint { get; set; }
        public string DoctPosn { get; set; }
        public string DoctPosnHint { get; set; }
        public bool DoctIsExist { get; set; }

    }


}