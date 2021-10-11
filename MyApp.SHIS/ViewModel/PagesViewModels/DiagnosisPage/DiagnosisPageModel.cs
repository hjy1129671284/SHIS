namespace MyApp.SHIS.ViewModel.PagesViewModels.DiagnosisPage
{
    public class DiagnosisPageModel
    {
        
        public int? SerialNumber{ get; set; }
        public int? MedCardNum{ get; set; }
        public int? PatiAge{ get; set; }
        public string PatiAuthName{ get; set; }
        public string DoctDiagnosis{ get; set; }
        public string MedRecord{ get; set; }
        public bool SerialNumberIsEnable { get; set; }
    }
}