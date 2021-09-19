using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace MyApp.SHIS.View
{
    public partial class DashBoardView
    {
        public bool LoginFlag { get; set; }
        public string UserName { get; set; }
        
        // 未登录窗口
        public DashBoardView()
        {
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
            LoginView lv = new LoginView();
            lv.Top = this.Top;
            lv.Left = this.Left;
            lv.Show();
            this.Close();
        }
    }
}
