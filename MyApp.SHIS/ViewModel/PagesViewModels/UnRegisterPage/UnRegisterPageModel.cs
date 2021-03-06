using System.Collections.ObjectModel;
using System.Windows.Controls;
using MyApp.SHIS.Models;

namespace MyApp.SHIS.ViewModel.PagesViewModels.UnRegisterPage
{
    public class UnRegisterPageModel
    {
        public UnRegisterPageModel()
        {
            RegisterInfo = new ObservableCollection<pati_out_visit>();
        }
        
        public int? SerialNumber{ get; set; }
        public int? MedCardNum{ get; set; }
        public string PatiAuthName{ get; set; }
        public string DoctAuthName{ get; set; }
        public decimal PayAmount{ get; set; }
        public decimal RefundPay{ get; set; }
        public ComboBoxItem RefundType { get; set; }
        public ObservableCollection<pati_out_visit> RegisterInfo{ get; set; }
        public pati_out_visit SelectedPatiOutVisit { get; set; }
        
        // Hint
        public string SerialNumberHint{ get; set; }
        public string MedCardNumHint{ get; set; }
        public string PatiAuthNameHint{ get; set; }
        public string DoctAuthNameHint{ get; set; }
        public string RefundTypeHint { get; set; }

    }
}