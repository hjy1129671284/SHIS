using System.Threading.Tasks;
using MaterialDesignThemes.Wpf;
using System.Windows;
using System.Windows.Controls;
using MyApp.SHIS.Repository.Repository;
using MyApp.SHIS.Services.Services;

namespace MyApp.SHIS.View.Pages
{
    public partial class MyAccountPage : Page
    {
        public MyAccountPage(string userName)
        {
            
            InitializeComponent();

            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = normUserService.QueryAsync(it => it.UserName == userName).Result;
            if (result != null && result.Count > 0)
            {
                var user = result[0];
                HintAssist.SetHint(UserNameTextBox, user.UserName);
                HintAssist.SetHint(UserSexTextBox, user.UserName);
                HintAssist.SetHint(IDCardTypeTextBox, user.UserName);
                HintAssist.SetHint(IDCardTextBox, user.UserName);
                HintAssist.SetHint(IDAutherTextBox, user.UserName);
                HintAssist.SetHint(IDAutherMethodTextBox, user.UserName);
                HintAssist.SetHint(UserAuthNameTextBox, user.UserName);
                HintAssist.SetHint(BirthDateTextBox, user.UserName);
                HintAssist.SetHint(MobileNumTextBox, user.UserName);
                HintAssist.SetHint(PersonEmailTextBox, user.UserName);
                HintAssist.SetHint(OccupationTextBox, user.UserName);
                HintAssist.SetHint(RegiLocTextBox, user.UserName);
                HintAssist.SetHint(MarriedTextBox, user.UserName);
                HintAssist.SetHint(RetireTypeTextBox, user.UserName);
                HintAssist.SetHint(CountryTextBox, user.UserName);
                HintAssist.SetHint(NationalityTextBox, user.UserName);
                HintAssist.SetHint(NativePlaceTextBox, user.UserName);
                HintAssist.SetHint(RegiLocPostCodeTextBox, user.UserName);
                HintAssist.SetHint(BloodTypeTextBox, user.UserName);
                HintAssist.SetHint(MedCardNumTextBox, user.UserName);
            }
            
        }
        

        private async void UserNameButton_OnClick(object sender, RoutedEventArgs e)
        {
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = await normUserService.QueryAsync(it => it.UserName == UserNameTextBox.Text);
        }
        
    }
}