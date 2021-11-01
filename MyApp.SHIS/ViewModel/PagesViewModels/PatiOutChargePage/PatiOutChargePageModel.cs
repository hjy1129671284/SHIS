using System.Collections.ObjectModel;
using MyApp.SHIS.Models;

namespace MyApp.SHIS.ViewModel.PagesViewModels.PatiOutChargePage
{
    public class PatiOutChargePageModel
    {
        public PatiOutChargePageModel()
        {
            PatiOutVisits = new ObservableCollection<pati_out_visit>();
            PayTypes = new ObservableCollection<string> {"现金", "微信", "支付宝", "银联"};
        }

        public int? MedCardNum { get; set; }
        public string DoctDept { get; set; }
        public string DoctName { get; set; }
        public string PatiName { get; set; }
        public ObservableCollection<string> PayTypes { get; set; }
        public string PayType { get; set; }
        public decimal PayAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal ChangeAmount { get; set; }
        public pati_out_visit SelectedPatiOutVisit { get; set; }
        public ObservableCollection<pati_out_visit> PatiOutVisits { get; set; }
    }
}