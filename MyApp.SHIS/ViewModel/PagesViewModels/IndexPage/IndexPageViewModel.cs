using System;
using MyApp.SHIS.Repository.Repository;
using MyApp.SHIS.Services.Services;
using MyApp.SHIS.ViewModel.Common;

namespace MyApp.SHIS.ViewModel.PagesViewModels.IndexPage
{
    public class IndexPageViewModel : NotificationObject
    {
        private readonly IndexPageModel _indexPageModel = new IndexPageModel();

        public IndexPageViewModel()
        {
            CalNum();
        }

        public int NumOfPeople
        {
            get => _indexPageModel.NumOfPeople;
            set
            {
                _indexPageModel.NumOfPeople = value;
                OnPropertyChanged(nameof(NumOfPeople));
            }
        }

        public async void CalNum()
        {
            PatiOutVisitService patiOutVisitService = new PatiOutVisitService(new PatiOutVisitRepository());
            var patiOutVisitResult = await patiOutVisitService.QueryAsync(it => it.VaildDate.Date == DateTime.Now.Date);
            
            patiOutVisitResult.ForEach(
                it =>
                {
                    if (it.OutStatus == 0 || it.OutStatus == 1)
                        NumOfPeople += 1;
                });
            
        }
        
    }
}