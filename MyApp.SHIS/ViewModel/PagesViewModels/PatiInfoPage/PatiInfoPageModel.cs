using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MyApp.SHIS.ViewModel.PagesViewModels.PatiInfoPage
{
    public class PatiInfoPageModel
    {
        
        public int? PatiUserMedCardNum{ get; set; }
        public bool PatiMedCardNumIsEnable { get; set; }
        public string PatiIDCardNum{ get; set; }
        public string PatiAuthName{ get; set; }
        public string PatiMobileNum{ get; set; }
        public string IDCardText{ get; set; }
        public string PatiIDCardText{ get; set; }
        public string PatiCountry{ get; set; }
        public ComboBoxItem PatiGender{ get; set; }
        public ComboBoxItem PatiIdCardType{ get; set; }
        public ComboBoxItem PatiMarriedType{ get; set; }
        public ComboBoxItem PatiNationality{ get; set; }
        public ComboBoxItem PatiOccupation{ get; set; }
        public ComboBoxItem PatiNativePlace{ get; set; }
        public DateTime? PatiBirthDate{ get; set; }
        public decimal PatiRegistryPay{ get; set; }
        public Brush IDCardTextColor { get; set; }
        public Visibility IDCardComBoxVisibility { get; set; }
        public Visibility IDCardTextBoxVisibility { get; set; }

        // Hint
        public string PatiUserMedCardNumHint{ get; set; }
        public string PatiIDCardNumHint{ get; set; }
        public string PatiAuthNameHint{ get; set; }
        public string PatiMobileNumHint{ get; set; }
        public string PatiGenderHint{ get; set; }
        public string PatiIdCardTypeHint{ get; set; }
        public string PatiMarriedTypeHint{ get; set; }
        public string PatiNationalityHint{ get; set; }
        public string PatiCountryHint{ get; set; }
        public string PatiOccupationHint{ get; set; }
        public string PatiNativePlaceHint{ get; set; }
        public string PatiBirthDateHint{ get; set; }
        public string PatiRegistryPayHint{ get; set; }
        

    }
}