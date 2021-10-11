using System.Collections.ObjectModel;
using MyApp.SHIS.Models;

namespace MyApp.SHIS.ViewModel.PagesViewModels.OrderWritePage
{
    public class OrderWritePageModel
    {
        
        public int? SerialNumber{ get; set; }
        public int? MedCardNum{ get; set; }
        public int? PatiAge{ get; set; }
        public string PatiAuthName{ get; set; }
        public bool SerialNumberIsEnable { get; set; }
        public string MedicineName{ get; set; }
        public string MedicineSpec{ get; set; }
        public string MedicineUse{ get; set; }
        public string MedicinePrice{ get; set; }
        public string MedicineAmount{ get; set; }
        public string TotalPay{ get; set; }

    }
    
}