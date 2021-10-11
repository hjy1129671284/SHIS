using System.Collections.ObjectModel;
using MyApp.SHIS.Models;

namespace MyApp.SHIS.ViewModel.PagesViewModels.PatiAdmissionPage
{
    public class PatiAdmissionPageModel
    {
        public PatiAdmissionPageModel()
        {
            PatiOutVisits = new ObservableCollection<pati_out_visit>();
        }
        public ObservableCollection<pati_out_visit> PatiOutVisits { get; set; }
        public pati_out_visit PatiOutVisit { get; set; }
    }
}