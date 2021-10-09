using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using MyApp.SHIS.Models;
using MyApp.SHIS.Repository.Repository;
using MyApp.SHIS.Services.Services;
using MyApp.SHIS.ViewModel.Common;

namespace MyApp.SHIS.ViewModel.PagesViewModels.UnRegisterPage
{
    public class UnRegisterPageViewModel : NotificationObject
    {
        private readonly UnRegisterPageModel _unRegisterPageModel = new UnRegisterPageModel();

        public UnRegisterPageViewModel()
        {
            InitionalizePatiOutVisitInfo();
        }

        private ICommand _refresh;
        private ICommand _unregister;
        private ICommand _refund;
        private ICommand _queryBySerialNumber;
        private ICommand _queryByMedCardNum;
        private ICommand _queryByPatiAuthName;
        private ICommand _queryByDoctAuthName;
        

        #region 属性

         public int? SerialNumber
        { 
            get => _unRegisterPageModel.SerialNumber;
            set
            {
                _unRegisterPageModel.SerialNumber = value;
                OnPropertyChanged(nameof(SerialNumber));
            }
        }
        public int? MedCardNum
        { 
            get => _unRegisterPageModel.MedCardNum;
            set
            {
                _unRegisterPageModel.MedCardNum = value;
                OnPropertyChanged(nameof(MedCardNum));
            }
        }
        public string PatiAuthName
        { 
            get => _unRegisterPageModel.PatiAuthName;
            set
            {
                _unRegisterPageModel.PatiAuthName = value;
                OnPropertyChanged(nameof(PatiAuthName));
            }
        }
        public string DoctAuthName
        { 
            get => _unRegisterPageModel.DoctAuthName;
            set
            {
                _unRegisterPageModel.DoctAuthName = value;
                OnPropertyChanged(nameof(DoctAuthName));
            }
        }
        public decimal TotalPay
        { 
            get => _unRegisterPageModel.TotalPay;
            set
            {
                _unRegisterPageModel.TotalPay = value;
                OnPropertyChanged(nameof(TotalPay));
            }
        }
        public decimal RefundPay
        { 
            get => _unRegisterPageModel.RefundPay;
            set
            {
                _unRegisterPageModel.RefundPay = value;
                OnPropertyChanged(nameof(RefundPay));
            }
        }
        public ObservableCollection<pati_out_visit> RegisterInfo
        { 
            get => _unRegisterPageModel.RegisterInfo;
            set
            {
                _unRegisterPageModel.RegisterInfo = value;
                OnPropertyChanged(nameof(RegisterInfo));
            }
        }
        public pati_out_visit SelectedPatiOutVisit
        {
            get => _unRegisterPageModel.SelectedPatiOutVisit;
            set
            {
                _unRegisterPageModel.SelectedPatiOutVisit = value;
                OnPropertyChanged(nameof(SelectedPatiOutVisit));
            }
        }
        
        // Hint
        public string SerialNumberHint
        { 
            get => _unRegisterPageModel.SerialNumberHint;
            set
            {
                _unRegisterPageModel.SerialNumberHint = value;
                OnPropertyChanged(nameof(SerialNumberHint));
            }
        }
        public string MedCardNumHint
        { 
            get => _unRegisterPageModel.MedCardNumHint;
            set
            {
                _unRegisterPageModel.MedCardNumHint = value;
                OnPropertyChanged(nameof(MedCardNumHint));
            }
        }
        public string PatiAuthNameHint
        { 
            get => _unRegisterPageModel.PatiAuthNameHint;
            set
            {
                _unRegisterPageModel.PatiAuthNameHint = value;
                OnPropertyChanged(nameof(PatiAuthNameHint));
            }
        }
        public string DoctAuthNameHint
        { 
            get => _unRegisterPageModel.DoctAuthNameHint;
            set
            {
                _unRegisterPageModel.DoctAuthNameHint = value;
                OnPropertyChanged(nameof(DoctAuthNameHint));
            }
        }
        public string TotalPayHint
        { 
            get => _unRegisterPageModel.TotalPayHint;
            set
            {
                _unRegisterPageModel.TotalPayHint = value;
                OnPropertyChanged(nameof(TotalPayHint));
            }
        }
        public string RefundPayHint
        { 
            get => _unRegisterPageModel.RefundPayHint;
            set
            {
                _unRegisterPageModel.RefundPayHint = value;
                OnPropertyChanged(nameof(RefundPayHint));
            }
        }

        #endregion


        #region 命令

        public ICommand Refresh
        {
            get => _refresh ?? (_refresh = new RelayCommand(InitionalizePatiOutVisitInfo));
            set => _refresh = value;
        }
        public ICommand Unregister
        {
            get => _unregister ?? (_unregister = new RelayCommand(Unregist));
            set => _unregister = value;
        }
        public ICommand Refund
        {
            get => _refund ?? (_refund = new RelayCommand(RefundPays));
            set => _refund = value;
        }
        public ICommand QueryBySerialNumber
        {
            get => _queryBySerialNumber ?? (_queryBySerialNumber = new RelayCommand(UpdateDataGridBySerialNumber));
            set => _queryBySerialNumber = value;
        }
        public ICommand QueryByMedCardNum
        {
            get => _queryByMedCardNum ?? (_queryByMedCardNum = new RelayCommand(UpdateDataGridByMedCardNum));
            set => _queryByMedCardNum = value;
        }
        public ICommand QueryByPatiAuthName
        {
            get => _queryByPatiAuthName ?? (_queryByPatiAuthName = new RelayCommand(UpdateDataGridByPatiAuthName));
            set => _queryByPatiAuthName = value;
        }
        public ICommand QueryByDoctAuthName
        {
            get => _queryByDoctAuthName ?? (_queryByDoctAuthName = new RelayCommand(UpdateDataGridByDoctAuthName));
            set => _queryByDoctAuthName = value;
        }

        #endregion。。

        #region 命令方法

        // 退号
        public async void Unregist()
        {
            PatiOutVisitService patiOutVisitService = new PatiOutVisitService(new PatiOutVisitRepository());
            bool isEdit = await patiOutVisitService.DeleteAsync(SelectedPatiOutVisit.SerialNumber);
            InitionalizePatiOutVisitInfo();
            MessageBox.Show(isEdit ? "成功" : "失败");
        }
        // 退款
        public void RefundPays()
        {
            
        }
        // 根据流水号查询
        public async void UpdateDataGridBySerialNumber()
        {
            if (SerialNumber != null)
            {
                PatiOutVisitService patiOutVisitService = new PatiOutVisitService(new PatiOutVisitRepository());
                var patiOutVisitResult = await patiOutVisitService.QueryAsync(it => it.SerialNumber == SerialNumber);

                if (patiOutVisitResult != null && patiOutVisitResult.Count > 0)
                {
                    RegisterInfo.Clear();
                    foreach (var patiOutVisit in patiOutVisitResult)
                        RegisterInfo.Add(patiOutVisit);
                }
                else
                    MessageBox.Show("查询结果为空，请确认流水号并重新输入");

            }
            else
                MessageBox.Show("请输入流水号");

        }
        // 根据医疗卡号查询
        public async void UpdateDataGridByMedCardNum()
        {
            if (MedCardNum != null)
            {
                PatiOutVisitService patiOutVisitService = new PatiOutVisitService(new PatiOutVisitRepository());
                var patiOutVisitResult = await patiOutVisitService.QueryAsync(it => it.MedCardNum == MedCardNum);

                if (patiOutVisitResult != null && patiOutVisitResult.Count > 0)
                {
                    RegisterInfo.Clear();
                    foreach (var patiOutVisit in patiOutVisitResult)
                        RegisterInfo.Add(patiOutVisit);
                }
                else
                    MessageBox.Show("查询结果为空，请确认医疗卡号并重新输入");
            }
            else
                MessageBox.Show("请输入医疗卡号");
        }
        // 根据患者姓名查询
        public async void UpdateDataGridByPatiAuthName()
        {
            if (SerialNumber != null)
            {
                PatiOutVisitService patiOutVisitService = new PatiOutVisitService(new PatiOutVisitRepository());
                var patiOutVisitResult = await patiOutVisitService.QueryAsync(it => it.PatiName == PatiAuthName);

                if (patiOutVisitResult != null && patiOutVisitResult.Count > 0)
                {
                    RegisterInfo.Clear();
                    foreach (var patiOutVisit in patiOutVisitResult)
                        RegisterInfo.Add(patiOutVisit);
                }
                else
                    MessageBox.Show("查询结果为空，请确认患者姓名并重新输入");

            }
            else
                MessageBox.Show("请输入患者姓名");
        }
        // 根据医生姓名查询
        public async void UpdateDataGridByDoctAuthName()
        {
            if (SerialNumber != null)
            {
                DoctUserService doctUserService = new DoctUserService(new DoctUserRepository());
                var doctUserResult = await doctUserService.QueryAsync(it => it.DoctName == DoctAuthName);
                if (doctUserResult != null && doctUserResult.Count > 0)
                {
                    PatiOutVisitService patiOutVisitService = new PatiOutVisitService(new PatiOutVisitRepository());
                    var patiOutVisitResult = await patiOutVisitService.QueryAsync(it => it.DoctID == doctUserResult[0].DoctID);

                    if (patiOutVisitResult != null && patiOutVisitResult.Count > 0)
                    {
                        RegisterInfo.Clear();
                        foreach (var patiOutVisit in patiOutVisitResult)
                            RegisterInfo.Add(patiOutVisit);
                    }
                    else
                        MessageBox.Show("查询结果为空，请确认医生姓名并重新输入");
                }
                else
                    MessageBox.Show("未查询到医生，请确认医生姓名并重新输入");
            }
            else
                MessageBox.Show("请输入医生姓名");
        }
        

        #endregion

        public async void InitionalizePatiOutVisitInfo()
        {
            RegisterInfo.Clear();
            PatiOutVisitService patiOutVisitService = new PatiOutVisitService(new PatiOutVisitRepository());
            var patiOutVisitResult = await patiOutVisitService.QueryAsync();

            foreach (var patiOutVisit in patiOutVisitResult)
                RegisterInfo.Add(patiOutVisit);
        }
    }
}