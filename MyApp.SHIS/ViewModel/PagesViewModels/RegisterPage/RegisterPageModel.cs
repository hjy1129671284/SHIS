using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace MyApp.SHIS.ViewModel.PagesViewModels.RegisterPage
{
    public class RegisterPageModel
    {
        public int PatiMedCardNum{ get; set; }
        public int PatiAge{ get; set; }
        public int SerialNumber{ get; set; }
        public int QueueNo{ get; set; }
        public bool PatiMedCardNumIsEnable { get; set; }
        public List<string> DoctDepts { get; set; }
        public List<string> DoctNames { get; set; }
        public string PatiAuthName{ get; set; }
        public string PatiGender{ get; set; }
        public string DoctDept{ get; set; }
        public string DoctName{ get; set; }
        public DateTime? RegDate{ get; set; }
        public DateTime? ValidDate{ get; set; }
        public decimal Totalpay{ get; set; }
        
        // Hint
        public string DoctDeptHint{ get; set; }
        public string VaildDateHint{ get; set; }
        public string DoctIDHint{ get; set; }
        public string TotalpayHint{ get; set; }
    }
}