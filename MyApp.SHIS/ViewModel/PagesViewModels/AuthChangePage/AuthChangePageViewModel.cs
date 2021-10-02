using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using MyApp.SHIS.Models;
using MyApp.SHIS.Repository.Repository;
using MyApp.SHIS.Services.Services;
using MyApp.SHIS.ViewModel.Common;

namespace MyApp.SHIS.ViewModel.PagesViewModels.AuthChangePage
{
    public class AuthChangePageViewModel : NotificationObject
    {
        private readonly AuthChangePageModel _authChangePageModel = new AuthChangePageModel();

        private ICommand _findUser;
        private ICommand _changAuth;
        private ICommand _selectUserType;


        #region 属性

        public string UserName
        {
            get => _authChangePageModel.UserName;
            set
            {
                _authChangePageModel.UserName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        public int NewUserType
        {
            get => _authChangePageModel.NewUserType;
            set
            {
                _authChangePageModel.NewUserType = value;
                OnPropertyChanged(nameof(NewUserType));
            }
        }

        public ComboBoxItem UserType
        {
            get => _authChangePageModel.UserType;
            set
            {
                _authChangePageModel.UserType = value;
                OnPropertyChanged(nameof(UserType));
            }
        }

        public ObservableCollection<user> UserList
        {
            get => _authChangePageModel.UserList;
            set
            {
                _authChangePageModel.UserList = value;
                OnPropertyChanged(nameof(UserList));
            }
        }

        public Visibility PatiVisibility
        {
            get => _authChangePageModel.PatiVisibility;
            set
            {
                _authChangePageModel.PatiVisibility = value;
                OnPropertyChanged(nameof(PatiVisibility));
            }
        }

        public int? MedCardNum
        {
            get => _authChangePageModel.MedCardNum;
            set
            {
                _authChangePageModel.MedCardNum = value;
                OnPropertyChanged(nameof(MedCardNum));
            }
        }

        public int? MedCardNumHint
        {
            get => _authChangePageModel.MedCardNumHint;
            set
            {
                _authChangePageModel.MedCardNumHint = value;
                OnPropertyChanged(nameof(MedCardNumHint));
            }
        }

        public ComboBoxItem SecretGradeID
        {
            get => _authChangePageModel.SecretGradeID;
            set
            {
                _authChangePageModel.SecretGradeID = value;
                OnPropertyChanged(nameof(SecretGradeID));
            }
        }

        public string SecretGradeIDHint
        {
            get => _authChangePageModel.SecretGradeIDHint;
            set
            {
                _authChangePageModel.SecretGradeIDHint = value;
                OnPropertyChanged(nameof(SecretGradeIDHint));
            }
        }

        public bool PatiIsExist
        {
            get => _authChangePageModel.PatiIsExist;
            set
            {
                _authChangePageModel.PatiIsExist = value;
                OnPropertyChanged(nameof(PatiIsExist));
            }
        }


        public Visibility StaffVisibility
        {
            get => _authChangePageModel.StaffVisibility;
            set
            {
                _authChangePageModel.StaffVisibility = value;
                OnPropertyChanged(nameof(StaffVisibility));
            }
        }
        
        public int? StaffUserID
        {
            get => _authChangePageModel.StaffUserID;
            set
            {
                _authChangePageModel.StaffUserID = value;
                OnPropertyChanged(nameof(StaffUserID));
            }
        }

        public string StaffUserIDHint
        {
            get => _authChangePageModel.StaffUserIDHint;
            set
            {
                _authChangePageModel.StaffUserIDHint = value;
                OnPropertyChanged(nameof(StaffUserIDHint));
            }
        }


        public string StaffAuthName
        {
            get => _authChangePageModel.StaffAuthName;
            set
            {
                _authChangePageModel.StaffAuthName = value;
                OnPropertyChanged(nameof(StaffAuthName));
            }
        }

        public string StaffAuthNameHint
        {
            get => _authChangePageModel.StaffAuthNameHint;
            set
            {
                _authChangePageModel.StaffAuthNameHint = value;
                OnPropertyChanged(nameof(StaffAuthNameHint));
            }
        }
        
        public ComboBoxItem StaffType
        {
            get => _authChangePageModel.StaffType;
            set
            {
                _authChangePageModel.StaffType = value;
                OnPropertyChanged(nameof(StaffType));
            }
        }

        public string StaffTypeHint
        {
            get => _authChangePageModel.StaffTypeHint;
            set
            {
                _authChangePageModel.StaffTypeHint = value;
                OnPropertyChanged(nameof(StaffTypeHint));
            }
        }

        public bool StaffIsExist
        {
            get => _authChangePageModel.StaffIsExist;
            set
            {
                _authChangePageModel.StaffIsExist = value;
                OnPropertyChanged(nameof(StaffIsExist));
            }
        }


        public Visibility DoctVisibility
        {
            get => _authChangePageModel.DoctVisibility;
            set
            {
                _authChangePageModel.DoctVisibility = value;
                OnPropertyChanged(nameof(DoctVisibility));
            }
        }

        public string DoctDept
        {
            get => _authChangePageModel.DoctDept;
            set
            {
                _authChangePageModel.DoctDept = value;
                OnPropertyChanged(nameof(DoctDept));
            }
        }

        public string DoctDeptHint
        {
            get => _authChangePageModel.DoctDeptHint;
            set
            {
                _authChangePageModel.DoctDeptHint = value;
                OnPropertyChanged(nameof(DoctDeptHint));
            }
        }
        
        public string DoctPosn
        {
            get => _authChangePageModel.DoctPosn;
            set
            {
                _authChangePageModel.DoctPosn = value;
                OnPropertyChanged(nameof(DoctPosn));
            }
        }

        public string DoctPosnHint
        {
            get => _authChangePageModel.DoctPosnHint;
            set
            {
                _authChangePageModel.DoctPosnHint = value;
                OnPropertyChanged(nameof(DoctPosnHint));
            }
        }

        public bool DoctIsExist
        {
            get => _authChangePageModel.DoctIsExist;
            set
            {
                _authChangePageModel.DoctIsExist = value;
                OnPropertyChanged(nameof(DoctIsExist));
            }
        }


        #endregion
        

        #region 命令

        public ICommand FindUser
        {
            get => _findUser ?? (_findUser = new RelayCommand(Find));
            set => _findUser = value;
        }
        
        public ICommand SelectUserType
        {
            get => _selectUserType ?? (_selectUserType = new RelayCommand(UserTypeSelectedChanged));
            set => _selectUserType = value;
        }
        
        public ICommand ChangeAuth
        {
            get => _changAuth ?? (_changAuth = new RelayCommand(ChangUserAuth));
            set => _changAuth = value;
        }

        #endregion


        #region 命令方法

        public async void Find()
        {
            _authChangePageModel.UserList.Clear();
            UserService userService = new UserService(new UserRepository());
            var result = await userService.QueryAsync(it => it.UserName == _authChangePageModel.UserName);
            if (result != null && result.Count > 0)
            {
                _authChangePageModel.UserList.Add(result[0]);
            }
            else
            {
                MessageBox.Show($"没找到{_authChangePageModel.UserName}");
            }
        }
        
        public async void UserTypeSelectedChanged()
        {
            MedCardNum = null;
            SecretGradeID = null;
            StaffUserID = null;
            StaffAuthName = null;
            StaffType = null;
            DoctDept = null;
            DoctPosn = null;
            
            if (_authChangePageModel.UserName == null)
                MessageBox.Show("请输入用户名");
            else
            {
                if (_authChangePageModel.UserType.Content.ToString() == "病人")
                {
                    PatiVisibility = Visibility.Visible;
                    StaffVisibility = Visibility.Collapsed;
                    DoctVisibility = Visibility.Collapsed;

                    PatiUserService patiUserService = new PatiUserService(new PatiUserRepository());

                    var result = await patiUserService.QueryAsync(it => it.UserName == _authChangePageModel.UserName);
                    if (result != null && result.Count > 0)
                    {
                        MedCardNum = result[0].MedCardNum;
                        _authChangePageModel.PatiIsExist = true;
                        switch (result[0].SecretGradeID)
                        {
                            case 0: SecretGradeIDHint = "无"; break;
                            case 1: SecretGradeIDHint = "机密"; break;
                            case 2: SecretGradeIDHint = "秘密"; break;
                            case 3: SecretGradeIDHint = "绝密"; break;
                        }
                    }
                    else
                    {
                        _authChangePageModel.PatiIsExist = false;
                    }
                }
                else if (_authChangePageModel.UserType.Content.ToString() == "其他职工")
                {
                    PatiVisibility = Visibility.Collapsed;
                    StaffVisibility = Visibility.Visible;
                    DoctVisibility = Visibility.Collapsed;
                
                    StaffUserService staffUserService = new StaffUserService(new StaffUserRepository());

                    var result = await staffUserService.QueryAsync(it => it.UserName == _authChangePageModel.UserName);
                    if (result != null && result.Count > 0)
                    {
                        StaffUserIDHint = result[0].StaffID.ToString();
                        StaffAuthNameHint = result[0].StafName;
                        _authChangePageModel.StaffIsExist = true;
                        switch (result[0].StafType)
                        {
                            case 3: StaffTypeHint = "医生"; break;
                            case 4: StaffTypeHint = "药师"; break;
                            case 5: StaffTypeHint = "挂号员"; break;
                            case 6: StaffTypeHint = "收费员"; break;
                            case 7: StaffTypeHint = "护士"; break;
                        }
                    }
                    else
                    {
                        StaffUserIDHint = "请填写职工编码";
                        _authChangePageModel.StaffIsExist = false;
                    }
                }
                else if (_authChangePageModel.UserType.Content.ToString() == "医生")
                {
                    PatiVisibility = Visibility.Collapsed;
                    StaffVisibility = Visibility.Collapsed;
                    DoctVisibility = Visibility.Visible;

                    DoctUserService doctUserService = new DoctUserService(new DoctUserRepository());
                    var doctResult = await doctUserService.QueryAsync(it => it.UserName == _authChangePageModel.UserName);

                    if (doctResult != null && doctResult.Count > 0)
                    {
                        _authChangePageModel.DoctIsExist = true;
                        StaffUserIDHint = doctResult[0].DoctID.ToString();
                        StaffAuthNameHint = doctResult[0].DoctName;
                        DoctDeptHint = doctResult[0].DoctDept;
                        DoctPosnHint = doctResult[0].DoctPosn;
                    }
                    else
                    {
                        StaffUserIDHint = "新医生自动生成编码";
                        _authChangePageModel.DoctIsExist = false;
                    }
                }
                else
                {
                    PatiVisibility = Visibility.Collapsed;
                    StaffVisibility = Visibility.Collapsed;
                    DoctVisibility = Visibility.Collapsed;
                }
            }
        }
        
        public async void ChangUserAuth()
        {
            bool doctIsDelete = true;  // 标志医生表数据是否删除成功
            bool staffIsDelete = true;  // 标志原表数据是否删除成功
            bool userIsEdit = false;  // 标志用户表是否修改成功
            bool normIsEdit = true;  // 标志用户表是否修改成功
            bool patiIsEdit = true;  // 标志病人表是否修改成功
            bool staffIsEdit = true;  // 标志职工表是否修改成功
            bool doctIsEdit = true;  // 标志医生表是否修改成功
            
            // 修改后的用户权限名称
            string newUserType = null;

            // 在表中更新的用户权限字段
            switch (_authChangePageModel.UserType.Content.ToString())
            {
                case "管理员": _authChangePageModel.NewUserType = 0; newUserType= "管理员"; break;
                case "普通用户":   _authChangePageModel.NewUserType = 1; newUserType= "普通用户"; break;
                case "病人":   _authChangePageModel.NewUserType = 2; newUserType= "病人"; break;
                case "医生":   _authChangePageModel.NewUserType = 3; newUserType= "医生"; break;
                case "其他职工":
                    string staffType = _authChangePageModel.StaffType == null
                        ? _authChangePageModel.StaffTypeHint
                        : _authChangePageModel.StaffType.Content.ToString();
                    switch (staffType) 
                    {
                                case "药师": _authChangePageModel.NewUserType = 4; newUserType= "药师"; break;
                                case "挂号员":  _authChangePageModel.NewUserType = 5; newUserType= "挂号员"; break;
                                case "收费员":  _authChangePageModel.NewUserType = 6; newUserType= "收费员"; break;
                                case "护士": _authChangePageModel.NewUserType = 7; newUserType= "护士"; break;
                    }
                    break;
            }
            
            // 得到该用户的原来的信息
            UserService userService = new UserService(new UserRepository());
            var user = await userService.QueryAsync(it => it.UserName == _authChangePageModel.UserName);

            // 修改用户权限之前、需要删除用户原来的记录
            #region 删除记录
            
            // 若用户原来是医生，改变后不是医生，则应删除 doct表 中对应的信息
            if (user[0].UserType == 3 && _authChangePageModel.NewUserType != 3)
            {
                DoctUserService doctUserService = new DoctUserService(new DoctUserRepository());
                doctIsDelete = await doctUserService.DeleteAsync(it => it.UserName == UserName);
                
            }
            // 若用户原来是 (医生、药师、挂号员、收费员、护士)，改变后不是，则应删除 staff表 中对应的信息
            bool userIsStaff = user[0].UserType == 3 || user[0].UserType == 4 || user[0].UserType == 5 ||
                               user[0].UserType == 6 || user[0].UserType == 7;
            bool changeIsStaff = _authChangePageModel.NewUserType == 3 || _authChangePageModel.NewUserType == 4 || 
                                 _authChangePageModel.NewUserType == 5 || _authChangePageModel.NewUserType == 6 || 
                                 _authChangePageModel.NewUserType == 7;
            
            if (userIsStaff && !changeIsStaff)
            {
                StaffUserService staffUserService = new StaffUserService(new StaffUserRepository());
                staffIsDelete = await staffUserService.DeleteAsync(it => it.UserName == UserName);
            }
            
            #endregion
            
            # region 修改user表
            
            user[0].UserType = _authChangePageModel.NewUserType;
            userIsEdit = await userService.EditAsync(user[0]);
            # endregion

            #region 修改pati表
            
            if (_authChangePageModel.UserType.Content.ToString() == "病人")
            {
                // 置修改标记为 false
                normIsEdit = false;
                patiIsEdit = false;
                // 根据选择的病历保密级别转换为级别ID
                int grade = 0;
                switch (SecretGradeID.Content.ToString())
                {
                    case "无": grade = 0; break;
                    case "保密": grade = 1; break;
                    case "机密": grade = 2; break;
                    case "绝密": grade = 3; break;
                }
                
                // 检测医疗卡号是否填写
                if (_authChangePageModel.MedCardNum != null)
                {
                    // 检测医疗卡号是否存在重复记录
                    NormUserService normUserService = new NormUserService(new NormUserRepository());
                    var existResult =
                        await normUserService.QueryAsync(it => it.MedCardNum == _authChangePageModel.MedCardNum);
                    if (existResult != null && existResult.Count > 0)
                        MessageBox.Show("医疗卡号已存在，请确认后重新输入");
                    else 
                    {
                        // 判断病人是否存在在 norm_user 表中
                        if (_authChangePageModel.PatiIsExist) 
                        {
                            // 若 norm表 中有记录，则先修改 norm表 记录中的 医疗卡号字段
                            var normResult = await normUserService.QueryAsync(it => it.UserName == _authChangePageModel.UserName);

                            // 修改 norm表
                            var normUser = normResult[0];
                            normUser.MedCardNum = _authChangePageModel.MedCardNum;
                            normIsEdit = await normUserService.EditAsync(normUser);

                            // pati表 添加数据
                            pati_user patiUser = new pati_user
                                {
                                    NormID = normUser.NormID,
                                    UserName = normUser.UserName,
                                    MedCardNum = (int) _authChangePageModel.MedCardNum,
                                    SecretGradeID = grade
                                };
                            
                            PatiUserService patiUserService = new PatiUserService(new PatiUserRepository());
                            patiIsEdit = await patiUserService.EditAsync(patiUser);
                        }
                        else
                        {
                            // 若 norm表中 不存在记录，则向 norm表 和 pati表 添加数据
                            norm_user normUser = new norm_user
                            {
                                UserName = _authChangePageModel.UserName,
                                MedCardNum = _authChangePageModel.MedCardNum
                            };
                            // norm表 添加数据
                            normIsEdit = await normUserService.CreateAsync(normUser);
                            
                            // pati表 的 normID 和 UserName 从 norm表 获取
                            var normResult = await normUserService.QueryAsync(it => it.UserName == _authChangePageModel.UserName);
                            pati_user patiUser = new pati_user
                            {
                                NormID = normResult[0].NormID,
                                UserName = normResult[0].UserName,
                                MedCardNum = (int) _authChangePageModel.MedCardNum,
                                SecretGradeID = grade
                            };

                            // pati表 添加数据
                            PatiUserService patiUserService = new PatiUserService(new PatiUserRepository());
                            patiIsEdit = await patiUserService.CreateAsync(patiUser);
                        }
                    }
                }
                else
                    MessageBox.Show("请输入医疗卡号");
            }

            #endregion
            
            # region 修改staff表
            if (_authChangePageModel.UserType.Content.ToString() == "其他职工")
            {
                // 置修改标记为 false
                staffIsEdit = false;
                
                StaffUserService staffUserService = new StaffUserService(new StaffUserRepository());
                
                //判断管理员填写的职工编码是否与 staff表 中的记录重复
                int staffID;
                if (_authChangePageModel.StaffUserID == null)
                {
                    int.TryParse(_authChangePageModel.StaffUserIDHint, out staffID) ;
                }
                else
                {
                    staffID = (int) _authChangePageModel.StaffUserID;
                }
                var existResult =
                await staffUserService.QueryAsync(it => it.StaffID == staffID);
                if(existResult != null && existResult.Count > 0)
                    MessageBox.Show("职工编码已存在，请确认并重写填写");
                else
                {
                    // 判断职工是否已有记录
                    if (_authChangePageModel.StaffIsExist)
                    {
                        //如果用户在staff表中有记录，则查询出原有的信息，比较原有信息和管理员填写信息，更新表
                        var result =
                            await staffUserService.QueryAsync(it => it.UserName == _authChangePageModel.UserName);
                        staff_user staffUser = result[0];

                        if (_authChangePageModel.StaffUserID != null)
                            staffUser.StaffID = (int) _authChangePageModel.StaffUserID;
                        if (_authChangePageModel.StaffAuthName != null)
                            staffUser.StafName = _authChangePageModel.StaffAuthName;
                        staffUser.StafType = _authChangePageModel.NewUserType;

                        staffIsEdit = await staffUserService.EditAsync(staffUser);
                    
                    }
                    else
                    {
                        // 如果用户在staff表中没有记录，则根据管理员填写的信息，创建一条新的记录
                        if (_authChangePageModel.StaffUserID != null)
                        {
                            staff_user staffUser = new staff_user
                            {
                                UserID = user[0].UserID,
                                StaffID = (int)_authChangePageModel.StaffUserID,
                                UserName = _authChangePageModel.UserName,
                                StafName = _authChangePageModel.StaffAuthName,
                                StafType = _authChangePageModel.NewUserType,
                                StafWork = 1
                            };

                            staffIsEdit = await staffUserService.CreateAsync(staffUser);
                        }
                        else
                        {
                            MessageBox.Show("请输入职工编码");
                        }
                    }
                }
                
            }
            # endregion

            #region 修改doct表

            if (_authChangePageModel.UserType.Content.ToString() == "医生")
            {
                // 置修改标记为 false
                staffIsEdit = false;
                doctIsEdit = false;

                StaffUserService staffUserService = new StaffUserService(new StaffUserRepository());

                // 判断管理员填写的医生编码是否与 staff表 中的记录重复

                int staffID = _authChangePageModel.StaffUserID ?? -1;

                var existResult = await staffUserService.QueryAsync(it => it.StaffID == staffID);
                if (existResult != null && existResult.Count > 0)
                    MessageBox.Show("医生编码已存在，请确认并重新填写");
                else
                {
                    staff_user staffUser = null;

                    // 判断医生是否在 staff 表中有记录
                    var staffResult =
                        await staffUserService.QueryAsync(it => it.UserName == _authChangePageModel.UserName);
                    
                    if (staffResult != null && staffResult.Count > 0)
                    {
                        // 若医生在 staff表 中有记录，则根据 staff表记录的信息 以及 管理员填写的信息,更新 staff表
                        staffUser = staffResult[0];

                        if (_authChangePageModel.StaffUserID != null)
                            staffUser.StaffID = (int) _authChangePageModel.StaffUserID;
                        if (_authChangePageModel.StaffAuthName != null)
                            staffUser.StafName = _authChangePageModel.StaffAuthName;
                        staffUser.StafType = 3;
                        
                        staffIsEdit = await staffUserService.EditAsync(staffUser);
                    }
                    else
                    {
                        // 若医生在 staff表 中没有记录，则根据管理员填写的信息，创建 staff表记录，其中 staffID, staffName 不能为空
                        if (_authChangePageModel.StaffUserID != null)
                        {
                            if (_authChangePageModel.StaffAuthName != null)
                            {
                                staffUser = new staff_user
                                {
                                    UserID = user[0].UserID,
                                    StaffID = (int) _authChangePageModel.StaffUserID,
                                    UserName = _authChangePageModel.UserName,
                                    StafName = _authChangePageModel.StaffAuthName,
                                    StafType = 3,
                                    StafWork = 1
                                };

                                staffIsEdit = await staffUserService.CreateAsync(staffUser);
                            }
                            else
                                MessageBox.Show("请填写医生姓名");
                        }
                        else
                            MessageBox.Show("请填写医生编码");
                    }
                    

                    DoctUserService doctUserService = new DoctUserService(new DoctUserRepository());
                    // 判断医生是否在 doct表 中有记录
                    if (DoctIsExist)
                    {
                        // 若医生在doct表中存在记录，则根据 doct表 的信息和管理员填写的信息，更新 doct表
                        var doctResult =
                            await doctUserService.QueryAsync(it => it.UserName == _authChangePageModel.UserName);
                        doct_user doctUser = doctResult[0];
                        
                        if (_authChangePageModel.StaffUserID != null)
                            doctUser.DoctID = (int) _authChangePageModel.StaffUserID;
                        if (_authChangePageModel.StaffAuthName != null)
                            doctUser.DoctName = _authChangePageModel.StaffAuthName;
                        if (_authChangePageModel.DoctDept != null)
                            doctUser.DoctDept = _authChangePageModel.DoctDept;
                        if (_authChangePageModel.DoctPosn != null)
                            doctUser.DoctPosn = _authChangePageModel.DoctPosn;
                        
                        doctIsEdit = await doctUserService.EditAsync(doctUser);

                    }
                    else
                    {
                        // 若医生在 doct表 中无记录，则根据 staff表 中记录的信息和管理员填写的信息，创建 doct表 记录
                        var staff =
                            await staffUserService.QueryAsync(it => it.UserName == _authChangePageModel.UserName);

                        if (_authChangePageModel.DoctDept != null)
                        {
                            if (_authChangePageModel.DoctPosn != null)
                            {
                                doct_user doctUser = new doct_user
                                {
                                    UserID = staff[0].UserID,
                                    DoctID = staff[0].StaffID,
                                    UserName = staff[0].UserName,
                                    DoctName = staff[0].StafName,
                                    DoctDept = _authChangePageModel.DoctDept,
                                    DoctPosn = _authChangePageModel.DoctPosn,
                                    DoctWork = 1
                                };

                                doctIsEdit = await doctUserService.CreateAsync(doctUser);
                            }
                            else
                                MessageBox.Show("请填写医生职位");
                        }
                        else
                            MessageBox.Show("请填写医生科室");
                    }
                }
            }

            #endregion
            
            
            // 全部需要修改的表修改成功则输出成功消息 否则输出失败消息
            if (!doctIsDelete)
                MessageBox.Show("doct_user表中的信息删除失败");
            else if(!staffIsDelete)
                MessageBox.Show("staff_user表中的信息删除失败");
            else if (!userIsEdit)
                MessageBox.Show("user表修改失败");
            else if(!normIsEdit)
                MessageBox.Show("norm_user表修改失败");
            else if(!patiIsEdit)
                MessageBox.Show("pati_user表修改失败");
            else if(!staffIsEdit)
                MessageBox.Show("staff_user表修改失败");
            else if(!doctIsEdit)
                MessageBox.Show("doct_user表修改失败");
            else
                MessageBox.Show($"修改成功,目前 {_authChangePageModel.UserName} 用户的权限为 {newUserType}");
        }

        #endregion
        

    }    
    
}