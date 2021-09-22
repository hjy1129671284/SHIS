using System.Windows;
using SqlSugar;
using MyApp.SHIS.Commom;
using System.Diagnostics;
using System.Threading.Tasks;
using Models;
using MyApp.SHIS.Repository.Repository;
using MyApp.SHIS.Services.Services;

namespace MyApp.SHIS.View.Window
{
    public partial class RegisterView
    {
        public RegisterView()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ViewManage.ChangeView(this, new LoginView());
        }
        
        private void BackToDashBoardButton_Click(object sender, RoutedEventArgs e)
        {
            ViewManage.ChangeView(this, new DashBoardView());
        }

        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            UserService userService = new UserService(new UserRepository());
            NormUserService normUserService = new NormUserService(new NormUserRepository());

            string userName = NameTextBox.Text;
            string pwd1 = PasswordBox1.Password;
            string pwd2 = PasswordBox2.Password;

            var result = userService.QueryAsync(it => it.UserName == userName).Result;

            if (result != null && result.Count > 0)
            {
                MessageBox.Show("帐号已存在，注册失败");
            }
            else
            {
                if (pwd1 == pwd2)
                {
                    // 插入数据
                    await userService.CreateAsync(new user() { UserName = userName, UserPwd = pwd1, UserType = 1});
                    await normUserService.CreateAsync(new norm_user() {UserName = userName});
                    MessageBox.Show("注册成功");
                }
                else
                {
                    MessageBox.Show("两次输入密码不同，注册失败");
                }
                
            }
            
        }
    }
}