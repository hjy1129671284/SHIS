using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        
        public ComboBoxItem UserType { get; set; }
        
        public ObservableCollection<user> UserList { get; set; }
        
    }


}