﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using MyApp.SHIS.Commom;
using MyApp.SHIS.View.Pages;
using MyApp.SHIS.ViewModel;
using SqlSugar.Extensions;
using SqlSugar.IOC;

namespace MyApp.SHIS.View.Window
{
    public partial class DashBoardView
    {
        public string UserName { get; set; }
        
        // 未登录窗口
        public DashBoardView()
        {
            // SqlSugar.IOC 注入
            SugarIocServices.AddSqlSugar(new IocConfig()
            {
                ConnectionString = "server=localhost;port=3306;uid=root;pwd=hjyhjyhjy;database=his",
                DbType = IocDbType.MySql,
                IsAutoCloseConnection = true//自动释放
            }); 
            InitializeComponent();
            GenerateNoLoginMenu();

            // 生成实体
            // DbScoped.Sugar.DbFirst.IsCreateAttribute().CreateClassFile("D:\\C Sharp\\demo\\SHIS\\MyApp.SHIS\\Models", "Models");
        }
        
        // 登录后窗口
        public DashBoardView(string username, int userType)
        {
            InitializeComponent();
            
            UserNameButton.Content = "退出登录";
            switch (userType)
            {
                case 0: UserNameTextBlock.Text = "管理员 "+username; GenerateAdminMenu(); break;
                case 1: UserNameTextBlock.Text = "用户 "+username; GenerateNormMenu(); break;
                case 2: UserNameTextBlock.Text = "患者 "+username; GeneratePatiMenu(); break;
                case 3: UserNameTextBlock.Text = "医生 "+username; GenerateDoctMenu(); break;
                case 4: UserNameTextBlock.Text = "药师 "+username; GeneratePhstMenu(); break;
                case 5: UserNameTextBlock.Text = "挂号员 "+username; GenerateRgstMenu(); break;
                case 6: UserNameTextBlock.Text = "收费员 "+username; GenerateTollMenu(); break;
                case 7: UserNameTextBlock.Text = "护士 "+username; GenerateNurseMenu(); break;
            }
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

        private void ButtonPopUpLogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }
        
        private void GridTitle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void UserNameButton_OnClick(object sender, RoutedEventArgs e)
        {
            ViewManage.ChangeView(this, new LoginView());
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            SwitchPages(new SettingPage());
        }
        
        #region 生成管理员的个人面板
        public void GenerateAdminMenu()
        {
            var item0 = new ItemMenu("主页", new IndexPage(), PackIconKind.ViewDashboard);

            var menuAuth = new List<SubItem>
            {
                new SubItem("所有用户", new CheckUserPage()),
                new SubItem("权限改动"),
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
                new SubItem("我的账号", new MyAccountPage()),
                new SubItem("实名认证", new MyAccountPage()),
                new SubItem("我的病历", new MyAccountPage()),
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
                new SubItem("我的账号", new MyAccountPage()),
                new SubItem("实名认证", new MyAccountPage()),
                new SubItem("我的病历", new MyAccountPage()),
                new SubItem("复诊信息", new MyAccountPage())
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
                new SubItem("缴费单")
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
            var item2 = new ItemMenu("反馈", new IndexPage(), PackIconKind.ShoppingBasket);

            Menu.Children.Add(new UserControlMenuItem(item0, this));
            Menu.Children.Add(new UserControlMenuItem(item2, this));
        }
        #endregion
        
        #region 生成药师的个人面板
        public void GeneratePhstMenu()
        {
            var item0 = new ItemMenu("主页", new IndexPage(), PackIconKind.ViewDashboard);
            var item2 = new ItemMenu("反馈", new IndexPage(), PackIconKind.ShoppingBasket);

            Menu.Children.Add(new UserControlMenuItem(item0, this));
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
            var item2 = new ItemMenu("反馈", new IndexPage(), PackIconKind.ShoppingBasket);

            Menu.Children.Add(new UserControlMenuItem(item0, this));
            Menu.Children.Add(new UserControlMenuItem(item2, this));
        }
        #endregion
        
        #region 生成收费员的个人面板
        public void GenerateTollMenu()
        {
            var item0 = new ItemMenu("主页", new IndexPage(), PackIconKind.ViewDashboard);
            var item2 = new ItemMenu("反馈", new IndexPage(), PackIconKind.ShoppingBasket);

            Menu.Children.Add(new UserControlMenuItem(item0, this));
            Menu.Children.Add(new UserControlMenuItem(item2, this));
        }
        #endregion
    }
}
