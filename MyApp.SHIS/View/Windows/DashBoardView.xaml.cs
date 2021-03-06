using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using MaterialDesignThemes.Wpf;
using MyApp.SHIS.Commom;
using MyApp.SHIS.Models;
using MyApp.SHIS.Repository.Repository;
using MyApp.SHIS.Services.Services;
using MyApp.SHIS.View.Pages;
using MyApp.SHIS.View.UserControls;
using MyApp.SHIS.ViewModel.UserControlsViewModels.UserControlMenuItem;
using MyApp.SHIS.ViewModel.WindowsViewModels.DashBoard;
using Newtonsoft.Json;
using SqlSugar.IOC;

namespace MyApp.SHIS.View.Windows
{
    public partial class DashBoardView
    {
        private readonly DashBoardViewModel _dashBoardViewModel = new DashBoardViewModel();
        private readonly string _userName;
        
        
        public DashBoardView(string username, int userType)
        {
            // 读取 AppSetting.json 
            StreamReader streamReader = new StreamReader("AppSetting.json");
            string jsonString = streamReader.ReadToEnd();
            AppSetting m = JsonConvert.DeserializeObject<AppSetting>(jsonString);

            #region SqlSugar.IOC 注入

            try
            {
                if (m != null)
                    SugarIocServices.AddSqlSugar(new IocConfig()
                    {
                        ConnectionString = m.ConnectionString, // 格式 server=localhost;Database=SqlSugar4xTest;Uid=root;Pwd=haosql;
                        DbType = IocDbType.MySql,
                        IsAutoCloseConnection = true //自动释放
                    });
                else
                {
                    MessageBox.Show("请在AppSetting.json文件中填写ConnectionString");
                }
            }
            catch
            {
                MessageBox.Show("请在AppSetting.json文件中确认ConnectionString是否正确");
            }

            #endregion
            
            InitializeComponent();
            this.DataContext = _dashBoardViewModel;
            _userName = username;
            
            //注册消息
            Messenger.Default.Register<string>(this,"closeWindow", CloseWindow);
            Messenger.Default.Register<string>(this, "generateMenu", GenerateMenu);
            Messenger.Default.Register<string>(this, "openMenu", OpenMenu);
            Messenger.Default.Register<string>(this, "closeMenu", CloseMenu);
            Messenger.Default.Register<string>(this, "dashBoard2Login", DashBOard2Login);
            Messenger.Default.Register<string>(this, "settingMenu", SettingPage);

            if (string.IsNullOrEmpty(username))
            {
                // 未登录界面
                GenerateNoLoginMenu();
                _dashBoardViewModel.UserLoginButtonContent = "账号登录";
                _dashBoardViewModel.SettingButtonVisibility = Visibility.Collapsed;
                _dashBoardViewModel.ButtonCloseMenuVisibility = Visibility.Collapsed;

            }
            else
            {
                // 登录后窗口
                _dashBoardViewModel.UserLoginButtonContent = "退出登录";
                _dashBoardViewModel.UserName = username;
                _dashBoardViewModel.SettingButtonVisibility = Visibility.Visible;
                _dashBoardViewModel.ButtonCloseMenuVisibility = Visibility.Collapsed;
                _dashBoardViewModel.UserType = userType.ToString();
            }
            //移除消息
            Unloaded += (sender, e) => Messenger.Default.Unregister(this);
            
            // 创建数据库、表、项
            // SqlSugarCreate();

        }
        
        internal void SwitchPages(object sender)
        {
            
            var page = (Page)sender;

            if (page != null)
            {
                ContentControl.Content = new Frame()
                {
                    Content = page
                };
            }

        }

        #region 接受消息执行的方法

        private void CloseWindow(string msg)
        {
            Application.Current.Shutdown();
        }

        private void OpenMenu(string msg)
        {
            _dashBoardViewModel.ButtonOpenMenuVisibility = Visibility.Collapsed;
            _dashBoardViewModel.ButtonCloseMenuVisibility = Visibility.Visible;
        }

        private void CloseMenu(string msg)
        {
            _dashBoardViewModel.ButtonOpenMenuVisibility = Visibility.Visible;
            _dashBoardViewModel.ButtonCloseMenuVisibility = Visibility.Collapsed;
        }
        
        private void DashBOard2Login(string msg)
        {
            ViewManage.ChangeView(this, new LoginView());
        }

        private void SettingPage(string msg)
        {
            SwitchPages(new SettingPage(_dashBoardViewModel.UserName));
        }
        
        

        #endregion
        

        #region 初始化数据库
        // public async void SqlSugarCreate()
        // {
        //     // 创建数据库
        //     DbScoped.Sugar.DbMaintenance.CreateDatabase();
        //     // 创建表
        //     DbScoped.Sugar.CodeFirst.SetStringDefaultLength(200).InitTables
        //     (
        //         typeof(user),
        //         typeof(norm_user),
        //         typeof(pati_user),
        //         typeof(staff_user),
        //         typeof(doct_user)
        //     );
        //     // 生成管理员帐号
        //     UserService userService = new UserService(new UserRepository());
        //     await userService.CreateAsync(new user()
        //     {
        //         UserID = 1,
        //         UserName = "root",
        //         UserPwd = "123456",
        //         UserType = 0
        //     });
        // }

        public void SqlSugarCreate()
        {
            // 生成实体
            DbScoped.Sugar.DbFirst.IsCreateAttribute()
                .CreateClassFile("D:\\C Sharp\\demo\\SHIS\\MyApp.SHIS\\Models", "MyApp.SHIS.Models");
        }

        #endregion
        
        
        /// <summary>
        /// 菜单滚轮滑动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScrollViewer_OnPreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var eventArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
            {
                RoutedEvent = UIElement.MouseWheelEvent,
                Source = sender
            };
            ScrollViewer.RaiseEvent(eventArg);
        }
        
        /// <summary>
        /// 窗口拖动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridTitle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        #region 生成个人面板
        
        public void GenerateMenu(string msg)
        {
            switch (msg)
            {
                case "管理员": GenerateAdminMenu(); break;
                case "用户": GenerateNormMenu(); break;
                case "患者": GeneratePatiMenu(); break;
                case "医生": GenerateDoctMenu(); break;
                case "药师": GeneratePhstMenu(); break;
                case "挂号员": GenerateRgstMenu(); break;
                case "收费员": GenerateTollMenu(); break;
                case "护士": GenerateNurseMenu(); break;
                default: GenerateNoLoginMenu(); break;
            }
        }
        
        #region 生成管理员的个人面板
        public void GenerateAdminMenu()
        {
            var item0 = new ItemMenu("主页", new IndexPage(), PackIconKind.ViewDashboard);

            var menuAuth = new List<SubItem>
            {
                new SubItem("所有用户", new CheckUserPage()),
                new SubItem("权限改动", new AuthChangePage()),
                new SubItem("申请审核")
            };
            var item2 = new ItemMenu("用户权限管理", menuAuth, PackIconKind.ShoppingBasket);

            Menu.Children.Add(new UserControlMenuItem(item0, this));
            Menu.Children.Add(new UserControlMenuItem(item2, this));
        }
        #endregion
        
        #region 生成未登录用户的个人面板
        public void GenerateNoLoginMenu()
        {
            var item0 = new ItemMenu("主页", new IndexPage(), PackIconKind.ViewDashboard);
            
            var menuConsult = new List<SubItem>
            {
                new SubItem("地图"),
                new SubItem("病情咨询"),
                new SubItem("科室信息"),
                new SubItem("医生状态")
            };
            var item1 = new ItemMenu("咨询", menuConsult, PackIconKind.About);
            
            var item2 = new ItemMenu("反馈", new IndexPage(), PackIconKind.ShoppingBasket);

            Menu.Children.Add(new UserControlMenuItem(item0, this));
            Menu.Children.Add(new UserControlMenuItem(item1, this));
            Menu.Children.Add(new UserControlMenuItem(item2, this));
        }
        #endregion
        
        #region 生成普通用户的个人面板
        public void GenerateNormMenu()
        {
            var item0 = new ItemMenu("主页", new IndexPage(), PackIconKind.ViewDashboard);
            
            var menuRegister = new List<SubItem>
            {
                new SubItem("我的账号", new MyAccountPage(_dashBoardViewModel.UserName, this)),
                new SubItem("实名认证"),
                new SubItem("我的病历")
            };
            var item1 = new ItemMenu("我的", menuRegister, PackIconKind.Register);

            var menuConsult = new List<SubItem>
            {
                new SubItem("地图"),
                new SubItem("病情咨询"),
                new SubItem("科室信息"),
                new SubItem("医生状态")
            };
            var item2 = new ItemMenu("咨询", menuConsult, PackIconKind.About);
            
            var menuSchedule = new List<SubItem>
            {
                new SubItem("我要挂号"),
                new SubItem("挂号记录")
            };
            var item3 = new ItemMenu("挂号", menuSchedule, PackIconKind.Schedule);

            var menurelatives = new List<SubItem>
            {
                new SubItem("我的亲属"),
                new SubItem("亲属绑定")
            };
            var item5 = new ItemMenu("亲属", menurelatives, PackIconKind.FileReport);
            
            var item6 = new ItemMenu("反馈", new IndexPage(), PackIconKind.ShoppingBasket);

            Menu.Children.Add(new UserControlMenuItem(item0, this));
            Menu.Children.Add(new UserControlMenuItem(item1, this));
            Menu.Children.Add(new UserControlMenuItem(item2, this));
            Menu.Children.Add(new UserControlMenuItem(item3, this));
            Menu.Children.Add(new UserControlMenuItem(item5, this));
            Menu.Children.Add(new UserControlMenuItem(item6, this));
        }
        #endregion
        
        #region 生成患者的个人面板
        public void GeneratePatiMenu()
        {
            var item0 = new ItemMenu("主页", new IndexPage(), PackIconKind.ViewDashboard);
            
            var menuRegister = new List<SubItem>
            {
                new SubItem("我的账号", new MyAccountPage(_dashBoardViewModel.UserName, this)),
                new SubItem("实名认证"),
                new SubItem("我的病历"),
                new SubItem("复诊信息")
            };
            var item1 = new ItemMenu("我的", menuRegister, PackIconKind.Register);

            var menuConsult = new List<SubItem>
            {
                new SubItem("地图"),
                new SubItem("病情咨询"),
                new SubItem("科室信息"),
                new SubItem("医生状态")
            };
            var item2 = new ItemMenu("咨询", menuConsult, PackIconKind.About);
            
            var menuSchedule = new List<SubItem>
            {
                new SubItem("我要挂号"),
                new SubItem("本次挂号信息"),
                new SubItem("挂号记录")
            };
            var item3 = new ItemMenu("挂号", menuSchedule, PackIconKind.Schedule);

            var menuPays = new List<SubItem>
            {
                new SubItem("挂号缴费"),
                new SubItem("药品缴费"),
                new SubItem("缴费单"),
                new SubItem("退款"),
                new SubItem("发票打印")
            };
            var item4 = new ItemMenu("缴费", menuPays, PackIconKind.FileReport);
            
            var menurelatives = new List<SubItem>
            {
                new SubItem("我的亲属"),
                new SubItem("亲属绑定")
            };
            var item5 = new ItemMenu("亲属", menurelatives, PackIconKind.FileReport);
            
            var item6 = new ItemMenu("反馈", new IndexPage(), PackIconKind.ShoppingBasket);

            Menu.Children.Add(new UserControlMenuItem(item0, this));
            Menu.Children.Add(new UserControlMenuItem(item1, this));
            Menu.Children.Add(new UserControlMenuItem(item2, this));
            Menu.Children.Add(new UserControlMenuItem(item3, this));
            Menu.Children.Add(new UserControlMenuItem(item4, this));
            Menu.Children.Add(new UserControlMenuItem(item5, this));
            Menu.Children.Add(new UserControlMenuItem(item6, this));
        }
        #endregion
        
        #region 生成医生的个人面板
        public void GenerateDoctMenu()
        {
            var item0 = new ItemMenu("主页", new IndexPage(), PackIconKind.ViewDashboard);
            
            var menuDoctor = new List<SubItem>()
            {
                new SubItem("科室患者", new PatiAdmissionPage(this, _userName)),
                new SubItem("诊断病历", new DiagnosisPage(this, _userName)),
                new SubItem("医院医嘱", new OrderWritePage(_userName)),
            };
            var item1 = new ItemMenu("工作站", menuDoctor, PackIconKind.Work);
            
            var item2 = new ItemMenu("反馈", new IndexPage(), PackIconKind.ShoppingBasket);

            Menu.Children.Add(new UserControlMenuItem(item0, this));
            Menu.Children.Add(new UserControlMenuItem(item1, this));
            Menu.Children.Add(new UserControlMenuItem(item2, this));
        }
        #endregion
        
        #region 生成药师的个人面板
        public void GeneratePhstMenu()
        {
            var item0 = new ItemMenu("主页", new IndexPage(), PackIconKind.ViewDashboard);
            var menuPhst = new List<SubItem>()
            {
                new SubItem("医嘱列表", new OrderListPage(this, _userName)),
                new SubItem("医嘱执行", new OrderExecPage(this, _userName))
            };
            var item1 = new ItemMenu("用药管理", menuPhst, PackIconKind.Work);
            var item2 = new ItemMenu("反馈", new IndexPage(), PackIconKind.Medicine);

            Menu.Children.Add(new UserControlMenuItem(item0, this));
            Menu.Children.Add(new UserControlMenuItem(item1, this));
            Menu.Children.Add(new UserControlMenuItem(item2, this));
        }
        #endregion
        
        #region 生成护士的个人面板
        public void GenerateNurseMenu()
        {
            var item0 = new ItemMenu("主页", new IndexPage(), PackIconKind.ViewDashboard);
            var item2 = new ItemMenu("反馈", new IndexPage(), PackIconKind.ShoppingBasket);

            Menu.Children.Add(new UserControlMenuItem(item0, this));
            Menu.Children.Add(new UserControlMenuItem(item2, this));
        }
        #endregion
        
        #region 生成挂号员的个人面板
        public void GenerateRgstMenu()
        {
            var item0 = new ItemMenu("主页", new IndexPage(), PackIconKind.ViewDashboard);

            var menuRegister = new List<SubItem>()
            {
                new SubItem("患者信息", new PatiInfoPage(this, _userName)),
                new SubItem("挂号", new RegisterPage(_userName)),
                new SubItem("退号", new UnRegisterPage()),
            };
            var item1 = new ItemMenu("挂号", menuRegister, PackIconKind.Register);    
            
            var item2 = new ItemMenu("反馈", new IndexPage(), PackIconKind.ShoppingBasket);

            Menu.Children.Add(new UserControlMenuItem(item0, this));
            Menu.Children.Add(new UserControlMenuItem(item1, this));
            Menu.Children.Add(new UserControlMenuItem(item2, this));
        }
        #endregion
        
        #region 生成收费员的个人面板
        public void GenerateTollMenu()
        {
            var item0 = new ItemMenu("主页", new IndexPage(), PackIconKind.ViewDashboard);
            var menuPhst = new List<SubItem>()
            {
                new SubItem("挂号收费", new PatiOutChargePage(_userName)),
                new SubItem("医嘱收费", new OrderChargePage(_userName))
            };
            var item1 = new ItemMenu("收费管理", menuPhst, PackIconKind.Work);
            var item2 = new ItemMenu("反馈", new IndexPage(), PackIconKind.ShoppingBasket);

            Menu.Children.Add(new UserControlMenuItem(item0, this));
            Menu.Children.Add(new UserControlMenuItem(item1, this));
            Menu.Children.Add(new UserControlMenuItem(item2, this));
        }
        #endregion
        #endregion
        

        
    }
}
