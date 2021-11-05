using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using MyApp.SHIS.Models;
using MyApp.SHIS.Repository.Repository;
using MyApp.SHIS.Services.Services;
using MyApp.SHIS.ViewModel.Common;

namespace MyApp.SHIS.ViewModel.PagesViewModels.PatiOutChargePage
{
    public class PatiOutChargePageViewModel : NotificationObject
    {
        private readonly PatiOutChargePageModel _patiOutChargePageModel = new PatiOutChargePageModel();
        private readonly string _userName;

        public PatiOutChargePageViewModel(string userName)
        {
            _userName = userName;
            ClearInfo();
        }
        
        private ICommand _patiInfoCommand;
        private ICommand _clearPatiCommand;
        private ICommand _leftClickCommand;
        private ICommand _medCardNumCommand;
        private ICommand _doctDeptCommand;
        private ICommand _doctNameCommand;
        private ICommand _patiNameCommand;
        private ICommand _paidAmountChangeCommand;
        private ICommand _confirmPaymentCommand;


        #region 属性

        public int? MedCardNum
        {
            get => _patiOutChargePageModel.MedCardNum;
            set
            {
                _patiOutChargePageModel.MedCardNum = value;
                OnPropertyChanged(nameof(MedCardNum));
            }
        }

        public string DoctDept
        {
            get => _patiOutChargePageModel.DoctDept;
            set
            {
                _patiOutChargePageModel.DoctDept = value;
                OnPropertyChanged(nameof(DoctDept));
            }
        }

        public string DoctName
        {
            get => _patiOutChargePageModel.DoctName;
            set
            {
                _patiOutChargePageModel.DoctName = value;
                OnPropertyChanged(nameof(DoctName));
            }
        }
        public string PatiName
        {
            get => _patiOutChargePageModel.PatiName;
            set
            {
                _patiOutChargePageModel.PatiName = value;
                OnPropertyChanged(nameof(PatiName));
            }
        }
        public pati_out_visit SelectedPatiOutVisit
        {
            get => _patiOutChargePageModel.SelectedPatiOutVisit;
            set
            {
                _patiOutChargePageModel.SelectedPatiOutVisit = value;
                OnPropertyChanged(nameof(SelectedPatiOutVisit));
            }
        }
        public ObservableCollection<pati_out_visit> PatiOutVisits
        {
            get => _patiOutChargePageModel.PatiOutVisits;
            set
            {
                _patiOutChargePageModel.PatiOutVisits = value;
                OnPropertyChanged(nameof(PatiOutVisits));
            }
        }

        public ObservableCollection<string> PayTypes
        {
            get => _patiOutChargePageModel.PayTypes;
            set
            {
                _patiOutChargePageModel.PayTypes = value;
                OnPropertyChanged(nameof(PayTypes));
            }
        }

        public string PayType
        {
            get => _patiOutChargePageModel.PayType;
            set
            {
                _patiOutChargePageModel.PayType = value;
                OnPropertyChanged(nameof(PayType));
            }
        }

        public decimal PayAmount
        {
            get => _patiOutChargePageModel.PayAmount;
            set
            {
                _patiOutChargePageModel.PayAmount = value;
                OnPropertyChanged(nameof(PayAmount));
            }
        }

        public decimal PaidAmount
        {
            get => _patiOutChargePageModel.PaidAmount;
            set
            {
                _patiOutChargePageModel.PaidAmount = value;
                OnPropertyChanged(nameof(PaidAmount));
            }
        }

        public decimal ChangeAmount
        {
            get => _patiOutChargePageModel.ChangeAmount;
            set
            {
                _patiOutChargePageModel.ChangeAmount = value;
                OnPropertyChanged(nameof(ChangeAmount));
            }
        }

        #endregion

        #region 命令

        public ICommand PatiInfoCommand
        {
            get => _patiInfoCommand ?? (_patiInfoCommand = new RelayCommand(PatiInfo));
            set => _patiInfoCommand = value;
        }

        public ICommand ClearPatiCommand
        {
            get => _clearPatiCommand ?? (_clearPatiCommand = new RelayCommand(ClearInfo));
            set => _clearPatiCommand = value;
        }

        public ICommand LeftClickCommand
        {
            get => _leftClickCommand ?? (_leftClickCommand = new RelayCommand(LeftClick));
            set => _leftClickCommand = value;
        }

        public ICommand MedCardNumCommand
        {
            get => _medCardNumCommand ?? (_medCardNumCommand = new RelayCommand(MedCardNumQuery));
            set => _medCardNumCommand = value;
        }

        public ICommand DoctDeptCommand
        {
            get => _doctDeptCommand ?? (_doctDeptCommand = new RelayCommand(DoctDeptQuery));
            set => _doctDeptCommand = value;
        }

        public ICommand DoctNameCommand
        {
            get => _doctNameCommand ?? (_doctNameCommand = new RelayCommand(DoctNameQuery));
            set => _doctNameCommand = value;
        }
        
        public ICommand PatiNameCommand
        {
            get => _patiNameCommand ?? (_patiNameCommand = new RelayCommand(PatiNameQuery));
            set => _patiNameCommand = value;
        }

        public ICommand PaidAmountChangeCommand
        {
            get => _paidAmountChangeCommand ?? (_paidAmountChangeCommand = new RelayCommand(CalChangeAmount));
            set => _paidAmountChangeCommand = value;
        }

        public ICommand ConfirmPaymentCommand
        {
            get => _confirmPaymentCommand ?? (_confirmPaymentCommand = new RelayCommand(ConfirmPayment));
            set => _confirmPaymentCommand = value;
        }

        #endregion

        #region 命令方法

        public async void PatiInfo()
        {
            PatiOutVisits.Clear();

            PatiOutVisitService patiOutVisitService = new PatiOutVisitService(new PatiOutVisitRepository());
            var patiOutVisitResult = await patiOutVisitService.QueryAsync(it => it.OutStatus == 0);
            
            patiOutVisitResult.ForEach(patiOutVisit => PatiOutVisits.Add(patiOutVisit));
        }
        public async void ClearInfo()
        {
            PatiOutVisits.Clear();

            PatiOutVisitService patiOutVisitService = new PatiOutVisitService(new PatiOutVisitRepository());
            var patiOutVisitResult = await patiOutVisitService.QueryAsync(it => it.OutStatus == 0);
            
            patiOutVisitResult.ForEach(patiOutVisit => PatiOutVisits.Add(patiOutVisit));
        }
        public async void MedCardNumQuery()
        {
            if (MedCardNum != null)
            {
                PatiOutVisits.Clear();
                PatiOutVisitService patiOutVisitService = new PatiOutVisitService(new PatiOutVisitRepository());
                var patiOutVisitResult =
                    await patiOutVisitService.QueryAsync(it => it.MedCardNum == MedCardNum && it.OutStatus == 0);

                patiOutVisitResult.ForEach(patiOutVisit => PatiOutVisits.Add(patiOutVisit));
            }
            else
                MessageBox.Show("请填写医疗卡号");
        }
        public async void PatiNameQuery()
        {
            if (!string.IsNullOrEmpty(PatiName))
            {
                PatiOutVisits.Clear();

                PatiOutVisitService patiOutVisitService = new PatiOutVisitService(new PatiOutVisitRepository());
                var patiOutVisitResult =
                    await patiOutVisitService.QueryAsync(it => it.PatiName == PatiName && it.OutStatus == 0);

                patiOutVisitResult.ForEach(patiOutVisit => PatiOutVisits.Add(patiOutVisit));
            }
            else
                MessageBox.Show("请填写患者姓名");
        }
        public async void DoctDeptQuery()
        {
            if (!string.IsNullOrEmpty(DoctDept))
            {
                PatiOutVisits.Clear();

                PatiOutVisitService patiOutVisitService = new PatiOutVisitService(new PatiOutVisitRepository());
                var patiOutVisitResult =
                    await patiOutVisitService.QueryAsync(it => it.DoctDept == DoctDept && it.OutStatus == 0);

                patiOutVisitResult.ForEach(patiOutVisit => PatiOutVisits.Add(patiOutVisit));
            }
            else
                MessageBox.Show("请填写医生科室");
        }
        public async void DoctNameQuery()
        {
            if (!string.IsNullOrEmpty(DoctName))
            {

                DoctUserService doctUserService = new DoctUserService(new DoctUserRepository());
                var doctResult = await doctUserService.QueryAsync(it => it.DoctName == DoctName);

                if (doctResult != null && doctResult.Count > 0)
                {
                    PatiOutVisits.Clear();

                    PatiOutVisitService patiOutVisitService = new PatiOutVisitService(new PatiOutVisitRepository());
                    var patiOutVisitResult =
                        await patiOutVisitService.QueryAsync(it => it.DoctID == doctResult[0].DoctID && it.OutStatus == 0);

                    patiOutVisitResult.ForEach(patiOutVisit => PatiOutVisits.Add(patiOutVisit));
                }
                else
                    MessageBox.Show("查询结果为空，请确认医生姓名");
            }
            else
                MessageBox.Show("请填写医生姓名");
        }
        public void LeftClick()
        {
            if(SelectedPatiOutVisit.PayAmount!= null)
                PayAmount = (decimal)SelectedPatiOutVisit.PayAmount;
        }

        public void CalChangeAmount()
        {
            if (_patiOutChargePageModel.PaidAmount > _patiOutChargePageModel.PayAmount)
                ChangeAmount = _patiOutChargePageModel.PaidAmount - _patiOutChargePageModel.PayAmount;
        }
        public async void ConfirmPayment()
        {
            if (SelectedPatiOutVisit == null)
                MessageBox.Show("请选择待缴费的挂号");
            else if (PayType == null)
                MessageBox.Show("缴费错误，请选择缴费方式");
            else if (_patiOutChargePageModel.PaidAmount < _patiOutChargePageModel.PayAmount)
                MessageBox.Show("缴费错误，请确认实付金额不小于应付金额");
            else
            {
                StaffUserService staffUserService = new StaffUserService(new StaffUserRepository());
                var staffResult = await staffUserService.QueryAsync(it => it.UserName == _userName);

                PatiOutVisitService patiOutVisitService = new PatiOutVisitService(new PatiOutVisitRepository());
                var patiOutVisit = await patiOutVisitService.FindAsync(SelectedPatiOutVisit.SerialNumber);
                patiOutVisit.OutStatus = 1;
                patiOutVisit.PaidAmount = _patiOutChargePageModel.PaidAmount;
                patiOutVisit.PayType = _patiOutChargePageModel.PayType;

                bool isEdit = await patiOutVisitService.EditAsync(patiOutVisit);
                
                PatiOutVisitSettleService patiOutVisitSettleService = new PatiOutVisitSettleService(new PatiOutVisitSettleRepository());
                pati_out_visit_settle patiOutVisitSettle = new pati_out_visit_settle
                {
                    SettleDate = DateTime.Now,
                    PayType = PayType,
                    PayAmount = _patiOutChargePageModel.PayAmount,
                    PaidAmount = _patiOutChargePageModel.PaidAmount,
                    ChangeAmount = _patiOutChargePageModel.ChangeAmount,
                    StaffID = staffResult[0].StaffID,
                    SerialNumber = SelectedPatiOutVisit.SerialNumber
                };
                bool isCreate = await patiOutVisitSettleService.CreateAsync(patiOutVisitSettle);

                MessageBox.Show(isEdit && isCreate ? "付费成功" : "付费失败");

            }
        }
        
        #endregion
    }
}