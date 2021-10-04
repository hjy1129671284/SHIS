using System.Windows.Controls;
using MyApp.SHIS.ViewModel.PagesViewModels.RegisterPage;

namespace MyApp.SHIS.View.Pages
{
    public partial class RegisterPage : Page
    {
        public RegisterPage(int? patiMedCardNum = null)
        {
            RegisterPageViewModel registerPageViewModel = new RegisterPageViewModel(patiMedCardNum);
            InitializeComponent();
            this.DataContext = registerPageViewModel;
            
        }
    }
}