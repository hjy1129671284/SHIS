namespace MyApp.SHIS.ViewModel.PagesViewModels.OrderExecPage
{
    public class OrderExecPagemodel
    {
        public int? OrderID{ get; set; }
        public int? MedicineAmount{ get; set; }
        public string PatiAuthName{ get; set; }
        public string DoctDept{ get; set; }
        public string DoctName{ get; set; }
        public string MedicineName{ get; set; }
        public string MedicineSpec{ get; set; }
        public string MedicineUse{ get; set; }
        public string DoctDiagnosis { get; set; }
        public string Note { get; set; }
        public decimal MedicinePrice{ get; set; }
        public decimal MedicineTotalPrice{ get; set; }
        public bool OrderIDIsEnable { get; set; }
    }
}