using System.Collections.ObjectModel;
using MyApp.SHIS.Models;

namespace MyApp.SHIS.ViewModel.PagesViewModels.OrderListPage
{
    public class OrderListPageModel
    {
        public OrderListPageModel()
        {
            Orders = new ObservableCollection<order>();
        }

        public int? MedCardNum { get; set; }
        public string DoctDept { get; set; }
        public string DoctName { get; set; }
        public order SelectedOrder { get; set; }
        public ObservableCollection<order> Orders { get; set; }
    }
}