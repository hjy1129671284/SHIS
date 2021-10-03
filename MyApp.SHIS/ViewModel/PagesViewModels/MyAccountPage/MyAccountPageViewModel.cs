using System;
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


        public string Gender
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
            
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = normUserService.QueryAsync(it => it.UserName == _myAccountPageModel.UserName).Result;
            var user = result[0];
                    
            int age = Convert.ToInt32(_myAccountPageModel.Age);
            DateTime now = DateTime.Now;
            int birthYear = now.Year - age;
            DateTime birthDate = new DateTime(birthYear, now.Month, now.Day);
                    
            user.BirthDate = birthDate;
            BirthDate = birthDate;
                    
            bool isEdit = await normUserService.EditAsync(user);
            MessageBox.Show(isEdit ? "修改成功" : "修改失败");
                    
            // MessageBox.Show($"Age:{Age}, _myAccountPageModel.Age:{_myAccountPageModel.Age}");
            
        }

        #endregion

        #region 修改性别

        public async void EditGender()
        {
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = normUserService.QueryAsync(it => it.UserName == _myAccountPageModel.UserName).Result;
            var user = result[0];

            string gender = _myAccountPageModel.Gender;
            user.SexName = gender;
            if (gender == "  ")
            {
                user.SexID = 0;
                user.SexName = null;
            }
            else if (gender == "男")
            {
                user.SexID = 1;
                user.SexName = "男";
            }
            else if (gender == "女")
            {
                user.SexID = 2;
                user.SexName = "女";
            }
            
            bool isEdit = await normUserService.EditAsync(user);
            MessageBox.Show(isEdit ? "修改成功" : "修改失败");
        }

        #endregion

        #region 修改证件类型

        public async void EditIDCardType()
        {
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = normUserService.QueryAsync(it => it.UserName == _myAccountPageModel.UserName).Result;
            var user = result[0];
            
            user.IDCardTypeName = _myAccountPageModel.IDCardType.Content.ToString() == 
                                  "其他证件类型" ? _myAccountPageModel.IDCardTypeText : _myAccountPageModel.IDCardType.Content.ToString();
            switch (user.IDCardTypeName)
            {
                case "身份证": user.IDCardTypeID = 100001; user.IDCardTypeName = "身份证"; break;
                case "军人证": user.IDCardTypeID = 100002; user.IDCardTypeName = "军人证"; break;
                case "护照": user.IDCardTypeID = 100003; user.IDCardTypeName = "护照"; break;
                case "户口本": user.IDCardTypeID = 100004; user.IDCardTypeName = "户口本"; break;
                case "外国人永久居留证": user.IDCardTypeID = 100005; user.IDCardTypeName = "外国人永久居留证"; break;
                case "武警证": user.IDCardTypeID = 100006; user.IDCardTypeName = "武警证"; break;
                case "公章": user.IDCardTypeID = 100007; user.IDCardTypeName = "公章"; break;
                case "工商营业执照": user.IDCardTypeID = 100008; user.IDCardTypeName = "工商营业执照"; break;
                case "法人代码证": user.IDCardTypeID = 100009; user.IDCardTypeName = "法人代码证"; break;
                case "学生证": user.IDCardTypeID = 100010; user.IDCardTypeName = "学生证"; break;
                case "士兵证": user.IDCardTypeID = 100011; user.IDCardTypeName = "士兵证"; break;
                case "港澳居民来往内地通行证": user.IDCardTypeID = 100016; user.IDCardTypeName = "港澳居民来往内地通行证"; break;
                case "台湾居民来往大陆通行证": user.IDCardTypeID = 100017; user.IDCardTypeName = "台湾居民来往大陆通行证"; break;
                default: user.IDCardTypeID = 10018; user.IDCardTypeName = "其他证件类型"; break;
            }
            
            bool isEdit = await normUserService.EditAsync(user);
            MessageBox.Show(isEdit ? "修改成功" : "修改失败");
        }

        #endregion

        #region 修改证件号

        public async void EditIDCard()
        {
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = normUserService.QueryAsync(it => it.UserName == _myAccountPageModel.UserName).Result;
            var user = result[0];

            if(_myAccountPageModel.IDCard != null)
                user.IDCard = _myAccountPageModel.IDCard;
            else
            {
                MessageBox.Show("请填写正确的证件号");
            }
            
            bool isEdit = await normUserService.EditAsync(user);
            MessageBox.Show(isEdit ? "修改成功" : "修改失败");
        }

        #endregion

        #region 实名认证

        public async void EditAuth()
        {
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = normUserService.QueryAsync(it => it.UserName == _myAccountPageModel.UserName).Result;
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
            
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = normUserService.QueryAsync(it => it.UserName == _myAccountPageModel.UserName).Result;
            var user = result[0];

            if (_myAccountPageModel.BirthDate != null)
            {
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
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = normUserService.QueryAsync(it => it.UserName == _myAccountPageModel.UserName).Result;
            var user = result[0];

            user.MobileNum = _myAccountPageModel.MobileNum;
            
            bool isEdit = await normUserService.EditAsync(user);
            MessageBox.Show(isEdit ? "修改成功" : "修改失败");
        }

        #endregion
        
        #region 修改电子邮箱

        public async void EditUserEmail()
        {
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = normUserService.QueryAsync(it => it.UserName == _myAccountPageModel.UserName).Result;
            var user = result[0];

            user.UserEmail = _myAccountPageModel.UserEmail;
            
            bool isEdit = await normUserService.EditAsync(user);
            MessageBox.Show(isEdit ? "修改成功" : "修改失败");
        }

        #endregion
        
        #region 修改职业

        public async void EditOccupation()
        {
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = normUserService.QueryAsync(it => it.UserName == _myAccountPageModel.UserName).Result;
            var user = result[0];

            user.OccupationName = _myAccountPageModel.OccupationName.Content.ToString();
            switch (user.OccupationName)
            {
                case "国家机关、党群组织、企业、事业单位负责人": user.OccupationID = 10000; break;
                case "专业技术人员": user.OccupationID = 20000; break;
                case "办事人员和有关人员": user.OccupationID = 30000; break;
                case "商业、服务业人员": user.OccupationID = 40000; break;
                case "农、林、牧、渔、水利业生产人员": user.OccupationID = 50000; break;
                case "生产、运输设备操作人员及有关人员": user.OccupationID = 60000; break;
                case "军人": user.OccupationID = 70000; break;
                case "无职业者分类及代码": user.OccupationID = 80000; break;
                case "不便分类的其他人群": user.OccupationID = 90000; break;
                case "不知道": user.OccupationID = -1; break;
                
            }
            
            bool isEdit = await normUserService.EditAsync(user);
            MessageBox.Show(isEdit ? "修改成功" : "修改失败");
        }

        #endregion
        
        #region 修改户口地

        public async void EditRegiLoc()
        {
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = normUserService.QueryAsync(it => it.UserName == _myAccountPageModel.UserName).Result;
            var user = result[0];

            user.OccupationName = _myAccountPageModel.OccupationName.Content.ToString();

            switch (_myAccountPageModel.OccupationName.Content.ToString())
            {
                case "国家机关、党群组织、企业、事业单位负责人": user.OccupationID = 10000; break;
                case "专业技术人员": user.OccupationID = 20000; break;
                case "办事人员和有关人员": user.OccupationID = 30000; break;
                case "商业、服务业人员": user.OccupationID = 40000; break;
                case "农、林、牧、渔、水利业生产人员": user.OccupationID = 50000; break;
                case "生产、运输设备操作人员及有关人员": user.OccupationID = 60000; break;
                case "军人": user.OccupationID = 70000; break;
                case "无职业者分类及代码": user.OccupationID = 80000; break;
                case "不便分类的其他人群": user.OccupationID = 90000; break;
                case "不知道": user.OccupationID = -1; break;
            }
            
            bool isEdit = await normUserService.EditAsync(user);
            MessageBox.Show(isEdit ? "修改成功" : "修改失败");
        }

        #endregion
        
        #region 修改婚姻状态

        public async void EditMarried()
        {
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = normUserService.QueryAsync(it => it.UserName == _myAccountPageModel.UserName).Result;
            var user = result[0];

            string marriedType = _myAccountPageModel.Married.Content.ToString();

            switch (marriedType)
            {
                case "未婚": user.MarriedID = 10; break;
                case "已婚": user.MarriedID = 10; break;
                case "已婚-初婚": user.MarriedID = 10; break;
                case "已婚-再婚": user.MarriedID = 10; break;
                case "已婚-复婚": user.MarriedID = 10; break;
                case "丧偶": user.MarriedID = 10; break;
                case "离婚": user.MarriedID = 10; break;
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
            var result = normUserService.QueryAsync(it => it.UserName == _myAccountPageModel.UserName).Result;
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
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = normUserService.QueryAsync(it => it.UserName == _myAccountPageModel.UserName).Result;
            var user = result[0];

            user.CountryName = _myAccountPageModel.Country;
            // countryID
            
            bool isEdit = await normUserService.EditAsync(user);
            MessageBox.Show(isEdit ? "修改成功" : "修改失败");
        }

        #endregion
        
        #region 修改民族

        public async void EditNationality()
        {
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = normUserService.QueryAsync(it => it.UserName == _myAccountPageModel.UserName).Result;
            var user = result[0];

            user.NationalityName = _myAccountPageModel.Nationality.Content.ToString();
            switch (user.NationalityName)
            {
                case "汉族": user.NationalityID = 01; break;
                case "蒙古族": user.NationalityID = 02; break;
                case "回族": user.NationalityID = 03; break;
                case "藏族": user.NationalityID = 04; break;
                case "维吾尔族": user.NationalityID = 05; break;
                case "苗族": user.NationalityID = 06; break;
                case "彝族": user.NationalityID = 07; break;
                case "壮族": user.NationalityID = 08; break;
                case "布依族": user.NationalityID = 09; break;
                case "朝鲜族": user.NationalityID = 10; break;
                case "满族": user.NationalityID = 11; break;
                case "侗族": user.NationalityID = 12; break;
                case "瑶族": user.NationalityID = 13; break;
                case "白族": user.NationalityID = 14; break;
                case "土家族": user.NationalityID = 15; break;
                case "哈尼族": user.NationalityID = 16; break;
                case "哈萨克族": user.NationalityID = 17; break;
                case "傣族": user.NationalityID = 18; break;
                case "黎族": user.NationalityID = 19; break;
                case "傈僳族": user.NationalityID = 20; break;
                case "佤族": user.NationalityID = 21; break;
                case "畲族": user.NationalityID = 22; break;
                case "高山族": user.NationalityID = 23; break;
                case "拉祜族": user.NationalityID = 24; break;
                case "水族": user.NationalityID = 25; break;
                case "东乡族": user.NationalityID = 26; break;
                case "纳西族": user.NationalityID = 27; break;
                case "景颇族": user.NationalityID = 28; break;
                case "柯尔克孜族": user.NationalityID = 29; break;
                case "土族": user.NationalityID = 30; break;
                case "达斡尔族": user.NationalityID = 31; break;
                case "仫佬族": user.NationalityID = 32; break;
                case "羌族": user.NationalityID = 33; break;
                case "布朗族": user.NationalityID = 34; break;
                case "撒拉族": user.NationalityID = 35; break;
                case "毛难族": user.NationalityID = 36; break;
                case "仡佬族": user.NationalityID = 37; break;
                case "锡伯族": user.NationalityID = 38; break;
                case "阿昌族": user.NationalityID = 39; break;
                case "普米族": user.NationalityID = 40; break;
                case "塔吉克族": user.NationalityID = 41; break;
                case "怒族": user.NationalityID = 42; break;
                case "乌孜别克族": user.NationalityID = 43; break;
                case "俄罗斯族": user.NationalityID = 44; break;
                case "鄂温克族": user.NationalityID = 45; break;
                case "崩龙族": user.NationalityID = 46; break;
                case "保安族": user.NationalityID = 47; break;
                case "裕固族": user.NationalityID = 48; break;
                case "京族": user.NationalityID = 49; break;
                case "塔塔尔族": user.NationalityID = 50; break;
                case "独龙族": user.NationalityID = 51; break;
                case "鄂伦春族": user.NationalityID = 52; break;
                case "赫哲族": user.NationalityID = 53; break;
                case "门巴族": user.NationalityID = 54; break;
                case "珞巴族": user.NationalityID = 55; break;
                case "基诺族": user.NationalityID = 56; break;
                case "其他": user.NationalityID = 97; break;
                case "外国血统": user.NationalityID = 98; break;
                default: user.NationalityID = null; break;
            }
            
            bool isEdit = await normUserService.EditAsync(user);
            MessageBox.Show(isEdit ? "修改成功" : "修改失败");
        }

        #endregion
        
        #region 修改籍贯地

        public async void EditNativePlace()
        {
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = normUserService.QueryAsync(it => it.UserName == _myAccountPageModel.UserName).Result;
            var user = result[0];

            user.NativePlaceName = _myAccountPageModel.NativePlace;
            // nativeplaceID
            
            bool isEdit = await normUserService.EditAsync(user);
            MessageBox.Show(isEdit ? "修改成功" : "修改失败");
        }

        #endregion
        
        #region 修改邮编

        public async void EditRegiLocPostCode()
        {
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = normUserService.QueryAsync(it => it.UserName == _myAccountPageModel.UserName).Result;
            var user = result[0];

            user.RegiLocPostCode = _myAccountPageModel.RegiLocPostCode;
            
            bool isEdit = await normUserService.EditAsync(user);
            MessageBox.Show(isEdit ? "修改成功" : "修改失败");
        }

        #endregion
        
        #region 修改血型

        public async void EditBloodType()
        {
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = normUserService.QueryAsync(it => it.UserName == _myAccountPageModel.UserName).Result;
            var user = result[0];

            user.BloodType = _myAccountPageModel.BloodType.Content.ToString();
            
            bool isEdit = await normUserService.EditAsync(user);
            MessageBox.Show(isEdit ? "修改成功" : "修改失败");
        }

        #endregion

        #endregion

        public void GenerateHint(string userName)
        {
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = normUserService.QueryAsync(it => it.UserName == userName).Result;
            
            if (result != null && result.Count > 0)
            {
                var user = result[0];
                _myAccountPageModel.GenderHint = user.SexName;
                _myAccountPageModel.IDCardTypeHint = user.IDCardTypeName;
                _myAccountPageModel.AuthNameHint = user.UserAuthName;
                _myAccountPageModel.MobileNumHint = user.MobileNum;
                _myAccountPageModel.UserEmailHint = user.UserEmail;
                _myAccountPageModel.OccupationNameHint = user.OccupationName;
                _myAccountPageModel.RegiLocHint = user.RegiLocName;
                _myAccountPageModel.CountryHint = user.CountryName;
                _myAccountPageModel.NationalityHint = user.NationalityName;
                _myAccountPageModel.NativePlaceHint = user.NativePlaceName;
                _myAccountPageModel.RegiLocPostCodeHint = user.RegiLocPostCode;
                _myAccountPageModel.BloodTypeHint = user.BloodType;
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
                        case 20: _myAccountPageModel.MarriedHint =  "已婚"; break;
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