using System.Collections.Generic;
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
            
            GenerateMenu();

        }
        
        // 登录后窗口
        public DashBoardView(string username, string userType)
        {
            InitializeComponent();
            GenerateMenu();
            UserNameTextBlock.Text = username;
            UserNameButton.Content = "退出登录";
        }

        public void GenerateMenu()
        {
            var item0 = new ItemMenu("主页", new IndexPage(), PackIconKind.ViewDashboard);
            
            var menuRegister = new List<SubItem>();
            menuRegister.Add(new SubItem("我的账号", new MyAccountPage()));
            menuRegister.Add(new SubItem("实名认证", new MyAccountPage()));
            menuRegister.Add(new SubItem("我的病历", new MyAccountPage()));
            menuRegister.Add(new SubItem("复诊信息", new MyAccountPage()));
            var item1 = new ItemMenu("我的", menuRegister, PackIconKind.Register);

            var menuSchedule = new List<SubItem>();
            menuSchedule.Add(new SubItem("我要挂号"));
            menuSchedule.Add(new SubItem("本次挂号信息"));
            menuSchedule.Add(new SubItem("挂号记录"));
            var item2 = new ItemMenu("挂号", menuSchedule, PackIconKind.Schedule);

            var menuPays = new List<SubItem>();
            menuPays.Add(new SubItem("挂号缴费"));
            menuPays.Add(new SubItem("药品缴费"));
            menuPays.Add(new SubItem("缴费单"));
            var item3 = new ItemMenu("缴费", menuPays, PackIconKind.FileReport);
            
            var menurelatives = new List<SubItem>();
            menurelatives.Add(new SubItem("我的亲属"));
            menurelatives.Add(new SubItem("亲属绑定"));
            var item4 = new ItemMenu("亲属", menurelatives, PackIconKind.FileReport);
            
            var item5 = new ItemMenu("用户反馈", new IndexPage(), PackIconKind.ShoppingBasket);

            Menu.Children.Add(new UserControlMenuItem(item0, this));
            Menu.Children.Add(new UserControlMenuItem(item1, this));
            Menu.Children.Add(new UserControlMenuItem(item2, this));
            Menu.Children.Add(new UserControlMenuItem(item3, this));
            Menu.Children.Add(new UserControlMenuItem(item4, this));
            Menu.Children.Add(new UserControlMenuItem(item5, this));
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
    }
}
