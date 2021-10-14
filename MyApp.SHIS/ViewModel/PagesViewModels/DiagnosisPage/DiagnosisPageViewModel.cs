using System;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MyApp.SHIS.Models;
using MyApp.SHIS.Repository.Repository;
using MyApp.SHIS.Services.Services;
using MyApp.SHIS.ViewModel.Common;

namespace MyApp.SHIS.ViewModel.PagesViewModels.DiagnosisPage
{
    public class DiagnosisPageViewModel : NotificationObject
    {
        private readonly DiagnosisPageModel _diagnosisPageModel = new DiagnosisPageModel();
        private readonly string _userName;

        public DiagnosisPageViewModel(string userName, int? serialNumber = null)
        {
            _userName = userName;
            SerialNumber = serialNumber;
            InitionalizePatiMessage();
        }

        private ICommand _patiMessage;
        private ICommand _uploadRecord;
        private ICommand _order;
        
        #region 属性

        public int? SerialNumber
        { 
            get => _diagnosisPageModel.SerialNumber;
            set
            {
                _diagnosisPageModel.SerialNumber = value;
                OnPropertyChanged(nameof(SerialNumber));
            }
        }
        public int? MedCardNum
        { 
            get => _diagnosisPageModel.MedCardNum;
            set
            {
                _diagnosisPageModel.MedCardNum = value;
                OnPropertyChanged(nameof(MedCardNum));
            }
        }
        public int? PatiAge
        { 
            get => _diagnosisPageModel.PatiAge;
            set
            {
                _diagnosisPageModel.PatiAge = value;
                OnPropertyChanged(nameof(PatiAge));
            }
        }
        public string PatiAuthName
        { 
            get => _diagnosisPageModel.PatiAuthName;
            set
            {
                _diagnosisPageModel.PatiAuthName = value;
                OnPropertyChanged(nameof(PatiAuthName));
            }
        }
        public string DoctDiagnosis
        { 
            get => _diagnosisPageModel.DoctDiagnosis;
            set
            {
                _diagnosisPageModel.DoctDiagnosis = value;
                OnPropertyChanged(nameof(DoctDiagnosis));
            }
        }
        public string MedRecord
        { 
            get => _diagnosisPageModel.MedRecord;
            set
            {
                _diagnosisPageModel.MedRecord = value;
                OnPropertyChanged(nameof(MedRecord));
            }
        }

        public bool SerialNumberIsEnable
        {
            get => _diagnosisPageModel.SerialNumberIsEnable;
            set
            {
                _diagnosisPageModel.SerialNumberIsEnable = value;
                OnPropertyChanged(nameof(SerialNumberIsEnable));
            }
        }

        #endregion

        #region 命令

        public ICommand PatiMessage
        {
            get => _patiMessage ?? (_patiMessage = new RelayCommand(InitionalizePatiMessage));
            set => _patiMessage = value;
        }
        public ICommand UploadRecord
        {
            get => _uploadRecord ?? (_uploadRecord = new RelayCommand(UpLoadMedRecord));
            set => _uploadRecord = value;
        }
        public ICommand Order
        {
            get => _order ?? (_order = new RelayCommand(Switch2Order));
            set => _order = value;
        }

        #endregion

        #region 命令方法

        // 初始化病人挂号信息
        public async void InitionalizePatiMessage()
        {
            if (SerialNumber != null)
            {
                PatiOutVisitService patiOutVisitService = new PatiOutVisitService(new PatiOutVisitRepository());
                var patiOutVisitResult =
                    await patiOutVisitService.QueryAsync(it => it.SerialNumber == _diagnosisPageModel.SerialNumber);

                if (patiOutVisitResult != null && patiOutVisitResult.Count > 0)
                {
                    MedCardNum = patiOutVisitResult[0].MedCardNum;
                    PatiAuthName = patiOutVisitResult[0].PatiName;

                    int patiID = patiOutVisitResult[0].PatiID;
                    PatiUserService patiUserService = new PatiUserService(new PatiUserRepository());
                    var patiResult = await patiUserService.FindAsync(patiID);
                    NormUserService normUserService = new NormUserService(new NormUserRepository());
                    var normResult = await normUserService.QueryAsync(it => it.UserName == patiResult.UserName);
                    if (normResult[0].BirthDate != null)
                        PatiAge = DateTime.Now.Year - ((DateTime) normResult[0].BirthDate).Year;
                    SerialNumberIsEnable = false;
                }
                else
                {
                    MessageBox.Show("查询结果为空，请确认流水号是否正确");
                    SerialNumberIsEnable = true;
                }
                    
            }
            else
                SerialNumberIsEnable = true;
        }
        
        // 将病历书写内容提交到数据库
        public async void UpLoadMedRecord()
        {
            if (_diagnosisPageModel.SerialNumber == null)
                MessageBox.Show("请填写医疗卡号");
            else if (string.IsNullOrEmpty(_diagnosisPageModel.MedRecord))
                MessageBox.Show("请输入诊断依据");
            else if (string.IsNullOrEmpty(_diagnosisPageModel.DoctDiagnosis))
                MessageBox.Show("请输入门诊诊断");
            else
            {
                PatiOutVisitService patiOutVisitService = new PatiOutVisitService(new PatiOutVisitRepository());
                var patiOutVisitResult =
                    await patiOutVisitService.QueryAsync(it => it.SerialNumber == _diagnosisPageModel.SerialNumber);

                diagnosis diag = new diagnosis
                {
                    SerialNumber = patiOutVisitResult[0].SerialNumber,
                    PatiID = patiOutVisitResult[0].PatiID,
                    DoctID = patiOutVisitResult[0].DoctID,
                    Diagnosis = _diagnosisPageModel.DoctDiagnosis,
                    Record = _diagnosisPageModel.MedRecord,
                    DiagTime = DateTime.Now
                };

                DiagnosisService diagnosisService = new DiagnosisService(new DiagnosisRepository());
                bool isEdit = await diagnosisService.CreateAsync(diag);
                MessageBox.Show(isEdit ? "添加成功" : "添加失败");
            }
        }
        
        // 切换到医嘱书写
        public void Switch2Order()
        {
            if (_diagnosisPageModel.SerialNumber != null)
                Messenger.Default.Send((int) _diagnosisPageModel.SerialNumber, "diagnosis2OrderWrite");
        }

        #endregion

        
    }
}