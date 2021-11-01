using System.Windows.Controls;
using MyApp.SHIS.ViewModel.PagesViewModels.SettingPage;

namespace MyApp.SHIS.View.Pages
{
    public partial class SettingPage : Page
    {
        private readonly SettingPageViewModel _settingPageViewModel;
        public SettingPage(string userName)
        {
            _settingPageViewModel = new SettingPageViewModel(userName);
            InitializeComponent();
            this.DataContext = _settingPageViewModel;
        }
    }
}