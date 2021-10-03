using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MyApp.SHIS.ViewModel.PagesViewModels.MyAccountPage
{
    public class MyAccountPageModel
    {
        public string UserName { get; set; }
        public int? Age { get; set; }
        public int? AgeHint { get; set; }
        public string Gender { get; set; }
        public string GenderHint { get; set; }
        public string IDCardText { get; set; }
        public Brush IDCardTextColor { get; set; }
        public ComboBoxItem IDCardType { get; set; }
        public string IDCardTypeText { get; set; }
        public string IDCardTypeHint { get; set; }
        public string IDCard { get; set; }
        public string IDCardHint { get; set; }
        public string AuthType { get; set; }
        public string AuthTypeText { get; set; }
        public bool IsAuth { get; set; }
        public string AuthTypeHint { get; set; }
        public string AuthButton { get; set; }
        public ComboBoxItem AuthMethod { get; set; }
        public string AuthMethodHint { get; set; }
        public string AuthName { get; set; }
        public string AuthNameHint { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? BirthDateHint { get; set; }
        public string MobileNum { get; set; }
        public string MobileNumHint { get; set; }
        public string UserEmail { get; set; }
        public string UserEmailHint { get; set; }
        public ComboBoxItem OccupationName { get; set; }
        public string OccupationNameHint { get; set; }
        public string RegiLoc { get; set; }
        public string RegiLocHint { get; set; }
        public ComboBoxItem Married { get; set; }
        public string MarriedHint { get; set; }
        public ComboBoxItem RetireType { get; set; }
        public int? RetireTypeHint { get; set; }
        public string Country { get; set; }
        public string CountryHint { get; set; }
        public ComboBoxItem Nationality { get; set; }
        public string NationalityHint { get; set; }
        public string NativePlace { get; set; }
        public string NativePlaceHint { get; set; }
        public string RegiLocPostCode { get; set; }
        public string RegiLocPostCodeHint { get; set; }
        public ComboBoxItem BloodType { get; set; }
        public string BloodTypeHint { get; set; }
        public int? MedCardNum { get; set; }
        public int? MedCardNumHint { get; set; }
        public Visibility IDCardComBoxVisibility { get; set; }
        public Visibility IDCardTextBoxVisibility { get; set; }
    }
}