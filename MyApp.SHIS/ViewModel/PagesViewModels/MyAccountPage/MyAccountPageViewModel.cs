using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MaterialDesignThemes.Wpf;
using MyApp.SHIS.Repository.Repository;
using MyApp.SHIS.Services.Services;
using MyApp.SHIS.ViewModel.Common;

namespace MyApp.SHIS.ViewModel.PagesViewModels.MyAccountPage
{
    public class MyAccountPageViewModel : NotificationObject
    {
        private readonly MyAccountPageModel _myAccountPageModel = new MyAccountPageModel();

        public MyAccountPageViewModel()
        {
            
        }

        #region 命令属性

        private ICommand _ageCommand;
        private ICommand _genderCommand;
        private ICommand _idCardTypeCommand;
        private ICommand _idCardCommand;
        private ICommand _authTypeCommand;
        private ICommand _authMethodCommand;
        private ICommand _authNameCommand;
        private ICommand _birthDateCommand;
        private ICommand _mobileNumCommand;
        private ICommand _userEmailCommand;
        private ICommand _occupationCommand;
        private ICommand _regiLocCommand;
        private ICommand _marriedCommand;
        private ICommand _retireTypeCommand;
        private ICommand _countryCommand;
        private ICommand _nationalityCommand;
        private ICommand _nativePlaceCommand;
        private ICommand _regiLocPostCodeCommand;
        private ICommand _bloodTypeCommand;
        private ICommand _idCardTypeSelectChange;
        private ICommand _idCardTypeSelect;

        #endregion
        
        #region 属性

        public string UserName
        {
            get => _myAccountPageModel.UserName;
            set
            {
                _myAccountPageModel.UserName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }
        

        public int? Age
        {
            get => _myAccountPageModel.Age;
            set
            {
                _myAccountPageModel.Age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        public int? AgeHint
        {
            get => _myAccountPageModel.AgeHint;
            set
            {
                _myAccountPageModel.AgeHint = value;
                OnPropertyChanged(nameof(AgeHint));
            }
        }


        public ComboBoxItem Gender
        {
            get => _myAccountPageModel.Gender;
            set
            {
                _myAccountPageModel.Gender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }
        public string GenderHint
        {
            get => _myAccountPageModel.GenderHint;
            set
            {
                _myAccountPageModel.GenderHint = value;
                OnPropertyChanged(nameof(GenderHint));
            }
        }

        public string IDCardText
        {
            get => _myAccountPageModel.IDCardText;
            set
            {
                _myAccountPageModel.IDCardText = value;
                OnPropertyChanged(nameof(IDCardText));
            }
        }

        public Brush IDCardTextColor
        {
            get => _myAccountPageModel.IDCardTextColor;
            set
            {
                _myAccountPageModel.IDCardTextColor = value;
                OnPropertyChanged(nameof(IDCardTextColor));
            }
        }

        public ComboBoxItem IDCardType
        {
            get => _myAccountPageModel.IDCardType;
            set
            {
                _myAccountPageModel.IDCardType = value;
                OnPropertyChanged(nameof(IDCardType));
            }
        }

        public string IDCardTypeText
        {
            get => _myAccountPageModel.IDCardTypeText;
            set
            {
                _myAccountPageModel.IDCardTypeText = value;
                OnPropertyChanged(nameof(IDCardTypeText));
            }
        }

        public string IDCardTypeTextHint
        {
            get => _myAccountPageModel.IDCardTypeTextHint;
            set
            {
                _myAccountPageModel.IDCardTypeTextHint = value;
                OnPropertyChanged(nameof(IDCardTypeTextHint));
            }
        }


        public string IDCardTypeHint
        {
            get => _myAccountPageModel.IDCardTypeHint;
            set
            {
                _myAccountPageModel.IDCardTypeHint = value;
                OnPropertyChanged(nameof(IDCardTypeHint));
            }
        }

        public string IDCard
        {
            get => _myAccountPageModel.IDCard;
            set
            {
                _myAccountPageModel.IDCard = value;
                OnPropertyChanged(nameof(IDCard));
            }
        }
        public string IDCardHint
        {
            get => _myAccountPageModel.IDCardHint;
            set
            {
                _myAccountPageModel.IDCardHint = value;
                OnPropertyChanged(nameof(IDCardHint));
            }
        }

        public string AuthType
        {
            get => _myAccountPageModel.AuthType;
            set
            {
                _myAccountPageModel.AuthType = value;
                OnPropertyChanged(nameof(AuthType));
            }
        }

        public string AuthTypeText
        {
            get => _myAccountPageModel.AuthTypeText;
            set
            {
                _myAccountPageModel.AuthTypeText = value;
                OnPropertyChanged(nameof(AuthTypeText));
            }
        }

        public bool IsAuth
        {
            get => _myAccountPageModel.IsAuth;
            set
            {
                _myAccountPageModel.IsAuth = value;
                OnPropertyChanged(nameof(IsAuth));
            }
        }
        public string AuthTypeHint
        {
            get => _myAccountPageModel.AuthTypeHint;
            set
            {
                _myAccountPageModel.AuthTypeHint = value;
                OnPropertyChanged(nameof(AuthTypeHint));
            }
        }

        public string AuthButton
        {
            get => _myAccountPageModel.AuthButton;
            set
            {
                _myAccountPageModel.AuthButton = value;
                OnPropertyChanged(nameof(AuthButton));
            }
        }

        public ComboBoxItem AuthMethod
        {
            get => _myAccountPageModel.AuthMethod;
            set
            {
                _myAccountPageModel.AuthMethod = value;
                OnPropertyChanged(nameof(AuthMethod));
            }
        }
        public string AuthMethodHint
        {
            get => _myAccountPageModel.AuthMethodHint;
            set
            {
                _myAccountPageModel.AuthMethodHint = value;
                OnPropertyChanged(nameof(AuthMethodHint));
            }
        }

        public string AuthName
        {
            get => _myAccountPageModel.AuthName;
            set
            {
                _myAccountPageModel.AuthName = value;
                OnPropertyChanged(nameof(AuthName));
            }
        }
        public string AuthNameHint
        {
            get => _myAccountPageModel.AuthNameHint;
            set
            {
                _myAccountPageModel.AuthNameHint = value;
                OnPropertyChanged(nameof(AuthNameHint));
            }
        }

        public DateTime? BirthDate
        {
            get => _myAccountPageModel.BirthDate;
            set
            {
                _myAccountPageModel.BirthDate = value;
                OnPropertyChanged(nameof(BirthDate));
            }
        }
        public DateTime? BirthDateHint
        {
            get => _myAccountPageModel.BirthDateHint;
            set
            {
                _myAccountPageModel.BirthDateHint = value;
                OnPropertyChanged(nameof(BirthDateHint));
            }
        }

        public string MobileNum
        {
            get => _myAccountPageModel.MobileNum;
            set
            {
                _myAccountPageModel.MobileNum = value;
                OnPropertyChanged(nameof(MobileNum));
            }
        }
        public string MobileNumHint
        {
            get => _myAccountPageModel.MobileNumHint;
            set
            {
                _myAccountPageModel.MobileNumHint = value;
                OnPropertyChanged(nameof(MobileNumHint));
            }
        }

        public string UserEmail
        {
            get => _myAccountPageModel.UserEmail;
            set
            {
                _myAccountPageModel.UserEmail = value;
                OnPropertyChanged(nameof(UserEmail));
            }
        }
        public string UserEmailHint
        {
            get => _myAccountPageModel.UserEmailHint;
            set
            {
                _myAccountPageModel.UserEmailHint = value;
                OnPropertyChanged(nameof(UserEmailHint));
            }
        }

        public ComboBoxItem OccupationName
        {
            get => _myAccountPageModel.OccupationName;
            set
            {
                _myAccountPageModel.OccupationName = value;
                OnPropertyChanged(nameof(OccupationName));
            }
        }
        public string OccupationNameHint
        {
            get => _myAccountPageModel.OccupationNameHint;
            set
            {
                _myAccountPageModel.OccupationNameHint = value;
                OnPropertyChanged(nameof(OccupationNameHint));
            }
        }

        public string RegiLoc
        {
            get => _myAccountPageModel.RegiLoc;
            set
            {
                _myAccountPageModel.RegiLoc = value;
                OnPropertyChanged(nameof(RegiLoc));
            }
        }
        public string RegiLocHint
        {
            get => _myAccountPageModel.RegiLocHint;
            set
            {
                _myAccountPageModel.RegiLocHint = value;
                OnPropertyChanged(nameof(RegiLocHint));
            }
        }

        public ComboBoxItem Married
        {
            get => _myAccountPageModel.Married;
            set
            {
                _myAccountPageModel.Married = value;
                OnPropertyChanged(nameof(Married));
            }
        }
        public string MarriedHint
        {
            get => _myAccountPageModel.MarriedHint;
            set
            {
                _myAccountPageModel.MarriedHint = value;
                OnPropertyChanged(nameof(MarriedHint));
            }
        }

        public ComboBoxItem RetireType
        {
            get => _myAccountPageModel.RetireType;
            set
            {
                _myAccountPageModel.RetireType = value;
                OnPropertyChanged(nameof(RetireType));
            }
        }
        public int? RetireTypeHint
        {
            get => _myAccountPageModel.RetireTypeHint;
            set
            {
                _myAccountPageModel.RetireTypeHint = value;
                OnPropertyChanged(nameof(RetireTypeHint));
            }
        }

        public string Country
        {
            get => _myAccountPageModel.Country;
            set
            {
                _myAccountPageModel.Country = value;
                OnPropertyChanged(nameof(Country));
            }
        }
        public string CountryHint
        {
            get => _myAccountPageModel.CountryHint;
            set
            {
                _myAccountPageModel.CountryHint = value;
                OnPropertyChanged(nameof(CountryHint));
            }
        }

        public ComboBoxItem Nationality
        {
            get => _myAccountPageModel.Nationality;
            set
            {
                _myAccountPageModel.Nationality = value;
                OnPropertyChanged(nameof(Nationality));
            }
        }
        public string NationalityHint
        {
            get => _myAccountPageModel.NationalityHint;
            set
            {
                _myAccountPageModel.NationalityHint = value;
                OnPropertyChanged(nameof(NationalityHint));
            }
        }

        public string NativePlace
        {
            get => _myAccountPageModel.NativePlace;
            set
            {
                _myAccountPageModel.NativePlace = value;
                OnPropertyChanged(nameof(NativePlace));
            }
        }
        public string NativePlaceHint
        {
            get => _myAccountPageModel.NativePlaceHint;
            set
            {
                _myAccountPageModel.NativePlaceHint = value;
                OnPropertyChanged(nameof(NativePlaceHint));
            }
        }

        public string RegiLocPostCode
        {
            get => _myAccountPageModel.RegiLocPostCode;
            set
            {
                _myAccountPageModel.RegiLocPostCode = value;
                OnPropertyChanged(nameof(RegiLocPostCode));
            }
        }
        public string RegiLocPostCodeHint
        {
            get => _myAccountPageModel.RegiLocPostCodeHint;
            set
            {
                _myAccountPageModel.RegiLocPostCodeHint = value;
                OnPropertyChanged(nameof(RegiLocPostCodeHint));
            }
        }

        public ComboBoxItem BloodType
        {
            get => _myAccountPageModel.BloodType;
            set
            {
                _myAccountPageModel.BloodType = value;
                OnPropertyChanged(nameof(BloodType));
            }
        }
        public string BloodTypeHint
        {
            get => _myAccountPageModel.BloodTypeHint;
            set
            {
                _myAccountPageModel.BloodTypeHint = value;
                OnPropertyChanged(nameof(BloodTypeHint));
            }
        }

        public int? MedCardNum
        {
            get => _myAccountPageModel.MedCardNum;
            set
            {
                _myAccountPageModel.MedCardNum = value;
                OnPropertyChanged(nameof(MedCardNum));
            }
        }
        public int? MedCardNumHint
        {
            get => _myAccountPageModel.MedCardNumHint;
            set
            {
                _myAccountPageModel.MedCardNumHint = value;
                OnPropertyChanged(nameof(MedCardNumHint));
            }
        }

        public Visibility IDCardComBoxVisibility
        {
            get => _myAccountPageModel.IDCardComBoxVisibility;
            set
            {
                _myAccountPageModel.IDCardComBoxVisibility = value;
                OnPropertyChanged(nameof(IDCardComBoxVisibility));
            }
        }

        public Visibility IDCardTextBoxVisibility
        {
            get => _myAccountPageModel.IDCardTextBoxVisibility;
            set
            {
                _myAccountPageModel.IDCardTextBoxVisibility = value;
                OnPropertyChanged(nameof(IDCardTextBoxVisibility));
            }
        }
        #endregion

        #region 命令

        public ICommand AgeCommand
        {
            get => _ageCommand ?? (_ageCommand = new RelayCommand(EditAge));
            set => _ageCommand = value;
        }

        public ICommand GenderCommand
        {
            get => _genderCommand ?? (_genderCommand = new RelayCommand(EditGender));
            set => _genderCommand = value;
        }
        public ICommand IDCardTypeCommand
        {
            get => _idCardTypeCommand ?? (_idCardTypeCommand = new RelayCommand(EditIDCardType));
            set => _idCardTypeCommand = value;
        }
        public ICommand IDCardCommand
        {
            get => _idCardCommand ?? (_idCardCommand = new RelayCommand(EditIDCard));
            set => _idCardCommand = value;
        }
        public ICommand AuthTypeCommand
        {
            get => _authTypeCommand ?? (_authTypeCommand = new RelayCommand(EditAuth));
            set => _authTypeCommand = value;
        }
        public ICommand AuthMethodCommand
        {
            get => _authMethodCommand ?? (_authMethodCommand = new RelayCommand(EditAuth));
            set => _authMethodCommand = value;
        }

        public ICommand AuthNameCommand
        {
            get => _authNameCommand ?? (_authNameCommand = new RelayCommand(EditAuth));
            set => _authNameCommand = value;
        }
        public ICommand BirthDateCommand
        {
            get => _birthDateCommand ?? (_birthDateCommand = new RelayCommand(EditBirthDate));
            set => _birthDateCommand = value;
        }
        public ICommand MobileNumCommand
        {
            get => _mobileNumCommand ?? (_mobileNumCommand = new RelayCommand(EditMobileNum));
            set => _mobileNumCommand = value;
        }
        public ICommand UserEmailCommand
        {
            get => _userEmailCommand ?? (_userEmailCommand = new RelayCommand(EditUserEmail));
            set => _userEmailCommand = value;
        }
        public ICommand OccupationCommand
        {
            get => _occupationCommand ?? (_occupationCommand = new RelayCommand(EditOccupation));
            set => _occupationCommand = value;
        }
        public ICommand RegiLocCommand
        {
            get => _regiLocCommand ?? (_regiLocCommand = new RelayCommand(EditRegiLoc));
            set => _regiLocCommand = value;
        }
        public ICommand MarriedCommand
        {
            get => _marriedCommand ?? (_marriedCommand = new RelayCommand(EditMarried));
            set => _marriedCommand = value;
        }
        public ICommand RetireTypeCommand
        {
            get => _retireTypeCommand ?? (_retireTypeCommand = new RelayCommand(EditRetireType));
            set => _retireTypeCommand = value;
        }
        public ICommand CountryCommand
        {
            get => _countryCommand ?? (_countryCommand = new RelayCommand(EditCountry));
            set => _countryCommand = value;
        }
        public ICommand NationalityCommand
        {
            get => _nationalityCommand ?? (_nationalityCommand = new RelayCommand(EditNationality));
            set => _nationalityCommand = value;
        }
        public ICommand NativePlaceCommand
        {
            get => _nativePlaceCommand ?? (_nativePlaceCommand = new RelayCommand(EditNativePlace));
            set => _nativePlaceCommand = value;
        }

        public ICommand RegiLocPostCodeCommand
        {
            get => _regiLocPostCodeCommand ?? (_regiLocPostCodeCommand = new RelayCommand(EditRegiLocPostCode));
            set => _regiLocPostCodeCommand = value;
        } 
        public ICommand BolldTypeCommand
        {
            get => _bloodTypeCommand ?? (_bloodTypeCommand = new RelayCommand(EditBloodType));
            set => _bloodTypeCommand = value;
        }

        public ICommand IDCardTypeSelectChange
        {
            get
            {
                return _idCardTypeSelectChange ?? (_idCardTypeSelectChange = new RelayCommand(
                    () =>
                    {
                        if (_myAccountPageModel.IDCardType != null)
                        {
                            if (_myAccountPageModel.IDCardType.Content.ToString() == "其他证件类型")
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

        #region 修改年龄

        public async void EditAge()
        {
            if (_myAccountPageModel.Age == null)
                MessageBox.Show("请填写年龄");
            else
            {
                NormUserService normUserService = new NormUserService(new NormUserRepository());
                var result = await normUserService.QueryAsync(it => it.UserName == _myAccountPageModel.UserName);
                var user = result[0];
                    
                int age = (int)_myAccountPageModel.Age;
                DateTime now = DateTime.Now;
                int birthYear = now.Year - age;
                DateTime birthDate = new DateTime(birthYear, now.Month, now.Day);
                    
                user.BirthDate = birthDate;
                BirthDate = birthDate;
                    
                bool isEdit = await normUserService.EditAsync(user);
                MessageBox.Show(isEdit ? "修改成功" : "修改失败");
            }
            
        }

        #endregion

        #region 修改性别

        public async void EditGender()
        {
            if (_myAccountPageModel.Gender == null)
                MessageBox.Show("请选择性别");
            else
            {
                NormUserService normUserService = new NormUserService(new NormUserRepository());
                var result = await normUserService.QueryAsync(it => it.UserName == _myAccountPageModel.UserName);
                var user = result[0];

                string genderName = _myAccountPageModel.Gender.Content.ToString();
                bool isEdit = await normUserService.EditGenderAsync(user, genderName);

                MessageBox.Show(isEdit ? "修改成功" : "修改失败");
                
            }
        }

        #endregion

        #region 修改证件类型

        public async void EditIDCardType()
        {
            if (_myAccountPageModel.IDCardType == null && string.IsNullOrEmpty(_myAccountPageModel.IDCardTypeText))
                MessageBox.Show("请选择证件类型");
            else
            {
                NormUserService normUserService = new NormUserService(new NormUserRepository());
                var result = await normUserService.QueryAsync(it => it.UserName == _myAccountPageModel.UserName);
                var user = result[0];
            
                bool isEdit = await normUserService.EditIDCardAsync(user, _myAccountPageModel.IDCardType.Content.ToString(),
                    _myAccountPageModel.IDCardTypeText);
            
                MessageBox.Show(isEdit ? "修改成功" : "修改失败");
            }
        }

        #endregion

        #region 修改证件号

        public async void EditIDCard()
        {
            if(string.IsNullOrEmpty(_myAccountPageModel.IDCard))
                MessageBox.Show("请填写正确的证件号");
            else
            {
                NormUserService normUserService = new NormUserService(new NormUserRepository());
                var result = await normUserService.QueryAsync(it => it.UserName == _myAccountPageModel.UserName);
                var user = result[0];

                user.IDCard = _myAccountPageModel.IDCard;
                bool isEdit = await normUserService.EditAsync(user);
                MessageBox.Show(isEdit ? "修改成功" : "修改失败");
            }

        }

        #endregion

        #region 实名认证

        public async void EditAuth()
        {
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = await normUserService.QueryAsync(it => it.UserName == _myAccountPageModel.UserName);
            var user = result[0];

            user.IDAuther = 0;
            user.IDAutherMethod = null;
            user.UserAuthName = null;

            bool isEdit = await normUserService.EditAsync(user);
            MessageBox.Show(isEdit ? "修改成功" : "修改失败");
            
            Messenger.Default.Send("", "MyAccount2IDAuth");
            
        }

        #endregion
        
        #region 修改出生日期

        public async void EditBirthDate()
        {
            if (_myAccountPageModel.BirthDate == null)
                MessageBox.Show("请选择您的出生日期");
            else
            {
                NormUserService normUserService = new NormUserService(new NormUserRepository());
                var result = await normUserService.QueryAsync(it => it.UserName == _myAccountPageModel.UserName);
                var user = result[0];
                
                user.BirthDate = (DateTime)_myAccountPageModel.BirthDate;
                Age = DateTime.Now.Year - ((DateTime)_myAccountPageModel.BirthDate).Year;

                bool isEdit = await normUserService.EditAsync(user);
                MessageBox.Show(isEdit ? "修改成功" : "修改失败");
            }
        }

        #endregion
        
        #region 修改手机号码

        public async void EditMobileNum()
        {
            if (string.IsNullOrEmpty(_myAccountPageModel.MobileNum))
                MessageBox.Show("请填写您的手机号码");
            else
            {
                NormUserService normUserService = new NormUserService(new NormUserRepository());
                var result = await normUserService.QueryAsync(it => it.UserName == _myAccountPageModel.UserName);
                var user = result[0];

                user.MobileNum = _myAccountPageModel.MobileNum;
            
                bool isEdit = await normUserService.EditAsync(user);
                MessageBox.Show(isEdit ? "修改成功" : "修改失败");
            }
            
            
        }

        #endregion
        
        #region 修改电子邮箱

        public async void EditUserEmail()
        {
            if (string.IsNullOrEmpty(_myAccountPageModel.UserEmail))
                MessageBox.Show("请填写您的电子邮箱");
            else
            {
                NormUserService normUserService = new NormUserService(new NormUserRepository());
                var result = await normUserService.QueryAsync(it => it.UserName == _myAccountPageModel.UserName);
                var user = result[0];

                user.UserEmail = _myAccountPageModel.UserEmail;
            
                bool isEdit = await normUserService.EditAsync(user);
                MessageBox.Show(isEdit ? "修改成功" : "修改失败");
            }
        }

        #endregion
        
        #region 修改职业

        public async void EditOccupation()
        {
            if (string.IsNullOrEmpty(_myAccountPageModel.OccupationName.Content.ToString()))
                MessageBox.Show("请选择您的职业");
            else
            {
                NormUserService normUserService = new NormUserService(new NormUserRepository());
                var result = await normUserService.QueryAsync(it => it.UserName == _myAccountPageModel.UserName);
                var user = result[0];

                bool isEdit = await normUserService.EditOccupation(user, _myAccountPageModel.OccupationName.Content.ToString());
                MessageBox.Show(isEdit ? "修改成功" : "修改失败");
            }
                
        }

        #endregion
        
        #region 修改户口地

        public async void EditRegiLoc()
        {
            if (string.IsNullOrEmpty(_myAccountPageModel.RegiLoc))
                MessageBox.Show("请选择户口地");
            else
            {
                NormUserService normUserService = new NormUserService(new NormUserRepository());
                var result = await normUserService.QueryAsync(it => it.UserName == _myAccountPageModel.UserName);
                var user = result[0];
            
                bool isEdit = await normUserService.EditAsync(user);
                MessageBox.Show(isEdit ? "修改成功" : "修改失败");
            }
            
        }

        #endregion
        
        #region 修改婚姻状态

        public async void EditMarried()
        {
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = await normUserService.QueryAsync(it => it.UserName == _myAccountPageModel.UserName);
            var user = result[0];

            string marriedType = _myAccountPageModel.Married.Content.ToString();

            switch (marriedType)
            {
                case "未婚": user.MarriedID = 10; break;
                case "已婚": user.MarriedID = 20; break;
                case "已婚-初婚": user.MarriedID = 21; break;
                case "已婚-再婚": user.MarriedID = 22; break;
                case "已婚-复婚": user.MarriedID = 23; break;
                case "丧偶": user.MarriedID = 30; break;
                case "离婚": user.MarriedID = 40; break;
                default: user.MarriedID = 0; break;
            }
            
            bool isEdit = await normUserService.EditAsync(user);
            MessageBox.Show(isEdit ? "修改成功" : "修改失败");
        }

        #endregion
        
        #region 修改职退状态

        public async void EditRetireType()
        {
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = await normUserService.QueryAsync(it => it.UserName == _myAccountPageModel.UserName);
            var user = result[0];

            switch (_myAccountPageModel.RetireType.Content.ToString())
            {
                case "退休": user.RetireTypeID = 0; break;
                case "在职": user.RetireTypeID = 1; break;
                default: user.RetireTypeID = null; break;
            }
            
            bool isEdit = await normUserService.EditAsync(user);
            MessageBox.Show(isEdit ? "修改成功" : "修改失败");
        }

        #endregion
        
        #region 修改国籍

        public async void EditCountry()
        {
            if (string.IsNullOrEmpty(_myAccountPageModel.Country))
                MessageBox.Show("请选择您的国籍");
            else
            {
                NormUserService normUserService = new NormUserService(new NormUserRepository());
                var result = await normUserService.QueryAsync(it => it.UserName == _myAccountPageModel.UserName);
                var user = result[0];

                bool isEdit = await normUserService.EditCountryAsync(user, _myAccountPageModel.Country);
                MessageBox.Show(isEdit ? "修改成功" : "修改失败");
            }
            
        }

        #endregion
        
        #region 修改民族

        public async void EditNationality()
        {
            if (string.IsNullOrEmpty(_myAccountPageModel.Nationality.Content.ToString()))
                MessageBox.Show("请选择您的民族");
            else
            {
                NormUserService normUserService = new NormUserService(new NormUserRepository());
                var result = await normUserService.QueryAsync(it => it.UserName == _myAccountPageModel.UserName);
                var user = result[0];

                bool isEdit = await normUserService.EditNationalityAsync(user, _myAccountPageModel.Nationality.Content.ToString());
                MessageBox.Show(isEdit ? "修改成功" : "修改失败");
            }
            
            
        }

        #endregion
        
        #region 修改籍贯地

        public async void EditNativePlace()
        {
            if (string.IsNullOrEmpty(_myAccountPageModel.NativePlace))
                MessageBox.Show("请选择您的籍贯地");
            else
            {
                NormUserService normUserService = new NormUserService(new NormUserRepository());
                var result = await normUserService.QueryAsync(it => it.UserName == _myAccountPageModel.UserName);
                var user = result[0];

                bool isEdit = await normUserService.EditNationalityAsync(user, _myAccountPageModel.NativePlace);
                MessageBox.Show(isEdit ? "修改成功" : "修改失败");
            }
            
            
        }

        #endregion
        
        #region 修改邮编

        public async void EditRegiLocPostCode()
        {
            if (string.IsNullOrEmpty(_myAccountPageModel.RegiLocPostCode))
                MessageBox.Show("请填写您的邮编");
            else
            {
                NormUserService normUserService = new NormUserService(new NormUserRepository());
                var result = await normUserService.QueryAsync(it => it.UserName == _myAccountPageModel.UserName);
                var user = result[0];

                user.RegiLocPostCode = _myAccountPageModel.RegiLocPostCode;
            
                bool isEdit = await normUserService.EditAsync(user);
                MessageBox.Show(isEdit ? "修改成功" : "修改失败");
            }

            
        }

        #endregion
        
        #region 修改血型

        public async void EditBloodType()
        {
            if (string.IsNullOrEmpty(_myAccountPageModel.BloodType.Content.ToString()))
                MessageBox.Show("请选择你的血型");
            else
            {
                NormUserService normUserService = new NormUserService(new NormUserRepository());
                var result = await normUserService.QueryAsync(it => it.UserName == _myAccountPageModel.UserName);
                var user = result[0];

                user.BloodType = _myAccountPageModel.BloodType.Content.ToString();
            
                bool isEdit = await normUserService.EditAsync(user);
                MessageBox.Show(isEdit ? "修改成功" : "修改失败");
            }
        }

        #endregion

        #endregion

        public async void GenerateHint(string userName)
        {
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = await normUserService.QueryAsync(it => it.UserName == userName);
            
            // 查找到用户
            if (result != null && result.Count > 0)
            {
                var user = result[0];
                _myAccountPageModel.GenderHint = user.SexName;  // 性别
                _myAccountPageModel.AuthNameHint = user.UserAuthName; // 实名
                _myAccountPageModel.MobileNumHint = user.MobileNum; // 联系方式
                _myAccountPageModel.UserEmailHint = user.UserEmail;  // 电子邮箱
                _myAccountPageModel.OccupationNameHint = user.OccupationName; // 职业
                _myAccountPageModel.RegiLocHint = user.RegiLocName;  // 户口
                _myAccountPageModel.CountryHint = user.CountryName;  // 国家
                _myAccountPageModel.NationalityHint = user.NationalityName;  // 民族
                _myAccountPageModel.NativePlaceHint = user.NativePlaceName;  // 籍贯
                _myAccountPageModel.RegiLocPostCodeHint = user.RegiLocPostCode;  // 邮编
                _myAccountPageModel.BloodTypeHint = user.BloodType;  // 血型

                // 证件类型
                string[] IDCardTypeList = {
                    "身份证", "军人证", "护照", "户口本", "外国人永久居留证", "武警证", "公章", "工商营业执照",
                    "法人代码证", "学生证", "士兵证", "港澳居民来往内地通行证", "台湾居民来往大陆通行证"
                };
                if (!IDCardTypeList.Contains(user.IDCardTypeName))
                {
                    _myAccountPageModel.IDCardTypeHint = "其他证件类型";
                    _myAccountPageModel.IDCardTypeTextHint = user.IDCardTypeName;
                }
                else
                    _myAccountPageModel.IDCardTypeHint = user.IDCardTypeName;

                if (user.IDCard != null) _myAccountPageModel.IDCardHint = user.IDCard;
                if (user.BirthDate != null) _myAccountPageModel.BirthDateHint = (DateTime) user.BirthDate;
                if (user.RetireTypeID != null) _myAccountPageModel.RetireTypeHint = user.RetireTypeID;
                if (user.MedCardNum != null) _myAccountPageModel.MedCardNumHint = user.MedCardNum;
                if (user.BirthDate != null) 
                    _myAccountPageModel.AgeHint = DateTime.Now.Year - user.BirthDate.Value.Year;
                if (user.IDAuther != null)
                {
                    if (user.IDAuther == 0)
                    {
                        _myAccountPageModel.AuthType = "未认证";
                        _myAccountPageModel.AuthButton = "去认证";
                    }
                    else
                    {
                        _myAccountPageModel.AuthType = "已认证";
                        _myAccountPageModel.AuthButton = "取消认证";
                    }

                }
                if (user.IDAutherMethod != null)
                {
                    _myAccountPageModel.AuthMethodHint = user.IDAutherMethod;
                    // IDAutherMethodComboBox.IsEnabled = true;
                    // IDAutherMethodButton.IsEnabled = true;
                    // UserAuthNameButton.IsEnabled = true;
                }
                else
                {
                    _myAccountPageModel.AuthType = "未认证";
                }
                if (user.MarriedID != null)
                {
                    switch (user.MarriedID)
                    {
                        case 10: _myAccountPageModel.MarriedHint = "未婚"; break;
                        case 20: _myAccountPageModel.MarriedHint = "已婚"; break;
                        case 21: _myAccountPageModel.MarriedHint = "已婚-初婚"; break;
                        case 22: _myAccountPageModel.MarriedHint = "已婚-再婚"; break;
                        case 23: _myAccountPageModel.MarriedHint = "已婚-复婚"; break;
                        case 30: _myAccountPageModel.MarriedHint = "丧偶"; break;
                        case 40: _myAccountPageModel.MarriedHint = "离婚"; break;
                        default: _myAccountPageModel.MarriedHint = ""; break;
                    }
                }
            }
        }
    }
}