using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using MyApp.SHIS.Models;
using MyApp.SHIS.Repository.Repository;
using MyApp.SHIS.Services.Services;
using MyApp.SHIS.ViewModel.Common;

namespace MyApp.SHIS.ViewModel.PagesViewModels.OrderWritePage
{
    public class OrderWritePageViewModel : NotificationObject
    {
        private readonly OrderWritePageModel _orderWritePageModel = new OrderWritePageModel();
        private string _userName;

        public OrderWritePageViewModel(string userName, int? serialNumber)
        {
            _userName = userName;
            SerialNumber = serialNumber;
            SerialNumberIsEnable = true;
            if(serialNumber != null)
                GetPatiImformation();

            GetMedicineNames();
        }

        private ICommand _patiInformation;
        private ICommand _clean;
        private ICommand _medicineInformation;
        private ICommand _medicineAdd;
        private ICommand _filter;
        private ICommand _calTotalPay;

        #region 属性

        public int? SerialNumber
        { 
            get => _orderWritePageModel.SerialNumber;
            set
            {
                _orderWritePageModel.SerialNumber = value;
                OnPropertyChanged(nameof(SerialNumber));
            }
        }
        public int? MedCardNum
        { 
            get => _orderWritePageModel.MedCardNum;
            set
            {
                _orderWritePageModel.MedCardNum = value;
                OnPropertyChanged(nameof(MedCardNum));
            }
        }
        public int? PatiAge
        { 
            get => _orderWritePageModel.PatiAge;
            set
            {
                _orderWritePageModel.PatiAge = value;
                OnPropertyChanged(nameof(PatiAge));
            }
        }
        public string PatiAuthName
        { 
            get => _orderWritePageModel.PatiAuthName;
            set
            {
                _orderWritePageModel.PatiAuthName = value;
                OnPropertyChanged(nameof(PatiAuthName));
            }
        }
        public bool SerialNumberIsEnable
        {
            get => _orderWritePageModel.SerialNumberIsEnable;
            set
            {
                _orderWritePageModel.SerialNumberIsEnable = value;
                OnPropertyChanged(nameof(SerialNumberIsEnable));
            }
        }
        public bool MedicineDropIsOpen
        {
            get => _orderWritePageModel.MedicineDropIsOpen;
            set
            {
                _orderWritePageModel.MedicineDropIsOpen = value;
                OnPropertyChanged(nameof(MedicineDropIsOpen));
            }
        }
        public string MedicineName
        {
            get => _orderWritePageModel.MedicineName;
            set
            {
                _orderWritePageModel.MedicineName = value;
                OnPropertyChanged(nameof(MedicineName));
            }
        }
        public string MedicineInputName
        {
            get => _orderWritePageModel.MedicineInputName;
            set
            {
                _orderWritePageModel.MedicineInputName = value;
                OnPropertyChanged(nameof(MedicineInputName));
            }
        }
        public string MedicineSpec
        {
            get => _orderWritePageModel.MedicineSpec;
            set
            {
                _orderWritePageModel.MedicineSpec = value;
                OnPropertyChanged(nameof(MedicineSpec));
            }
        }

        public string MedicineUse
        {
            get => _orderWritePageModel.MedicineUse;
            set
            {
                _orderWritePageModel.MedicineUse = value;
                OnPropertyChanged(nameof(MedicineUse));
            }
        }

        public decimal MedicinePrice
        {
            get => _orderWritePageModel.MedicinePrice;
            set
            {
                _orderWritePageModel.MedicinePrice = value;
                OnPropertyChanged(nameof(MedicinePrice));
            }
        }

        public int? MedicineAmount
        {
            get => _orderWritePageModel.MedicineAmount;
            set
            {
                _orderWritePageModel.MedicineAmount = value;
                OnPropertyChanged(nameof(MedicineAmount));
            }
        }

        public decimal TotalPay
        {
            get => _orderWritePageModel.TotalPay;
            set
            {
                _orderWritePageModel.TotalPay = value;
                OnPropertyChanged(nameof(TotalPay));
            }
        }

        public ObservableCollection<string> MedicineNames
        {
            get => _orderWritePageModel.MedicineNames;
            set
            {
                _orderWritePageModel.MedicineNames = value;
                OnPropertyChanged(nameof(MedicineNames));
            }
        }

        // Hint
        public string SerialNumberHint
        {
            get => _orderWritePageModel.SerialNumberHint;
            set
            {
                _orderWritePageModel.SerialNumberHint = value;
                OnPropertyChanged(nameof(SerialNumberHint));
            }
        }

        #endregion

        #region 命令

        public ICommand PatiInformation
        {
            get => _patiInformation ?? (_patiInformation = new RelayCommand(GetPatiImformation));
            set => _patiInformation = value;
        }
        public ICommand Clean
        {
            get => _clean ?? (_clean = new RelayCommand(CleanImformation));
            set => _clean = value;
        }
        public ICommand MedicineInformation
        {
            get => _medicineInformation ?? (_medicineInformation = new RelayCommand(GetMedicineImformation));
            set => _medicineInformation = value;
        }
        public ICommand MedicineAdd
        {
            get => _medicineAdd ?? (_medicineAdd = new RelayCommand(AddOrderImformation));
            set => _medicineAdd = value;
        }
        public ICommand Filter
        {
            get => _filter ?? (_filter = new RelayCommand(FilterMedicineName));
            set => _filter = value;
        }
        public ICommand CalTotalPay
        {
            get => _calTotalPay ?? (_calTotalPay = new RelayCommand(CalculateTotalPay));
            set => _calTotalPay = value;
        }


        #endregion

        #region 命令方法

        // 根据流水号得到病人信息
        public async void GetPatiImformation()
        {
            if (_orderWritePageModel.SerialNumber != null)
            {
                PatiOutVisitService patiOutVisitService = new PatiOutVisitService(new PatiOutVisitRepository());
                var patiOutVisitResult = await patiOutVisitService.QueryAsync(it => it.SerialNumber == _orderWritePageModel.SerialNumber);
                if (patiOutVisitResult != null && patiOutVisitResult.Count > 0)
                {
                    MedCardNum = patiOutVisitResult[0].MedCardNum;
                    PatiAuthName = patiOutVisitResult[0].PatiName;

                    NormUserService normUserService = new NormUserService(new NormUserRepository());
                    var normResult = await normUserService.QueryAsync(it => it.MedCardNum == _orderWritePageModel.MedCardNum);
                    if (normResult[0].BirthDate != null)
                        PatiAge = DateTime.Now.Year - ((DateTime) normResult[0].BirthDate).Year;
                    
                    SerialNumberIsEnable = false;
                }
                else
                {
                    MessageBox.Show("查询结果为空，请确认流水号");
                    SerialNumberIsEnable = true;
                }
                    
            }
            else
                SerialNumberIsEnable = true;

        }
        // 清空病人信息
        public void CleanImformation()
        {
            SerialNumberHint = _orderWritePageModel.SerialNumber.ToString();
            SerialNumber = null;
            MedCardNum = null;
            PatiAuthName = null;
            PatiAge = null;
            
            SerialNumberIsEnable = true;
        }
        // 根据药品名称更新药品信息
        public async void GetMedicineImformation()
        {
            if (_orderWritePageModel.MedicineName != null)
            {
                if (MedicineNames.Contains(_orderWritePageModel.MedicineName))
                {
                    MedicineService medicineService = new MedicineService(new MedicineRepository());
                    var medicineResult =
                        await medicineService.QueryAsync(it => it.MedicineName == _orderWritePageModel.MedicineName);
                    if (medicineResult != null && medicineResult.Count > 0)
                    {
                        MedicineSpec = medicineResult[0].MedicineSpec;
                        MedicineUse = medicineResult[0].MedicineUse;
                        MedicinePrice = medicineResult[0].MedicinePrice;

                        if (MedicineAmount == null)
                            MedicineAmount = 1;
                        CalculateTotalPay();
                    }
                    else
                        MessageBox.Show("没能查询到该药品，请重试");
                }
            }
            
        }
        public async void AddOrderImformation()
        {
            // 判断流水号是否填写
            if (_orderWritePageModel.SerialNumber == null)
                MessageBox.Show("请填写流水号");
            else if (_orderWritePageModel.MedicineName == null)
                MessageBox.Show("请选择药品");
            else
            {
                PatiOutVisitService patiOutVisitService = new PatiOutVisitService(new PatiOutVisitRepository());
                var patiOutVisitResult =
                    await patiOutVisitService.QueryAsync(it => it.SerialNumber == _orderWritePageModel.SerialNumber);

                MedicineService medicineService = new MedicineService(new MedicineRepository());
                var medicineResult =
                    await medicineService.QueryAsync(it => it.MedicineName == _orderWritePageModel.MedicineName);
                
                if (patiOutVisitResult != null && medicineResult != null  && patiOutVisitResult.Count > 0 && medicineResult.Count > 0)
                {
                    order o = new order
                    {
                        SerialNumber = (int) _orderWritePageModel.SerialNumber,
                        PatiID = patiOutVisitResult[0].PatiID,
                        DoctID = patiOutVisitResult[0].DoctID,
                        OrderTime = DateTime.Now,
                        MedicineID = medicineResult[0].MedicineID,
                        MedicineAmount = _orderWritePageModel.MedicineAmount,
                        TotalPay = _orderWritePageModel.TotalPay,
                        OrderType = 0
                    };

                    OrderService orderService = new OrderService(new OrderRepository());
                    bool isEdit = await orderService.CreateAsync(o);
                    MessageBox.Show(isEdit ? "添加成功" : "添加失败");
                }
            }
        }

        // 根据输入的文字筛选药品
        public async void FilterMedicineName()
        {

            if (_orderWritePageModel.MedicineInputName != null)
            {
                Regex rx = new Regex("^[\u4e00-\u9fa5]$");
                if (rx.IsMatch(_orderWritePageModel.MedicineInputName.Substring(0)))
                {
                    MedicineNames.Clear();
                    MedicineService medicineService = new MedicineService(new MedicineRepository());
                    var medicineResult = await medicineService.QueryAsync();

                    foreach (var medicine in medicineResult)
                    {
                        if (medicine.MedicineName.Contains(_orderWritePageModel.MedicineInputName))
                            MedicineNames.Add(medicine.MedicineName);
                    }

                    MedicineDropIsOpen = true;
                }
                else
                    GetMedicineNames();
            }
            else
                GetMedicineNames();

        }

        // 计算药品总价格
        public void CalculateTotalPay()
        {
            if (MedicineAmount != null)
                TotalPay = (int)MedicineAmount * _orderWritePageModel.MedicinePrice;
        }
        #endregion

        public async void GetMedicineNames()
        {
            MedicineNames.Clear();
            MedicineService medicineService = new MedicineService(new MedicineRepository());
            var medicineResult = await medicineService.QueryAsync();

            foreach (var medicine in medicineResult)
            {
                MedicineNames.Add(medicine.MedicineName);
            }
        }
    }
}