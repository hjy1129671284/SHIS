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
        private readonly OrderExecPagemodel _orderExecPagemodel = new OrderExecPagemodel();
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

        #region 属性

        public int? OrderID
        { 
            get => _orderExecPagemodel.OrderID;
            set
            {
                _orderExecPagemodel.OrderID = value;
                OnPropertyChanged(nameof(OrderID));
            }
        }
        public int? MedicineAmount
        { 
            get => _orderExecPagemodel.MedicineAmount;
            set
            {
                _orderExecPagemodel.MedicineAmount = value;
                OnPropertyChanged(nameof(MedicineAmount));
            }
        }
        public string PatiAuthName
        { 
            get => _orderExecPagemodel.PatiAuthName;
            set
            {
                _orderExecPagemodel.PatiAuthName = value;
                OnPropertyChanged(nameof(PatiAuthName));
            }
        }
        public string DoctDept
        { 
            get => _orderExecPagemodel.DoctDept;
            set
            {
                _orderExecPagemodel.DoctDept = value;
                OnPropertyChanged(nameof(DoctDept));
            }
        }
        public string DoctName
        { 
            get => _orderExecPagemodel.DoctName;
            set
            {
                _orderExecPagemodel.DoctName = value;
                OnPropertyChanged(nameof(DoctName));
            }
        }
        public string MedicineName
        { 
            get => _orderExecPagemodel.MedicineName;
            set
            {
                _orderExecPagemodel.MedicineName = value;
                OnPropertyChanged(nameof(MedicineName));
            }
        }
        public string MedicineSpec
        { 
            get => _orderExecPagemodel.MedicineSpec;
            set
            {
                _orderExecPagemodel.MedicineSpec = value;
                OnPropertyChanged(nameof(MedicineSpec));
            }
        }
        public string MedicineUse
        { 
            get => _orderExecPagemodel.MedicineUse;
            set
            {
                _orderExecPagemodel.MedicineUse = value;
                OnPropertyChanged(nameof(MedicineUse));
            }
        }
        public string Note
        {
            get => _orderExecPagemodel.Note;
            set
            {
                _orderExecPagemodel.Note = value;
                OnPropertyChanged(nameof(Note));
            }
        }
        public decimal MedicinePrice
        { 
            get => _orderExecPagemodel.MedicinePrice;
            set
            {
                _orderExecPagemodel.MedicinePrice = value;
                OnPropertyChanged(nameof(MedicinePrice));
            }
        }
        public decimal MedicineTotalPrice
        { 
            get => _orderExecPagemodel.MedicineTotalPrice;
            set
            {
                _orderExecPagemodel.MedicineTotalPrice = value;
                OnPropertyChanged(nameof(MedicineTotalPrice));
            }
        }
        public bool OrderIDIsEnable 
        { 
            get => _orderExecPagemodel.OrderIDIsEnable;
            set
            {
                _orderExecPagemodel.OrderIDIsEnable = value;
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
                    bool isCreate = await orderExecService.CreateAsync(orderExec);
                    bool isEdit = await orderService.EditAsync(orderResult);
                    MessageBox.Show(isCreate && isEdit ? "执行成功" : "执行失败");
                }
                else if (orderResult.OrderType == 0)
                    MessageBox.Show("该医嘱未缴费，请通知患者前往缴费");
                else if (orderResult.OrderType == 2)
                    MessageBox.Show("该医嘱已执行");
                
                
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
                    PatiOutVisitService patiOutVisitService = new PatiOutVisitService(new PatiOutVisitRepository());
                    var patiResult = await patiOutVisitService.FindAsync(orderResult.PatiID);

                    DoctUserService doctUserService = new DoctUserService(new DoctUserRepository());
                    var doctResult = await doctUserService.QueryAsync(it => it.DoctID == orderResult.DoctID);

                    PatiAuthName = patiResult.PatiName;
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
                }
                else if (orderResult.OrderType == 0)
                    MessageBox.Show("该医嘱未缴费，请通知患者前往缴费");
                else if (orderResult.OrderType == 2)
                    MessageBox.Show("该医嘱已执行");
                
            }
        }

    }
}