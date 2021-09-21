using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using MyApp.SHIS.Commom;
using MyApp.SHIS.View.Pages;
using MyApp.SHIS.ViewModel;
using SqlSugar.IOC;

namespace MyApp.SHIS.View.Window
{
    public partial class DashBoardView
    {
        public bool LoginFlag { get; set; }
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
            
            var menuRegister = new List<SubItem>();
            menuRegister.Add(new SubItem("Customer"));
            menuRegister.Add(new SubItem("Providers"));
            menuRegister.Add(new SubItem("Employees"));
            menuRegister.Add(new SubItem("Products"));
            var item6 = new ItemMenu("Register", menuRegister, PackIconKind.Register);

            var menuSchedule = new List<SubItem>();
            menuSchedule.Add(new SubItem("Services"));
            menuSchedule.Add(new SubItem("Meetings"));
            var item1 = new ItemMenu("Appointments", menuSchedule, PackIconKind.Schedule);

            var menuReports = new List<SubItem>();
            menuReports.Add(new SubItem("Customers"));
            menuReports.Add(new SubItem("Providers"));
            menuReports.Add(new SubItem("Products"));
            menuReports.Add(new SubItem("Stock"));
            menuReports.Add(new SubItem("Sales"));
            var item2 = new ItemMenu("Reports", menuReports, PackIconKind.FileReport);

            var menuExpenses = new List<SubItem>();
            menuExpenses.Add(new SubItem("Fixed"));
            menuExpenses.Add(new SubItem("Variable"));
            var item3 = new ItemMenu("Expenses", menuExpenses, PackIconKind.ShoppingBasket);

            var menuFinancial = new List<SubItem>();
            menuFinancial.Add(new SubItem("Cash flow"));
            var item4 = new ItemMenu("Financial", menuFinancial, PackIconKind.ScaleBalance);

            var item0 = new ItemMenu("Dashboard", new UserControl(), PackIconKind.ViewDashboard);

            Menu.Children.Add(new UserControlMenuItem(item0));
            Menu.Children.Add(new UserControlMenuItem(item6));
            Menu.Children.Add(new UserControlMenuItem(item1));
            Menu.Children.Add(new UserControlMenuItem(item2));
            Menu.Children.Add(new UserControlMenuItem(item3));
            Menu.Children.Add(new UserControlMenuItem(item4));
            
        }
        
        // 登录后窗口
        public DashBoardView(bool loginFlag, string username)
        {
            InitializeComponent();

            UserNameTextBlock.Text = username;
            UserNameButton.Content = "退出登录";
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

        private void UIElement_OnMouseLeftButtonDown1(object sender, MouseButtonEventArgs e)
        {
            ContentControl.Content = new Frame()
            {
                Content = new IndexPage()
            };
        }

        private void UIElement_OnMouseLeftButtonDown2(object sender, MouseButtonEventArgs e)
        {
            ContentControl.Content = new Frame()
            {
                Content = new BlankPage()
            };
        }
    }
}
