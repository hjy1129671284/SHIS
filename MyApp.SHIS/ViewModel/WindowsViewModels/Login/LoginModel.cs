using System.Windows.Controls;

namespace MyApp.SHIS.ViewModel.WindowsViewModels.Login
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public ListBoxItem UserType { get; set; }
    }
}