using System.Windows.Controls;
using MyApp.SHIS.ViewModel.PagesViewModels.UnRegisterPage;

namespace MyApp.SHIS.View.Pages
{
    public partial class UnRegisterPage : Page
    {
        private readonly UnRegisterPageViewModel _unRegisterPageViewModel = new UnRegisterPageViewModel();
        public UnRegisterPage()
        {
            InitializeComponent();
            this.DataContext = _unRegisterPageViewModel;
        }
    }
}