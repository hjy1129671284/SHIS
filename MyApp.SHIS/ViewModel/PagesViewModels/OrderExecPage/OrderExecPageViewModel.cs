using System;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MyApp.SHIS.Models;
using MyApp.SHIS.Repository.Repository;
using MyApp.SHIS.Services.Services;
using MyApp.SHIS.ViewModel.Common;

namespace MyApp.SHIS.ViewModel.PagesViewModels.OrderExecPage
{
    public class OrderExecPageViewModel : NotificationObject
    {
        private readonly OrderExecPagemodel _orderExecPageModel = new OrderExecPagemodel();
        private readonly string _userName;

        public OrderExecPageViewModel(string userName, int? orderID = null)
        {
            _userName = userName;
            OrderID = orderID;
            InitializeOrderInformation();
        }

        private ICommand _initializeCommand;
        private ICommand _backCommand;
        private ICommand _execCommand;
        private ICommand _reOrderCommand;

        #region 属性

        public int? OrderID
        { 
            get => _orderExecPageModel.OrderID;
            set
            {
                _orderExecPageModel.OrderID = value;
                OnPropertyChanged(nameof(OrderID));
            }
        }
        public int? MedicineAmount
        { 
            get => _orderExecPageModel.MedicineAmount;
            set
            {
                _orderExecPageModel.MedicineAmount = value;
                OnPropertyChanged(nameof(MedicineAmount));
            }
        }
        public string PatiAuthName
        { 
            get => _orderExecPageModel.PatiAuthName;
            set
            {
                _orderExecPageModel.PatiAuthName = value;
                OnPropertyChanged(nameof(PatiAuthName));
            }
        }
        public string DoctDept
        { 
            get => _orderExecPageModel.DoctDept;
            set
            {
                _orderExecPageModel.DoctDept = value;
                OnPropertyChanged(nameof(DoctDept));
            }
        }
        public string DoctName
        { 
            get => _orderExecPageModel.DoctName;
            set
            {
                _orderExecPageModel.DoctName = value;
                OnPropertyChanged(nameof(DoctName));
            }
        }
        public string MedicineName
        { 
            get => _orderExecPageModel.MedicineName;
            set
            {
                _orderExecPageModel.MedicineName = value;
                OnPropertyChanged(nameof(MedicineName));
            }
        }
        public string MedicineSpec
        { 
            get => _orderExecPageModel.MedicineSpec;
            set
            {
                _orderExecPageModel.MedicineSpec = value;
                OnPropertyChanged(nameof(MedicineSpec));
            }
        }
        public string MedicineUse
        { 
            get => _orderExecPageModel.MedicineUse;
            set
            {
                _orderExecPageModel.MedicineUse = value;
                OnPropertyChanged(nameof(MedicineUse));
            }
        }
        public string DoctDiagnosis
        {
            get => _orderExecPageModel.DoctDiagnosis;
            set
            {
                _orderExecPageModel.DoctDiagnosis = value;
                OnPropertyChanged(nameof(DoctDiagnosis));
            }
        }
        public string Note
        {
            get => _orderExecPageModel.Note;
            set
            {
                _orderExecPageModel.Note = value;
                OnPropertyChanged(nameof(Note));
            }
        }
        public decimal MedicinePrice
        { 
            get => _orderExecPageModel.MedicinePrice;
            set
            {
                _orderExecPageModel.MedicinePrice = value;
                OnPropertyChanged(nameof(MedicinePrice));
            }
        }
        public decimal MedicineTotalPrice
        { 
            get => _orderExecPageModel.MedicineTotalPrice;
            set
            {
                _orderExecPageModel.MedicineTotalPrice = value;
                OnPropertyChanged(nameof(MedicineTotalPrice));
            }
        }
        public bool OrderIDIsEnable 
        { 
            get => _orderExecPageModel.OrderIDIsEnable;
            set
            {
                _orderExecPageModel.OrderIDIsEnable = value;
                OnPropertyChanged(nameof(OrderIDIsEnable));
            }
        }
        
        #endregion

        #region 命令

        public ICommand InitializeCommand
        {
            get => _initializeCommand ?? (_initializeCommand = new RelayCommand(Switch2OrderList));
            set => _initializeCommand = value;
        }
        public ICommand BackCommand
        {
            get => _backCommand ?? (_backCommand = new RelayCommand(Switch2OrderList));
            set => _backCommand = value;
        }
        public ICommand ExecCommand
        {
            get => _execCommand ?? (_execCommand = new RelayCommand(OrderExec));
            set => _execCommand = value;
        }

        public ICommand ReOrderCommand
        {
            get => _reOrderCommand ?? (_reOrderCommand = new RelayCommand(ReOrder));
            set => _reOrderCommand = value;
        }


        #endregion

        #region 命令方法

        public void Switch2OrderList()
        {
            Messenger.Default.Send(_userName, "switch2OrderList");
        }
        
        public async void OrderExec()
        {
            if (OrderID != null)
            {
                OrderService orderService = new OrderService(new OrderRepository());
                var orderResult = await orderService.FindAsync((int)OrderID);

                if (orderResult.OrderType == 1)
                {
                    StaffUserService staffUserService = new StaffUserService(new StaffUserRepository());
                    var staffResult = await staffUserService.QueryAsync(it => it.UserName == _userName);

                    order_exec orderExec = new order_exec
                    {
                        OrderID = (int) OrderID,
                        StaffID = staffResult[0].StaffID,
                        ExecTime = DateTime.Now,
                        Note = Note
                    };
                    orderResult.OrderType = 2;
                    
                    OrderExecService orderExecService = new OrderExecService(new OrderExecRepository());
                    PatiOutVisitService patiOutVisitService = new PatiOutVisitService(new PatiOutVisitRepository());
                    var patiOutVisitResult = 
                        await patiOutVisitService.QueryAsync(it => it.SerialNumber == orderResult.SerialNumber);
                    pati_out_visit patiOutVisit = patiOutVisitResult[0];
                    patiOutVisit.OutStatus = 2;
                    patiOutVisit.VisitDate = DateTime.Now;

                    bool isCreate = await orderExecService.CreateAsync(orderExec);
                    bool isPatiOutVisitEdit = await patiOutVisitService.EditAsync(patiOutVisit);
                    bool isOrderEdit = await orderService.EditAsync(orderResult);
                    MessageBox.Show(isCreate && isPatiOutVisitEdit && isOrderEdit ? "执行成功" : "执行失败");
                }
                else if (orderResult.OrderType == 0)
                    MessageBox.Show("该医嘱未缴费，请通知患者前往缴费");
                else if (orderResult.OrderType == 2)
                    MessageBox.Show("该医嘱已执行");
                
                
            }
        }
        
        public async void ReOrder()
        {
            if (_orderExecPageModel.OrderID != null)
            {
                OrderService orderService = new OrderService(new OrderRepository());
                var orderReuslt = await orderService.FindAsync((int)_orderExecPageModel.OrderID);
                
                PatiOutVisitService patiOutVisitService = new PatiOutVisitService(new PatiOutVisitRepository());
                var patiOutVisitResult = await patiOutVisitService.FindAsync(orderReuslt.SerialNumber);

                PatiUserService patiUserService = new PatiUserService(new PatiUserRepository());
                var patiResult = await patiUserService.FindAsync(orderReuslt.PatiID);
                NormUserService normUserService = new NormUserService(new NormUserRepository());
                var normResult = await normUserService.FindAsync(patiResult.NormID);

                normResult.Gold += orderReuslt.TotalPay;
                patiOutVisitResult.OutStatus = 1;
                orderReuslt.OrderType = 3;
                bool isNormEdit = await normUserService.EditAsync(normResult);
                bool isPatiOutVisitEdit = await patiOutVisitService.EditAsync(patiOutVisitResult);
                bool isOrderEdit = await orderService.EditAsync(orderReuslt);
                
                MessageBox.Show(isNormEdit && isPatiOutVisitEdit && isOrderEdit ? "退回成功" : "退回失败");
            }
            
            
        }

        #endregion

        public async void InitializeOrderInformation()
        {
            if (OrderID == null)
                OrderIDIsEnable = true;
            else
            {
                OrderService orderService = new OrderService(new OrderRepository());
                var orderResult = await orderService.FindAsync((int)OrderID);

                if (orderResult.OrderType == 1)
                {
                    PatiUserService patiUserService = new PatiUserService(new PatiUserRepository());
                    var patiResult = await patiUserService.FindAsync(orderResult.PatiID);

                    DoctUserService doctUserService = new DoctUserService(new DoctUserRepository());
                    var doctResult = await doctUserService.QueryAsync(it => it.DoctID == orderResult.DoctID);

                    PatiAuthName = patiResult.UserAuthName;
                    DoctDept = doctResult[0].DoctDept;
                    DoctName = doctResult[0].DoctName;

                    if (orderResult.MedicineID != null)
                    {
                        MedicineService medicineService = new MedicineService(new MedicineRepository());
                        var medicineResult = await medicineService.FindAsync((int) orderResult.MedicineID);

                        MedicineName = medicineResult.MedicineName;
                        MedicineSpec = medicineResult.MedicineSpec;
                        MedicineUse = medicineResult.MedicineUse;
                        MedicineAmount = orderResult.MedicineAmount;
                        MedicinePrice = medicineResult.MedicinePrice;
                    
                        if(MedicineAmount != null)
                            MedicineTotalPrice = MedicinePrice * (int)MedicineAmount;

                        OrderIDIsEnable = false;
                    }

                    DiagnosisService diagnosisService = new DiagnosisService(new DiagnosisRepository());
                    var diagResult =
                        await diagnosisService.QueryAsync(it => it.SerialNumber == orderResult.SerialNumber);
                    DoctDiagnosis = diagResult[0].Diagnosis;
                }
                else if (orderResult.OrderType == 0)
                    MessageBox.Show("该医嘱未缴费，请通知患者前往缴费");
                else if (orderResult.OrderType == 2)
                    MessageBox.Show("该医嘱已执行");
                else if (orderResult.OrderType == 3)
                    MessageBox.Show("该医嘱已退回");
                
            }
        }
        

    }
}