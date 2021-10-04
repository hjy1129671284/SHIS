using System;
using System.Collections.Generic;
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

        public RegisterPageViewModel(int? patiMedCardNum = null)
        {
            DoctDepts = new List<string>
            {
                "牙科"
            };

            if (patiMedCardNum != null)
            {
                InitionalizeMessage((int)patiMedCardNum);
            }
        }
        
        private ICommand _register;

        #region 属性

         public int PatiMedCardNum
        { 
            get => _registerPageModel.PatiMedCardNum;
            set
            {
                _registerPageModel.PatiMedCardNum = value;
                OnPropertyChanged(nameof(PatiMedCardNum));
            }
        }
         public int SerialNumber
        { 
            get => _registerPageModel.SerialNumber;
            set
            {
                _registerPageModel.SerialNumber = value;
                OnPropertyChanged(nameof(SerialNumber));
            }
        }
         public int QueueNo
         {
             get => _registerPageModel.QueueNo;
             set
             {
                 _registerPageModel.QueueNo = value;
                 OnPropertyChanged(nameof(QueueNo));
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
         public int PatiAge
        { 
            get => _registerPageModel.PatiAge;
            set
            {
                _registerPageModel.PatiAge = value;
                OnPropertyChanged(nameof(PatiAge));
            }
        }
         public List<string> DoctDepts
         {
             get => _registerPageModel.DoctDepts;
             set
             {
                 _registerPageModel.DoctDepts = value;
                 OnPropertyChanged(nameof(DoctDepts));
             }
         }
         public List<string> DoctNames
         {
             get => _registerPageModel.DoctNames;
             set
             {
                 _registerPageModel.DoctNames = value;
                 OnPropertyChanged(nameof(DoctNames));
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
        public decimal Totalpay
        { 
            get => _registerPageModel.Totalpay;
            set
            {
                _registerPageModel.Totalpay = value;
                OnPropertyChanged(nameof(Totalpay));
            }
        }
        
        // Hint
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
        public string TotalpayHint
        { 
            get => _registerPageModel.TotalpayHint;
            set
            {
                _registerPageModel.TotalpayHint = value;
                OnPropertyChanged(nameof(TotalpayHint));
            }
        }


        #endregion

        public ICommand Register
        {
            get => _register ?? (_register = new RelayCommand(
                () => { MessageBox.Show(DoctDept); }
            ));
            set => _register = value;
        }




        public async void InitionalizeMessage(int patiMedCardNum)
        {
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = await normUserService.QueryAsync(it => it.MedCardNum == patiMedCardNum);
            var user = result[0];
            
            
            
            _registerPageModel.PatiMedCardNum = patiMedCardNum;
        }
    }
}