using System.Collections.ObjectModel;
using MyApp.SHIS.Models;

namespace MyApp.SHIS.ViewModel.PagesViewModels.OrderChargePage
{
    public class OrderChargePageModel
    {
        public OrderChargePageModel()
        {
            Orders = new ObservableCollection<order>();
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
        public order SelectedOrder { get; set; }
        public ObservableCollection<order> Orders { get; set; }
    }
}