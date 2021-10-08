using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using MyApp.SHIS.Repository.Repository;
using MyApp.SHIS.Services.Services;
using MyApp.SHIS.ViewModel.Common;

namespace MyApp.SHIS.ViewModel.PagesViewModels.RegisterPage
{
    public class RegisterPageViewModel : NotificationObject
    {
        private readonly RegisterPageModel _registerPageModel = new RegisterPageModel();

        public RegisterPageViewModel(int? patiMedCardNum)
        {                
            // 初始化挂号流水号
            SerialNumbers = new ObservableCollection<string>();
            // 初始化科室信息
            DoctDepts = new ObservableCollection<string>
            {
                "骨科", "神经外科", "胸心外科", "泌尿外科", "整形科", "普外科", "消化内科", "肾脏内科", "心血管内科",
                "呼吸内科", "血液内科", "内分泌科", "风湿免疫科", "传染科", "神经内科", "肿瘤科", "耳鼻喉科",
                "眼科", "口腔科", "精神科", "皮肤科", "疼痛科", "妇科", "儿科", "  "
            };
            // 初始化医生信息
            DoctNames = new ObservableCollection<string>();
            if (patiMedCardNum != null)
                InitionalizeMessage((int)patiMedCardNum);
            else
                _registerPageModel.PatiMedCardNumIsEnable = true;
        }

        private ICommand _generatePatiMessage;
        private ICommand _register;
        private ICommand _clean;
        private ICommand _deptSelectChange;
        private ICommand _serialNumberSelectChange;

        #region 属性

        public int? PatiMedCardNum
        { 
            get => _registerPageModel.PatiMedCardNum;
            set
            {
                _registerPageModel.PatiMedCardNum = value;
                OnPropertyChanged(nameof(PatiMedCardNum));
            }
        }
        public int? QueueNo
        {
             get => _registerPageModel.QueueNo;
             set
             {
                 _registerPageModel.QueueNo = value;
                 OnPropertyChanged(nameof(QueueNo));
             }
        }
        public int? PatiAge
        { 
            get => _registerPageModel.PatiAge;
            set
            {
                _registerPageModel.PatiAge = value;
                OnPropertyChanged(nameof(PatiAge));
            }
        }
        public ObservableCollection<string> DoctDepts
        {
             get => _registerPageModel.DoctDepts;
             set
             {
                 _registerPageModel.DoctDepts = value;
                 OnPropertyChanged(nameof(DoctDepts));
             }
        }
        public ObservableCollection<string> DoctNames
        {
             get => _registerPageModel.DoctNames;
             set
             {
                 _registerPageModel.DoctNames = value;
                 OnPropertyChanged(nameof(DoctNames));
             }
        }
        public ObservableCollection<string> SerialNumbers
        {
             get => _registerPageModel.SerialNumbers;
             set
             {
                 _registerPageModel.SerialNumbers = value;
                 OnPropertyChanged(nameof(SerialNumbers));
             }
        }
        public string PatiAuthName 
        { 
            get => _registerPageModel.PatiAuthName;
            set
            {
                _registerPageModel.PatiAuthName = value;
                OnPropertyChanged(nameof(PatiAuthName));
            }
        }
        public string PatiGender
        { 
            get => _registerPageModel.PatiGender;
            set
            {
                _registerPageModel.PatiGender = value;
                OnPropertyChanged(nameof(PatiGender));
            }
        }
        public string SerialNumber
        { 
            get => _registerPageModel.SerialNumber;
            set
            {
                _registerPageModel.SerialNumber = value;
                OnPropertyChanged(nameof(SerialNumber));
            }
        }
        public string DoctDept
        { 
            get => _registerPageModel.DoctDept;
            set
            {
                _registerPageModel.DoctDept = value;
                OnPropertyChanged(nameof(DoctDept));
            }
        }
        public string  DoctName
        { 
            get => _registerPageModel.DoctName;
            set
            {
                _registerPageModel.DoctName = value;
                OnPropertyChanged(nameof(DoctName));
            }
        }
        public DateTime? RegDate
        { 
            get => _registerPageModel.RegDate;
            set
            {
                _registerPageModel.RegDate = value;
                OnPropertyChanged(nameof(RegDate));
            }
        }
        public DateTime? ValidDate
        { 
            get => _registerPageModel.ValidDate;
            set
            {
                _registerPageModel.ValidDate = value;
                OnPropertyChanged(nameof(ValidDate));
            }
        }
        public decimal TotalFee
        { 
            get => _registerPageModel.TotalFee;
            set
            {
                _registerPageModel.TotalFee = value;
                OnPropertyChanged(nameof(TotalFee));
            }
        }
        public decimal RecvFee
        { 
            get => _registerPageModel.RecvFee;
            set
            {
                _registerPageModel.RecvFee = value;
                OnPropertyChanged(nameof(RecvFee));
            }
        }
        public ComboBoxItem PayType
        {
            get => _registerPageModel.PayType;
            set
            {
                _registerPageModel.PayType = value;
                OnPropertyChanged(nameof(PayType));
            }
        }
        public bool PatiMedCardNumIsEnable
        {
            get => _registerPageModel.PatiMedCardNumIsEnable;
            set
            {
                _registerPageModel.PatiMedCardNumIsEnable = value;
                OnPropertyChanged(nameof(PatiMedCardNumIsEnable));
            }
        }
        
        // Hint
        public int? PatiMedCardNumHint
        {
            get => _registerPageModel.PatiMedCardNumHint;
            set
            {
                _registerPageModel.PatiMedCardNumHint = value;
                OnPropertyChanged(nameof(PatiMedCardNumHint));
            }
        }
        public string DoctDeptHint
        { 
            get => _registerPageModel.DoctDeptHint;
            set
            {
                _registerPageModel.DoctDeptHint = value;
                OnPropertyChanged(nameof(DoctDeptHint));
            }
        }
        public string VaildDateHint
        { 
            get => _registerPageModel.VaildDateHint;
            set
            {
                _registerPageModel.VaildDateHint = value;
                OnPropertyChanged(nameof(VaildDateHint));
            }
        }
        public string DoctIDHint
        { 
            get => _registerPageModel.DoctIDHint;
            set
            {
                _registerPageModel.DoctIDHint = value;
                OnPropertyChanged(nameof(DoctIDHint));
            }
        }
        public string PayTypeHint
        {
            get => _registerPageModel.PayTypeHint;
            set
            {
                _registerPageModel.PayTypeHint = value;
                OnPropertyChanged(nameof(PayTypeHint));
            }
        }


        #endregion

        #region 命令

        public ICommand GeneratePatiMessage
        {
            get => _generatePatiMessage ?? (_generatePatiMessage = new RelayCommand(
                () =>
                {
                    InitionalizeMessage(_registerPageModel.PatiMedCardNum);
                }));
            set => _generatePatiMessage = value;
        }

        public ICommand Register
        {
            get => _register ?? (_register = new RelayCommand(PatiRegister));
            set => _register = value;
        }

        public ICommand Clean
        {
            get => _clean ?? (_clean = new RelayCommand(CleanMessage));
            set => _clean = value;
        }
        public ICommand DeptSelectChange
        {
            get => _deptSelectChange ?? (_deptSelectChange = new RelayCommand(GenerateDoct));
            set => _deptSelectChange = value;
        }
        public ICommand SerialNumberSelectChange
        {
            get => _serialNumberSelectChange ?? (_serialNumberSelectChange = new RelayCommand(UpdateSerialNumber));
            set => _serialNumberSelectChange = value;
        }

        #endregion

        #region 命令方法

        // 挂号
        public void PatiRegister()
        {
            
            
        }
        // 清空所有信息
        public void CleanMessage()
        {
            PatiMedCardNumHint = _registerPageModel.PatiMedCardNum;
            SerialNumbers.Clear();
            DoctNames.Clear();
            PatiMedCardNum = null;
            PatiAuthName = null;
            PatiGender = null;
            PatiAge = null;
            ValidDate = null;
            RegDate = null;
            TotalFee = 0;
            RecvFee = 0;
            
            PatiMedCardNumIsEnable = true;
        }
        // 根据选择的科室生成对应医生信息
        public async void GenerateDoct()
        {
            DoctNames.Clear();
            DoctUserService doctUserService = new DoctUserService(new DoctUserRepository());
            var doctResult = await doctUserService.QueryAsync(it => it.DoctDept == _registerPageModel.DoctDept);
            if (doctResult != null && doctResult.Count > 0)
            {
                foreach (var doct in doctResult)
                    DoctNames.Add(doct.DoctName);
            }
            else
                MessageBox.Show("该科室没有医生值班");
            
        }
        // 根据填写的医疗卡号 生成流水号信息
        public async void UpdateSerialNumber()
        {
            PatiOutVisitService patiOutVisitService = new PatiOutVisitService(new PatiOutVisitRepository());
            
            MessageBox.Show(_registerPageModel.SerialNumber);
            if (int.TryParse(_registerPageModel.SerialNumber, out var serialNumber))
            {
                var patiOutVisitResult = await patiOutVisitService.QueryAsync(it => it.SerialNumber == serialNumber);
                // 如果不是新添加的流水号，直接读取数据库的数据， 否则根据数据库中最新数据创建一条新记录
                if (patiOutVisitResult != null && patiOutVisitResult.Count > 0)
                {
                    QueueNo = patiOutVisitResult[0].QueueNo;
                    RegDate = patiOutVisitResult[0].RegDate;
                }
                else
                {
                    RegDate = DateTime.Now.Date;
                    
                }
                
            }
            else
            {
                if (_registerPageModel.SerialNumber == "返回选择")
                {
                    SerialNumbers.Clear();   
                    PatiUserService patiUserService = new PatiUserService(new PatiUserRepository());
                    var patiResult = await patiUserService.QueryAsync(it => it.MedCardNum == _registerPageModel.PatiMedCardNum);
                    var patiOutVisitResult = await patiOutVisitService.QueryAsync(it => it.PatiID == patiResult[0].PatiID);

                    foreach (var patiOutVisit in patiOutVisitResult)
                        SerialNumbers.Add(patiOutVisit.SerialNumber.ToString());
                
                    SerialNumbers.Add("添加新记录");
                    PatiMedCardNumIsEnable = false;
                }
                if(_registerPageModel.SerialNumber == "添加新记录")
                {
                    SerialNumbers.Clear();
                    var patiOutVisits = await patiOutVisitService.QueryAsync();
                    var newSerialNumber = patiOutVisits[patiOutVisits.Count - 1].SerialNumber + 1;
                    SerialNumbers.Add(newSerialNumber.ToString());
                    SerialNumbers.Add("返回选择");
                    
                }
            }
            
        }


        #endregion
        
        public async void InitionalizeMessage(int? patiMedCardNum)
        {
            // 初始化病人信息
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var normResult = await normUserService.QueryAsync(it => it.MedCardNum == patiMedCardNum);
            if (normResult != null && normResult.Count > 0)
            {
                var normUser = normResult[0];
            
                PatiMedCardNum = patiMedCardNum;
                PatiAuthName = normUser.UserAuthName;
                PatiGender = normUser.SexName;
            
                if(normUser.BirthDate != null)
                    PatiAge = DateTime.Now.Year - ((DateTime)normUser.BirthDate).Year;
            
                SerialNumbers.Clear();
                PatiUserService patiUserService = new PatiUserService(new PatiUserRepository());
                var patiResult = await patiUserService.QueryAsync(it => it.NormID == normUser.NormID);

                PatiOutVisitService patiOutVisitService = new PatiOutVisitService(new PatiOutVisitRepository());
                var patiOutVisitResult = await patiOutVisitService.QueryAsync(it => it.PatiID == patiResult[0].PatiID);

                foreach (var patiOutVisit in patiOutVisitResult)
                    SerialNumbers.Add(patiOutVisit.SerialNumber.ToString());
                
                SerialNumbers.Add("添加新记录");
                
                PatiMedCardNumIsEnable = false;
            }
            else
                MessageBox.Show("没能查询到医疗卡信息，请确认并重新填写");
            
        }
    }
}