using System.Windows.Controls;
using MyApp.SHIS.ViewModel.PagesViewModels.RegisterPage;

namespace MyApp.SHIS.View.Pages
{
    public partial class RegisterPage : Page
    {
        public RegisterPage(string userName,int? patiMedCardNum = null)
        {
            var registerPageViewModel = new RegisterPageViewModel(userName, patiMedCardNum);
            InitializeComponent();
            this.DataContext = registerPageViewModel;
            
            
        }
        
    }
}