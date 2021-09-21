using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MyApp.SHIS.Commom;
using SqlSugar.IOC;

namespace MyApp.SHIS.View
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
