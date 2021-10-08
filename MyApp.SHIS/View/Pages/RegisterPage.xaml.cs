using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using MyApp.SHIS.ViewModel.PagesViewModels.RegisterPage;

namespace MyApp.SHIS.View.Pages
{
    public partial class RegisterPage : Page
    {
        public RegisterPage(int? patiMedCardNum = null)
        {
            var registerPageViewModel = new RegisterPageViewModel(patiMedCardNum);
            InitializeComponent();
            this.DataContext = registerPageViewModel;
            
            
        }
        
    }
}