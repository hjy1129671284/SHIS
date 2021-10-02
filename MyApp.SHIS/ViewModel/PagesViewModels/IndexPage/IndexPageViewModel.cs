using MyApp.SHIS.ViewModel.Common;

namespace MyApp.SHIS.ViewModel.PagesViewModels.IndexPage
{
    public class IndexPageViewModel : NotificationObject
    {
        private readonly IndexPageModel _indexPageModel = new IndexPageModel();

        public int NumOfPeople
        {
            get => _indexPageModel.NumOfPeople;
            set
            {
                _indexPageModel.NumOfPeople = value;
                OnPropertyChanged(nameof(NumOfPeople));
            }
        }
    }
}