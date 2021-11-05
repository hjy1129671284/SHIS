using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using MyApp.SHIS.Models;
using MyApp.SHIS.Repository.Repository;
using MyApp.SHIS.Services.Services;
using MyApp.SHIS.ViewModel.Common;

namespace MyApp.SHIS.ViewModel.PagesViewModels.OrderChargePage
{
    public class OrderChargePageViewModel : NotificationObject
    {
        private readonly OrderChargePageModel _orderChargePageModel = new OrderChargePageModel();
        private readonly string _userName;

        public OrderChargePageViewModel(string userName)
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
            get => _orderChargePageModel.MedCardNum;
            set
            {
                _orderChargePageModel.MedCardNum = value;
                OnPropertyChanged(nameof(MedCardNum));
            }
        }

        public string DoctDept
        {
            get => _orderChargePageModel.DoctDept;
            set
            {
                _orderChargePageModel.DoctDept = value;
                OnPropertyChanged(nameof(DoctDept));
            }
        }

        public string DoctName
        {
            get => _orderChargePageModel.DoctName;
            set
            {
                _orderChargePageModel.DoctName = value;
                OnPropertyChanged(nameof(DoctName));
            }
        }
        public string PatiName
        {
            get => _orderChargePageModel.PatiName;
            set
            {
                _orderChargePageModel.PatiName = value;
                OnPropertyChanged(nameof(PatiName));
            }
        }
        public order SelectedOrder
        {
            get => _orderChargePageModel.SelectedOrder;
            set
            {
                _orderChargePageModel.SelectedOrder = value;
                OnPropertyChanged(nameof(SelectedOrder));
            }
        }
        public ObservableCollection<order> Orders
        {
            get => _orderChargePageModel.Orders;
            set
            {
                _orderChargePageModel.Orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }

        public ObservableCollection<string> PayTypes
        {
            get => _orderChargePageModel.PayTypes;
            set
            {
                _orderChargePageModel.PayTypes = value;
                OnPropertyChanged(nameof(PayTypes));
            }
        }

        public string PayType
        {
            get => _orderChargePageModel.PayType;
            set
            {
                _orderChargePageModel.PayType = value;
                OnPropertyChanged(nameof(PayType));
            }
        }

        public decimal PayAmount
        {
            get => _orderChargePageModel.PayAmount;
            set
            {
                _orderChargePageModel.PayAmount = value;
                OnPropertyChanged(nameof(PayAmount));
            }
        }

        public decimal PaidAmount
        {
            get => _orderChargePageModel.PaidAmount;
            set
            {
                _orderChargePageModel.PaidAmount = value;
                OnPropertyChanged(nameof(PaidAmount));
            }
        }

        public decimal ChangeAmount
        {
            get => _orderChargePageModel.ChangeAmount;
            set
            {
                _orderChargePageModel.ChangeAmount = value;
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
            OrderService orderService = new OrderService(new OrderRepository());
            var orderResult = await orderService.QueryAsync(it => it.OrderType == 0);
            
            orderResult.ForEach(patiOutVisit => Orders.Add(patiOutVisit));
        }
        public async void ClearInfo()
        {
            OrderService orderService = new OrderService(new OrderRepository());
            var orderResult = await orderService.QueryAsync(it => it.OrderType == 0);
            
            orderResult.ForEach(patiOutVisit => Orders.Add(patiOutVisit));
        }
        public async void MedCardNumQuery()
        {
            if (MedCardNum != null)
            {
                PatiUserService patiUserService = new PatiUserService(new PatiUserRepository());
                var patiResult =
                    await patiUserService.QueryAsync(it => it.MedCardNum == _orderChargePageModel.MedCardNum);

                if (patiResult != null && patiResult.Count > 0)
                {
                    Orders.Clear();
                    OrderService orderService = new OrderService(new OrderRepository());
                    var orderResult =
                        await orderService.QueryAsync(it => it.PatiID == patiResult[0].PatiID && it.OrderType == 0);

                    orderResult.ForEach(patiOutVisit => Orders.Add(patiOutVisit));
                }
                else
                    MessageBox.Show("查询结果为空，请确认医疗卡号。");

            }
            else
                MessageBox.Show("请填写医疗卡号");
        }
        public async void PatiNameQuery()
        {
            if (!string.IsNullOrEmpty(PatiName))
            {
                PatiUserService patiUserService = new PatiUserService(new PatiUserRepository());
                var patiResult =
                    await patiUserService.QueryAsync(it => it.UserAuthName == _orderChargePageModel.PatiName);
                if (patiResult != null && patiResult.Count > 0)
                {
                    Orders.Clear();
                    foreach (var patiUser in patiResult)
                    {
                        OrderService orderService = new OrderService(new OrderRepository());
                        var orderResult =
                            await orderService.QueryAsync(it => it.PatiID == patiUser.PatiID && it.OrderType == 0);

                        orderResult.ForEach(patiOutVisit => Orders.Add(patiOutVisit));
                    }
                }
                else
                    MessageBox.Show("查询结果为空，请确认患者姓名。");
            }
            else
                MessageBox.Show("请填写患者姓名");
        }
        public async void DoctDeptQuery()
        {
            if (!string.IsNullOrEmpty(DoctDept))
            {
                DoctUserService doctUserService = new DoctUserService(new DoctUserRepository());
                var doctResult = await doctUserService.QueryAsync(it => it.DoctDept == _orderChargePageModel.DoctDept);

                if (doctResult != null && doctResult.Count > 0)
                {
                    Orders.Clear();

                    foreach (var doctUser in doctResult)
                    {
                        OrderService orderService = new OrderService(new OrderRepository());
                        var orderResult =
                            await orderService.QueryAsync(it => it.DoctID == doctUser.DoctID && it.OrderType == 0);

                        orderResult.ForEach(patiOutVisit => Orders.Add(patiOutVisit));
                    }
                    
                }
                else
                    MessageBox.Show("查询结果为空，请确认医生科室。");
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
                    Orders.Clear();

                    OrderService orderService = new OrderService(new OrderRepository());
                    var orderResult =
                        await orderService.QueryAsync(it => it.DoctID == doctResult[0].DoctID && it.OrderType == 0);

                    orderResult.ForEach(patiOutVisit => Orders.Add(patiOutVisit));
                }
                else
                    MessageBox.Show("查询结果为空，请确认医生姓名。");
            }
            else
                MessageBox.Show("请填写医生姓名");
        }
        public void LeftClick()
        {
            if(SelectedOrder.TotalPay != null)
                PayAmount = (decimal)SelectedOrder.TotalPay;
        }

        public void CalChangeAmount()
        {
            if (_orderChargePageModel.PaidAmount > _orderChargePageModel.PayAmount)
                ChangeAmount = _orderChargePageModel.PaidAmount - _orderChargePageModel.PayAmount;
        }
        public async void ConfirmPayment()
        {
            if (SelectedOrder == null)
                MessageBox.Show("请选择待缴费的医嘱");
            else if (PayType == null)
                MessageBox.Show("缴费错误，请选择缴费方式");
            else if (_orderChargePageModel.PaidAmount < _orderChargePageModel.PayAmount)
                MessageBox.Show("缴费错误，请确认实付金额不小于应付金额");
            else
            {
                StaffUserService staffUserService = new StaffUserService(new StaffUserRepository());
                var staffResult = await staffUserService.QueryAsync(it => it.UserName == _userName);

                OrderService orderService = new OrderService(new OrderRepository());
                var order = await orderService.FindAsync(SelectedOrder.OrderID);
                order.OrderType = 1;
                
                bool isEdit = await orderService.EditAsync(order);

                OrderSettleService orderSettleService = new OrderSettleService(new OrderSettleRepository());
                order_settle orderSettle = new order_settle
                {
                    SettleDate = DateTime.Now,
                    PayType = PayType,
                    PayAmount = _orderChargePageModel.PayAmount,
                    PaidAmount = _orderChargePageModel.PaidAmount,
                    ChangeAmount = _orderChargePageModel.ChangeAmount,
                    StaffID = staffResult[0].StaffID,
                    OrderID = SelectedOrder.OrderID
                };
                bool isCreate = await orderSettleService.CreateAsync(orderSettle);

                MessageBox.Show(isEdit && isCreate ? "付费成功" : "付费失败");

            }
        }
        
        #endregion
    }
}