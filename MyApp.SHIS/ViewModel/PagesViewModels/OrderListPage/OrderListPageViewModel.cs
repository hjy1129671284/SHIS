using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MyApp.SHIS.Models;
using MyApp.SHIS.Repository.Repository;
using MyApp.SHIS.Services.Services;
using MyApp.SHIS.ViewModel.Common;

namespace MyApp.SHIS.ViewModel.PagesViewModels.OrderListPage
{
    public class OrderListPageViewModel : NotificationObject
    {
        private readonly OrderListPageModel _orderListPageModel = new OrderListPageModel();

        public OrderListPageViewModel()
        {
            ClearInfo();
        }

        private ICommand _patiInfoCommand;
        private ICommand _clearPatiCommand;
        private ICommand _doubleClick;
        private ICommand _medCardNumCommand;
        private ICommand _doctDeptCommand;
        private ICommand _doctNameCommand;


        #region 属性

        public int? MedCardNum
        {
            get => _orderListPageModel.MedCardNum;
            set
            {
                _orderListPageModel.MedCardNum = value;
                OnPropertyChanged(nameof(MedCardNum));
            }
        }

        public string DoctDept
        {
            get => _orderListPageModel.DoctDept;
            set
            {
                _orderListPageModel.DoctDept = value;
                OnPropertyChanged(nameof(DoctDept));
            }
        }

        public string DoctName
        {
            get => _orderListPageModel.DoctName;
            set
            {
                _orderListPageModel.DoctName = value;
                OnPropertyChanged(nameof(DoctName));
            }
        }
        public order SelectedOrder
        {
            get => _orderListPageModel.SelectedOrder;
            set
            {
                _orderListPageModel.SelectedOrder = value;
                OnPropertyChanged(nameof(SelectedOrder));
            }
        }
        public ObservableCollection<order> Orders
        {
            get => _orderListPageModel.Orders;
            set
            {
                _orderListPageModel.Orders = value;
                OnPropertyChanged(nameof(Orders));
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

        public ICommand DoubleClick
        {
            get => _doubleClick ?? (_doubleClick = new RelayCommand(Switch2Diag));
            set => _doubleClick = value;
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
        
        #endregion

        #region 命令方法

        public async void PatiInfo()
        {
            Orders.Clear();
            
            OrderService orderService = new OrderService(new OrderRepository());
            var orderResult = await orderService.QueryAsync(it => it.OrderType == 1);
            
            orderResult.ForEach(order => Orders.Add(order));
        }

        public async void ClearInfo()
        {
            Orders.Clear();
            
            OrderService orderService = new OrderService(new OrderRepository());
            var orderResult = await orderService.QueryAsync(it => it.OrderType == 1);
            
            orderResult.ForEach(order => Orders.Add(order));
        }
        
        public void Switch2Diag()
        {
            Messenger.Default.Send(_orderListPageModel.SelectedOrder.OrderID, "switch2OrderExec");
        }

        public async void MedCardNumQuery()
        {
            if (_orderListPageModel.MedCardNum == null)
                MessageBox.Show("请输入医疗卡号");
            else
            {
                PatiOutVisitService patiOutVisitService = new PatiOutVisitService(new PatiOutVisitRepository());
                var patiOutVisitResult =
                    await patiOutVisitService.QueryAsync(it => it.MedCardNum == _orderListPageModel.MedCardNum);

                if (patiOutVisitResult != null && patiOutVisitResult.Count > 0)
                {
                    Orders.Clear();
                    OrderService orderService = new OrderService(new OrderRepository());
                    var orderResult = await orderService.QueryAsync(it => it.PatiID == patiOutVisitResult[0].PatiID && it.OrderType == 1);
                    
                    orderResult.ForEach(order => Orders.Add(order));
                }
                else
                    MessageBox.Show("没能查询到结果，请确认医疗卡号是否输入正确");

            }
        }
        
        public async void DoctDeptQuery()
        {
            if (string.IsNullOrEmpty(_orderListPageModel.DoctDept))
                MessageBox.Show("请输入科室");
            else
            {
                DoctUserService doctUserService = new DoctUserService(new DoctUserRepository());
                var doctResult = await doctUserService.QueryAsync(it => it.DoctDept == DoctDept);

                if (doctResult != null && doctResult.Count > 0)
                {
                    Orders.Clear();
                    
                    HashSet<int> doctIDs = new HashSet<int>();
                    doctResult.ForEach(doct => doctIDs.Add(doct.DoctID));
                    
                    OrderService orderService = new OrderService(new OrderRepository());
                    foreach (var doctID in doctIDs)
                    {
                        var orderResult = await orderService.QueryAsync(it => it.DoctID == doctID && it.OrderType == 1);
                        orderResult.ForEach(order => Orders.Add(order));
                    }
                }
                else
                    MessageBox.Show("没能查询到结果，请确认科室是否输入正确");
                
            }
        }
        
        public async void DoctNameQuery()
        {
            if (string.IsNullOrEmpty(_orderListPageModel.DoctName))
                MessageBox.Show("请输入医生姓名");
            else
            {
                DoctUserService doctUserService = new DoctUserService(new DoctUserRepository());
                var doctResult = await doctUserService.QueryAsync(it => it.DoctName == DoctName);

                if (doctResult != null && doctResult.Count > 0)
                {
                    Orders.Clear();
                    
                    OrderService orderService = new OrderService(new OrderRepository());
                    var orderResult = await orderService.QueryAsync(it => it.DoctID == doctResult[0].DoctID && it.OrderType == 1);
                    
                    orderResult.ForEach(order => Orders.Add(order));
                }
                else
                    MessageBox.Show("没能查询到结果，请确认医生姓名是否输入正确");
                
            }
        }

        #endregion
    }
}