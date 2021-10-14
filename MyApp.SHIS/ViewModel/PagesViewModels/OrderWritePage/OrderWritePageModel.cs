using System.Collections.ObjectModel;
using MyApp.SHIS.Models;

namespace MyApp.SHIS.ViewModel.PagesViewModels.OrderWritePage
{
    public class OrderWritePageModel
    {
        public OrderWritePageModel()
        {
            MedicineNames = new ObservableCollection<string>();
        }
        
        public int? SerialNumber{ get; set; }
        public int? MedCardNum{ get; set; }
        public int? PatiAge{ get; set; }
        public string PatiAuthName{ get; set; }
        public bool SerialNumberIsEnable { get; set; }
        public bool MedicineDropIsOpen { get; set; }
        public string MedicineName{ get; set; }
        public string MedicineInputName{ get; set; }
        public string MedicineSpec{ get; set; }
        public string MedicineUse{ get; set; }
        public decimal MedicinePrice{ get; set; }
        public int? MedicineAmount{ get; set; }
        public decimal TotalPay{ get; set; }
        public ObservableCollection<string> MedicineNames { get; set; }

        // Hint
        public string SerialNumberHint{ get; set; }


    }
    
}