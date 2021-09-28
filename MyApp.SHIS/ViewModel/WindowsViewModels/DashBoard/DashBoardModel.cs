using System.Windows;

namespace MyApp.SHIS.ViewModel.WindowsViewModels.DashBoard
{
    public class DashBoardModel
    {

        public string UserType { get; set; }

        public string UserName { get; set; }

        public string UserLoginButtonContent { get; set; }

        public Visibility SettingButtonVisibility { get; set; }

        public Visibility ButtonOpenMenuVisibility { get; set; }
        
        public Visibility ButtonCloseMenuVisibility { get; set; }
        
    }
}