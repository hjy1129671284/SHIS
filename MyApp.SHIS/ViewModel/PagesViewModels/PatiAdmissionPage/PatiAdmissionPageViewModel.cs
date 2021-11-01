using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MyApp.SHIS.Models;
using MyApp.SHIS.Repository.Repository;
using MyApp.SHIS.Services.Services;
using MyApp.SHIS.ViewModel.Common;

namespace MyApp.SHIS.ViewModel.PagesViewModels.PatiAdmissionPage
{
    public class PatiAdmissionPageViewModel : NotificationObject
    {
        private readonly PatiAdmissionPageModel _patiAdmissionPageModel = new PatiAdmissionPageModel();
        private readonly string _userName;

        public PatiAdmissionPageViewModel(string userName)
        {
            _userName = userName;
            
        }

        private ICommand _deptPai;
        private ICommand _personalPati;
        private ICommand _clean;
        private ICommand _doubleClick;

        #region 属性

        public ObservableCollection<pati_out_visit> PatiOutVisits
        {
            get => _patiAdmissionPageModel.PatiOutVisits;
            set
            {
                _patiAdmissionPageModel.PatiOutVisits = value;
                OnPropertyChanged(nameof(PatiOutVisits));
            }
        }

        public pati_out_visit PatiOutVisit
        {
            get => _patiAdmissionPageModel.PatiOutVisit;
            set
            {
                _patiAdmissionPageModel.PatiOutVisit = value;
                OnPropertyChanged(nameof(PatiOutVisit));
            }
        }

        #endregion

        #region 命令

        public ICommand DeptPati
        {
            get => _deptPai ?? (_deptPai = new RelayCommand(UpdateDeptPati));
            set => _deptPai = value;
        }

        public ICommand PersonalPati
        {
            get => _personalPati ?? (_personalPati = new RelayCommand(UpdatePersonalPati));
            set => _personalPati = value;
        }
        
        public ICommand Clean
        {
            get => _clean ?? (_clean = new RelayCommand(CleanDataGrid));
            set => _clean = value;
        }

        public ICommand DoubleClick
        {
            get => _doubleClick ?? (_doubleClick = new RelayCommand(Switch2Diag));
            set => _doubleClick = value;
        }

        #endregion

        #region 命令方法
        
        // 查看科室病人
        public async void UpdateDeptPati()
        {
            PatiOutVisits.Clear();
            DoctUserService doctUserService = new DoctUserService(new DoctUserRepository());
            var doctResult = await doctUserService.QueryAsync(it => it.UserName == _userName);
            string doctDept = doctResult[0].DoctDept;
            PatiOutVisitService patiOutVisitService = new PatiOutVisitService(new PatiOutVisitRepository());
            var patiOutVisitResult = await patiOutVisitService.QueryAsync(it => it.DoctDept == doctDept && it.OutStatus == 1);
            foreach (var visit in patiOutVisitResult)
                PatiOutVisits.Add(visit);
        }
        // 查看医生个人病人
        public async void UpdatePersonalPati()
        {
            PatiOutVisits.Clear();
            DoctUserService doctUserService = new DoctUserService(new DoctUserRepository());
            var doctResult = await doctUserService.QueryAsync(it => it.UserName == _userName);
            int dcotID = doctResult[0].DoctID;
            PatiOutVisitService patiOutVisitService = new PatiOutVisitService(new PatiOutVisitRepository());
            var patiOutVisitResult = await patiOutVisitService.QueryAsync(it => it.DoctID == dcotID && it.OutStatus == 1);
            foreach (var visit in patiOutVisitResult)
                PatiOutVisits.Add(visit);
        }
        // 清空数据框
        public void CleanDataGrid()
        {
            PatiOutVisits.Clear();
        }
        // 切换到诊断页面
        public void Switch2Diag()
        {
            Messenger.Default.Send(PatiOutVisit.SerialNumber, "patiAdmission2Diagnosis");
        }

        #endregion
        
    }
}