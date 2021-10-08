using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace MyApp.SHIS.ViewModel.PagesViewModels.RegisterPage
{
    public class RegisterPageModel
    {
        public int? PatiMedCardNum{ get; set; }
        public int? PatiAge{ get; set; }
        public int? QueueNo{ get; set; }
        public bool PatiMedCardNumIsEnable { get; set; }
        public ObservableCollection<string> DoctDepts { get; set; }
        public ObservableCollection<string> DoctNames { get; set; }
        public ObservableCollection<string> SerialNumbers { get; set; }
        public string PatiAuthName{ get; set; }
        public string PatiGender{ get; set; }
        public string SerialNumber{ get; set; }
        public string DoctDept{ get; set; }
        public string DoctName{ get; set; }
        public DateTime? RegDate{ get; set; }
        public DateTime? ValidDate{ get; set; }
        public decimal TotalFee{ get; set; }
        public decimal RecvFee{ get; set; }
        public ComboBoxItem PayType { get; set; }

        // Hint
        public int? PatiMedCardNumHint{ get; set; }
        public string DoctDeptHint{ get; set; }
        public string VaildDateHint{ get; set; }
        public string DoctIDHint{ get; set; }
        public string PayTypeHint { get; set; }

    }
}