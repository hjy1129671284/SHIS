using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
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
        private ICommand _changePati;
        private ICommand _register;
        private ICommand _idCardTypeSelectChange;
        private ICommand _idCardTypeSelect;

        public PatiInfoPageViewModel()
        {
            PatiMedCardNumIsEnable = _patiInfoPageModel.PatiUserMedCardNum == null;
        }
        
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

        public bool PatiMedCardNumIsEnable
        {
            get => _patiInfoPageModel.PatiMedCardNumIsEnable;
            set
            {
                _patiInfoPageModel.PatiMedCardNumIsEnable = value;
                OnPropertyChanged(nameof(PatiMedCardNumIsEnable));
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
        public string PatiCountry
        { 
            get => _patiInfoPageModel.PatiCountry;
            set
            {
                _patiInfoPageModel.PatiCountry = value;
                OnPropertyChanged(nameof(PatiCountry));
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
            get => _patiInfoCommand ?? (_patiInfoCommand = new RelayCommand(GetInfo));
            set => _patiInfoCommand = value;
        }

        public ICommand PatiInfoChangeCommand
        {
            get => _patiInfoChangeCommand ?? (_patiInfoChangeCommand = new RelayCommand(SetInfo));
            set => _patiInfoChangeCommand = value;
        }

        public ICommand ChangePati
        {
            get => _changePati ?? (_changePati = new RelayCommand(ChangePatiInfo));
            set => _changePati = value;
        }

        public ICommand Register
        {
            get => _register ?? (_register = new RelayCommand(
                () =>
                {
                    if (_patiInfoPageModel.PatiUserMedCardNum != null)
                        Messenger.Default.Send<int>((int) _patiInfoPageModel.PatiUserMedCardNum, "patiInfo2Register");
                    else
                        MessageBox.Show("请输入医疗卡号");
                }));
            set => _register = value;
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
               NormUserService normUserService = new NormUserService(new NormUserRepository());

                var patiResult = await normUserService.QueryAsync(it => it.MedCardNum == _patiInfoPageModel.PatiUserMedCardNum);
                if (patiResult != null && patiResult.Count > 0)
                {
                    var patiUser = patiResult[0];
                    PatiAuthNameHint = patiUser.UserAuthName;
                    PatiGenderHint = patiUser.SexName;
                    PatiBirthDateHint = patiUser.BirthDate.ToString();
                    PatiIdCardTypeHint = patiUser.IDCardTypeName;
                    PatiIDCardNumHint = patiUser.IDCard;
                    PatiMobileNumHint = patiUser.MobileNum;
                    switch (patiUser.MarriedID)
                    {
                        case 10: PatiMarriedTypeHint = "未婚"; break;
                        case 20: PatiMarriedTypeHint = "已婚"; break;
                        case 21: PatiMarriedTypeHint = "已婚-初婚"; break;
                        case 22: PatiMarriedTypeHint = "已婚-再婚"; break;
                        case 23: PatiMarriedTypeHint = "已婚-复婚"; break;
                        case 30: PatiMarriedTypeHint = "丧偶"; break;
                        case 40: PatiMarriedTypeHint = "离婚"; break;
                        default: PatiMarriedTypeHint = ""; break;
                    }
                    PatiCountryHint = patiUser.CountryName;
                    PatiNationalityHint = patiUser.NationalityName;
                    PatiOccupationHint = patiUser.OccupationName;

                    PatiMedCardNumIsEnable = false;

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
            int totalNum = 0;
            int editNum = 0;
            
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var normResult =
                await normUserService.QueryAsync(it => it.MedCardNum == _patiInfoPageModel.PatiUserMedCardNum);
            var normUser = normResult[0];
            // 实名信息
            if (!string.IsNullOrEmpty(_patiInfoPageModel.PatiAuthName))
            {
                totalNum += 1;
                normUser.UserAuthName = _patiInfoPageModel.PatiAuthName;
                editNum += await normUserService.EditAsync(normUser) ? 1 : 0;
            }
            // 性别
            if (_patiInfoPageModel.PatiGender != null)
            {
                totalNum += 1;
                editNum += await normUserService.EditGenderAsync(normUser, _patiInfoPageModel.PatiGender.Content.ToString()) ? 1 : 0;
            }
            // 出生日期
            if (_patiInfoPageModel.PatiBirthDate != null)
            {
                totalNum += 1;
                normUser.BirthDate = _patiInfoPageModel.PatiBirthDate;
                editNum += await normUserService.EditAsync(normUser) ? 1 : 0;
            }
            // 证件类型
            if (_patiInfoPageModel.PatiIdCardType != null)
            {
                totalNum += 1;
                editNum += await normUserService.EditIDCardAsync
                (normUser, _patiInfoPageModel.PatiIdCardType.Content.ToString(), _patiInfoPageModel.IDCardText) ? 1 : 0;
            }
            // 证件号
            if (!string.IsNullOrEmpty(_patiInfoPageModel.PatiIDCardNum))
            {
                totalNum += 1;
                normUser.IDCard = _patiInfoPageModel.PatiIDCardNum;
                editNum += await normUserService.EditAsync(normUser) ? 1 : 0;
            }
            // 手机号码
            if (!string.IsNullOrEmpty(_patiInfoPageModel.PatiMobileNum))
            {
                totalNum += 1;
                normUser.MobileNum = _patiInfoPageModel.PatiMobileNum;
                editNum += await normUserService.EditAsync(normUser) ? 1 : 0;
            }
            // 婚姻状态
            if (_patiInfoPageModel.PatiMarriedType != null)
            {
                totalNum += 1;
                switch (_patiInfoPageModel.PatiMarriedType.Content.ToString())
                {
                    case "未婚": normUser.MarriedID = 10; break;
                    case "已婚": normUser.MarriedID = 20; break;
                    case "已婚-初婚": normUser.MarriedID = 21; break;
                    case "已婚-再婚": normUser.MarriedID = 22; break;
                    case "已婚-复婚": normUser.MarriedID = 23; break;
                    case "丧偶": normUser.MarriedID = 30; break;
                    case "离婚": normUser.MarriedID = 40; break;
                    default: normUser.MarriedID = 0; break;
                }
                editNum += await normUserService.EditAsync(normUser) ? 1 : 0;
            }
            // 国籍
            if (string.IsNullOrEmpty(_patiInfoPageModel.PatiCountry))
            {
                totalNum += 1;
                editNum += await normUserService.EditCountryAsync(normUser, _patiInfoPageModel.PatiCountry) ? 1 : 0;
            }
            // 民族
            if (_patiInfoPageModel.PatiNationality != null)
            {
                totalNum += 1;
                editNum += await normUserService.EditNationalityAsync(normUser, _patiInfoPageModel.PatiNationality.Content.ToString()) ? 1 : 0;
            }
            // 职业
            if (_patiInfoPageModel.PatiOccupation != null)
            {
                totalNum += 1;
                editNum += await normUserService.EditNationalityAsync(normUser, _patiInfoPageModel.PatiOccupation.Content.ToString()) ? 1 : 0;
            }


            MessageBox.Show($"一共修改 {totalNum} 项, 其中成功修改 {editNum} 项");
        }

        // 切换下一个病人，医疗卡号hint显示为上一个病人，其他值均置空
        public void ChangePatiInfo()
        { 
            PatiUserMedCardNumHint = PatiUserMedCardNum.ToString();
            
            // hint
            PatiAuthNameHint = null;
            PatiGenderHint = null;
            PatiBirthDateHint = null;
            PatiIdCardTypeHint = null;
            PatiIDCardNumHint = null;
            PatiMobileNumHint = null;
            PatiMarriedTypeHint = null;
            PatiCountryHint = null;
            PatiNationalityHint = null;
            PatiOccupationHint = null;

            // 填写内容
            PatiUserMedCardNum = null;
            PatiAuthName = null;
            PatiGender = null;
            PatiBirthDate = null;
            PatiIdCardType = null;
            PatiIDCardNum = null;
            PatiMobileNum = null;
            PatiMarriedType = null;
            PatiCountry = null;
            PatiNationality = null;
            PatiOccupation = null;

            // 查询病人按钮
            PatiMedCardNumIsEnable = true;
        }

        #endregion
    }
}