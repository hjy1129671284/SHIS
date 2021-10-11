using MyApp.SHIS.ViewModel.Common;

namespace MyApp.SHIS.ViewModel.PagesViewModels.OrderWritePage
{
    public class OrderWritePageViewModel : NotificationObject
    {
        private readonly OrderWritePageModel _orderWritePageModel = new OrderWritePageModel();

        public OrderWritePageViewModel(string userName, int? serialNumber)
        {
            
        }

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

        public string MedicineName
        {
            get => _orderWritePageModel.MedicineName;
            set
            {
                _orderWritePageModel.MedicineName = value;
                OnPropertyChanged(nameof(MedicineName));
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

        public string MedicinePrice
        {
            get => _orderWritePageModel.MedicinePrice;
            set
            {
                _orderWritePageModel.MedicinePrice = value;
                OnPropertyChanged(nameof(MedicinePrice));
            }
        }

        public string MedicineAmount
        {
            get => _orderWritePageModel.MedicineAmount;
            set
            {
                _orderWritePageModel.MedicineAmount = value;
                OnPropertyChanged(nameof(MedicineAmount));
            }
        }

        public string TotalPay
        {
            get => _orderWritePageModel.TotalPay;
            set
            {
                _orderWritePageModel.TotalPay = value;
                OnPropertyChanged(nameof(TotalPay));
            }
        }

        #endregion
        
        
    }
}