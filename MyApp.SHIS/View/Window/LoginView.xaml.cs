using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MyApp.SHIS.Commom;
using MyApp.SHIS.Repository.Repository;
using MyApp.SHIS.Services.Services;

namespace MyApp.SHIS.View.Window
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginView
    {
        public LoginView()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            UserService userService = new UserService(new UserRepository());

            string userName = NameTextBox.Text;
            string userType = ((ListBoxItem)ListBox.SelectedItem).Content.ToString();
            var result = userService.QueryAsync(it => it.UserName == userName).Result;

            if (result != null && result.Count > 0)
            {
                if (result[0].UserPwd == PasswordBox.Password)
                {
                    MessageBox.Show($"登录成功，欢迎 {userName}");
                    ViewManage.ChangeView(this, new DashBoardView(userName, userType));
                }
                else
                {
                    MessageBox.Show("密码错误，登录失败");
                }
            }
            else
            {
                MessageBox.Show("帐号不存在，登录失败");
            }
            
        }

        private void TextBox1_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ViewManage.ChangeView(this, new RegisterView());
        }

        private void TextBox2_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ViewManage.ChangeView(this, new RetrPwdView());
        }

        private void BackToDashBoardButton_Click(object sender, RoutedEventArgs e)
        {
            ViewManage.ChangeView(this, new DashBoardView());
        }
        
    }
}