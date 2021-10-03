using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MyApp.SHIS.ViewModel.PagesViewModels.PatiInfoPage;

namespace MyApp.SHIS.View.Pages
{
    public partial class PatiInfoPage : Page
    {
        private readonly PatiInfoPageViewModel _patiInfoPageViewModel = new PatiInfoPageViewModel();
        public PatiInfoPage()
        {
            InitializeComponent();
            this.DataContext = _patiInfoPageViewModel;
            
            _patiInfoPageViewModel.IDCardComBoxVisibility = Visibility.Visible;
            _patiInfoPageViewModel.IDCardTextBoxVisibility = Visibility.Collapsed;
            _patiInfoPageViewModel.IDCardText = "证件类型";
            _patiInfoPageViewModel.IDCardTextColor = new SolidColorBrush(Colors.Black);
            
            
        }
    }
}