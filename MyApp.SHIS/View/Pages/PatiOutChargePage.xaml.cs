using System.Windows.Controls;
using MyApp.SHIS.ViewModel.PagesViewModels.PatiOutChargePage;

namespace MyApp.SHIS.View.Pages
{
    public partial class PatiOutChargePage : Page
    {
        private readonly PatiOutChargePageViewModel _patiOutChargePageViewModel;

        public PatiOutChargePage(string userName)
        {
            _patiOutChargePageViewModel = new PatiOutChargePageViewModel(userName);
            InitializeComponent();
            this.DataContext = _patiOutChargePageViewModel;
        }
    }
}