using System.Security.RightsManagement;

namespace MyApp.SHIS.ViewModel.PagesViewModels.SettingPage
{
    public class SettingPageModel
    {
        public string UserName { get; set; }
        public decimal Balance { get; set; }
        public string OldPwd { get; set; }
        public string NewPwd1 { get; set; }
        public string NewPwd2 { get; set; }
    }
}