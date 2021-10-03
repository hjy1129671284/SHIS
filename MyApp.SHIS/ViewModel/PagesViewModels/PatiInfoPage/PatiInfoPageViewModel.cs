using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using GalaSoft.MvvmLight.CommandWpf;
using MyApp.SHIS.Repository.Repository;
using MyApp.SHIS.Services.Services;
using MyApp.SHIS.ViewModel.Common;

namespace MyApp.SHIS.ViewModel.PagesViewModels.PatiInfoPage
{
    public class PatiInfoPageViewModel : NotificationObject
    {
        private readonly PatiInfoPageModel _patiInfoPageModel = new PatiInfoPageModel();

        private ICommand _patiInfoCommand;
        private ICommand _patiInfoChangeCommand;
        private ICommand _idCardTypeSelectChange;
        private ICommand _idCardTypeSelect;
        
        #region 属性

        public int? PatiUserMedCardNum
        { 
            get => _patiInfoPageModel.PatiUserMedCardNum;
            set
            {
                _patiInfoPageModel.PatiUserMedCardNum = value;
                OnPropertyChanged(nameof(PatiUserMedCardNum));
            }
        }
        public string PatiIDCardNum
        { 
            get => _patiInfoPageModel.PatiIDCardNum;
            set
            {
                _patiInfoPageModel.PatiIDCardNum = value;
                OnPropertyChanged(nameof(PatiIDCardNum));
            }
        }
        public string PatiAuthName
        { 
            get => _patiInfoPageModel.PatiAuthName;
            set
            {
                _patiInfoPageModel.PatiAuthName = value;
                OnPropertyChanged(nameof(PatiAuthName));
            }
        }
        public string PatiMobileNum
        { 
            get => _patiInfoPageModel.PatiMobileNum;
            set
            {
                _patiInfoPageModel.PatiMobileNum = value;
                OnPropertyChanged(nameof(PatiMobileNum));
            }
        }

        public string IDCardText
        {
            get => _patiInfoPageModel.IDCardText;
            set
            {
                _patiInfoPageModel.IDCardText = value;
                OnPropertyChanged(nameof(IDCardText));
            }
        }

        public string PatiIDCardText
        {
            get => _patiInfoPageModel.PatiIDCardText;
            set
            {
                _patiInfoPageModel.PatiIDCardText = value;
                OnPropertyChanged(nameof(PatiIDCardText));
            }
        }
        public ComboBoxItem PatiGender
        { 
            get => _patiInfoPageModel.PatiGender;
            set
            {
                _patiInfoPageModel.PatiGender = value;
                OnPropertyChanged(nameof(PatiGender));
            }
        }
        public ComboBoxItem PatiIdCardType
        { 
            get => _patiInfoPageModel.PatiIdCardType;
            set
            {
                _patiInfoPageModel.PatiIdCardType = value;
                OnPropertyChanged(nameof(PatiIdCardType));
            }
        }
        public ComboBoxItem PatiMarriedType
        { 
            get => _patiInfoPageModel.PatiMarriedType;
            set
            {
                _patiInfoPageModel.PatiMarriedType = value;
                OnPropertyChanged(nameof(PatiMarriedType));
            }
        }
        public ComboBoxItem PatiNationality
        { 
            get => _patiInfoPageModel.PatiNationality;
            set
            {
                _patiInfoPageModel.PatiNationality = value;
                OnPropertyChanged(nameof(PatiNationality));
            }
        }
        public ComboBoxItem PatiCountry
        { 
            get => _patiInfoPageModel.PatiCountry;
            set
            {
                _patiInfoPageModel.PatiCountry = value;
                OnPropertyChanged(nameof(PatiCountry));
            }
        }
        public ComboBoxItem PatiOccupation
        { 
            get => _patiInfoPageModel.PatiOccupation;
            set
            {
                _patiInfoPageModel.PatiOccupation = value;
                OnPropertyChanged(nameof(PatiOccupation));
            }
        }
        public ComboBoxItem PatiNativePlace
        { 
            get => _patiInfoPageModel.PatiNativePlace;
            set
            {
                _patiInfoPageModel.PatiNativePlace = value;
                OnPropertyChanged(nameof(PatiNativePlace));
            }
        }
        public DateTime? PatiBirthDate
        { 
            get => _patiInfoPageModel.PatiBirthDate;
            set
            {
                _patiInfoPageModel.PatiBirthDate = value;
                OnPropertyChanged(nameof(PatiBirthDate));
            }
        }
        public decimal PatiRegistryPay
        { 
            get => _patiInfoPageModel.PatiRegistryPay;
            set
            {
                _patiInfoPageModel.PatiRegistryPay = value;
                OnPropertyChanged(nameof(PatiRegistryPay));
            }
        }

        public Visibility IDCardComBoxVisibility
        {
            get => _patiInfoPageModel.IDCardComBoxVisibility;
            set
            {
                _patiInfoPageModel.IDCardComBoxVisibility = value;
                OnPropertyChanged(nameof(IDCardComBoxVisibility));
            }
        }

        public Visibility IDCardTextBoxVisibility
        {
            get => _patiInfoPageModel.IDCardTextBoxVisibility;
            set
            {
                _patiInfoPageModel.IDCardTextBoxVisibility = value;
                OnPropertyChanged(nameof(IDCardTextBoxVisibility));
            }
        }
        
        // Hint
        public string PatiUserMedCardNumHint
        { 
            get => _patiInfoPageModel.PatiUserMedCardNumHint;
            set
            {
                _patiInfoPageModel.PatiUserMedCardNumHint = value;
                OnPropertyChanged(nameof(PatiUserMedCardNumHint));
            }
        }
        public string PatiIDCardNumHint
        { 
            get => _patiInfoPageModel.PatiIDCardNumHint;
            set
            {
                _patiInfoPageModel.PatiIDCardNumHint = value;
                OnPropertyChanged(nameof(PatiIDCardNumHint));
            }
        }
        public string PatiAuthNameHint
        { 
            get => _patiInfoPageModel.PatiAuthNameHint;
            set
            {
                _patiInfoPageModel.PatiAuthNameHint = value; 
                OnPropertyChanged(nameof(PatiAuthNameHint));
            }
        }
        public string PatiMobileNumHint
        { 
            get => _patiInfoPageModel.PatiMobileNumHint;
            set
            {
                _patiInfoPageModel.PatiMobileNumHint = value;
                OnPropertyChanged(nameof(PatiMobileNumHint));
            }
        }
        public string PatiGenderHint
        { 
            get => _patiInfoPageModel.PatiGenderHint;
            set
            {
                _patiInfoPageModel.PatiGenderHint = value; 
                OnPropertyChanged(nameof(PatiGenderHint));
            }
        }
        public string PatiIdCardTypeHint
        { 
            get => _patiInfoPageModel.PatiIdCardTypeHint;
            set
            {
                _patiInfoPageModel.PatiIdCardTypeHint = value;
                OnPropertyChanged(nameof(PatiIdCardTypeHint));
            }
        }
        public string PatiMarriedTypeHint
        { 
            get => _patiInfoPageModel.PatiMarriedTypeHint;
            set
            {
                _patiInfoPageModel.PatiMarriedTypeHint = value;
                OnPropertyChanged(nameof(PatiMarriedTypeHint));
            }
        }
        public string PatiNationalityHint
        { 
            get => _patiInfoPageModel.PatiNationalityHint;
            set
            {
                _patiInfoPageModel.PatiNationalityHint = value;
                OnPropertyChanged(nameof(PatiNationalityHint));
            }
        }
        public string PatiCountryHint
        { 
            get => _patiInfoPageModel.PatiCountryHint;
            set
            {
                _patiInfoPageModel.PatiCountryHint = value;
                OnPropertyChanged(nameof(PatiCountryHint));
            }
        }
        public string PatiOccupationHint
        { 
            get => _patiInfoPageModel.PatiOccupationHint;
            set
            {
                _patiInfoPageModel.PatiOccupationHint = value;
                OnPropertyChanged(nameof(PatiOccupationHint));
            }
        }
        public string PatiNativePlaceHint
        { 
            get => _patiInfoPageModel.PatiNativePlaceHint;
            set
            {
                _patiInfoPageModel.PatiNativePlaceHint = value;
                OnPropertyChanged(nameof(PatiNativePlaceHint));
            }
        }
        public string PatiBirthDateHint
        { 
            get => _patiInfoPageModel.PatiBirthDateHint;
            set
            {
                _patiInfoPageModel.PatiBirthDateHint = value;
                OnPropertyChanged(nameof(PatiBirthDateHint));
            }
        }
        public string PatiRegistryPayHint
        { 
            get => _patiInfoPageModel.PatiRegistryPayHint;
            set
            {
                _patiInfoPageModel.PatiRegistryPayHint = value;
                OnPropertyChanged(nameof(PatiRegistryPayHint));
            }
        }
        
        public Brush IDCardTextColor
        {
            get => _patiInfoPageModel.IDCardTextColor;
            set
            {
                _patiInfoPageModel.IDCardTextColor = value;
                OnPropertyChanged(nameof(IDCardTextColor));
            }
        }

        #endregion

        #region 命令

        public ICommand PatiInfoCommand
        {
            get =>  _patiInfoCommand ?? (_patiInfoCommand = new RelayCommand(GetInfo));
            set => _patiInfoCommand = value;
        }

        public ICommand PatiInfoChangeCommand
        {
            get =>  _patiInfoChangeCommand ?? (_patiInfoChangeCommand = new RelayCommand(SetInfo));
            set => _patiInfoChangeCommand = value;
        }

        
        public ICommand IDCardTypeSelectChange
        {
            get
            {
                return _idCardTypeSelectChange ?? (_idCardTypeSelectChange = new RelayCommand(
                    () =>
                    {
                        if (_patiInfoPageModel.PatiIdCardType != null)
                        {
                            if (_patiInfoPageModel.PatiIdCardType.Content.ToString() == "其他证件类型")
                            {
                                IDCardTextColor = new SolidColorBrush(Colors.Aqua);
                                IDCardText = "返回选择";
                                IDCardComBoxVisibility = Visibility.Collapsed;
                                IDCardTextBoxVisibility = Visibility.Visible;
                            }
                        }
                    }
                ));
            }
            set => _idCardTypeSelectChange = value;
        }
        
        public ICommand IDCardTypeSelect
        {
            get
            {
                return _idCardTypeSelect ?? (_idCardTypeSelect= new RelayCommand(
                    () =>
                    {
                        IDCardTextColor = new SolidColorBrush(Colors.Black);
                        IDCardText = "证件类型";
                        IDCardComBoxVisibility = Visibility.Visible;
                        IDCardTextBoxVisibility = Visibility.Collapsed;
                    }
                ));
            }
            set => _idCardTypeSelect = value;
        }
        #endregion

        #region 命令方法

        // 根据医疗卡号获取病人信息
        public async void GetInfo()
        {
            // 检测就诊卡号是否填写
            if(_patiInfoPageModel.PatiUserMedCardNum != null)
            {
                PatiUserService patiUserService = new PatiUserService(new PatiUserRepository());

                var patiResult = await patiUserService.QueryAsync(it => it.MedCardNum == _patiInfoPageModel.PatiUserMedCardNum);
                if (patiResult != null && patiResult.Count > 0)
                {
                    var patiUser = patiResult[0];
                    PatiAuthNameHint = patiUser.UserAuthName;
                }
                else
                    MessageBox.Show("没能查询到该医疗卡信息");
            }
            else
                MessageBox.Show("请输入医疗卡号");


        }
        
        // 根据挂号员填写内容修改病人信息
        public async void SetInfo()
        {
            
        }
        

        #endregion
    }
}