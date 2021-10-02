using System.Windows.Controls;
using MyApp.SHIS.ViewModel.PagesViewModels.SettingPage;

namespace MyApp.SHIS.View.Pages
{
    public partial class SettingPage : Page
    {
        private readonly SettingPageViewModel _settingPageViewModel = new SettingPageViewModel();
        public SettingPage(string userName)
        {
            InitializeComponent();
            this.DataContext = _settingPageViewModel;
        }
    }
}