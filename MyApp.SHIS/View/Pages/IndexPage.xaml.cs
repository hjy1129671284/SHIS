using System.Windows.Controls;
using MyApp.SHIS.ViewModel.PagesViewModels.IndexPage;

namespace MyApp.SHIS.View.Pages
{
    public partial class IndexPage : Page
    {
        private readonly IndexPageViewModel _indexPageViewModel = new IndexPageViewModel();
        public IndexPage()
        {
            InitializeComponent();
            this.DataContext = _indexPageViewModel;
        }
    }
}