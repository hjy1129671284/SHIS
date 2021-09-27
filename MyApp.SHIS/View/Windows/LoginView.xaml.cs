using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Models;
using MyApp.SHIS.Commom;
using MyApp.SHIS.Repository.Repository;
using MyApp.SHIS.Services.Services;

namespace MyApp.SHIS.View.Windows
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
            string userName = NameTextBox.Text;
            string userType = ((ListBoxItem)ListBox.SelectedItem).Content.ToString();
            
            LoginAdjust(userName, userType);
            
        }
        
        private void UIElement_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                string userName = NameTextBox.Text;
                string userType = ((ListBoxItem)ListBox.SelectedItem).Content.ToString();
            
                LoginAdjust(userName, userType);
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

        #region 帐号登录判断
        public async void LoginAdjust(string userName, string userType)
        {
            UserService userService = new UserService(new UserRepository());
            StaffUserService staffUserService = new StaffUserService(new StaffUserRepository());
            int type = 1;

            switch (userType)
            {
                case "管理员": type = 0; break;
                case "病人": type = 2; break;
                case "职工":
                    var staff = await staffUserService.QueryAsync(it => it.UserName == userName);
                    type = staff[0].StafType;
                    break;
            }

            var users = await userService.QueryAsync(it => it.UserName == userName);
            if (users != null && users.Count > 0)
            {
                if (users[0].UserPwd == PasswordBox.Password)
                {
                    var loginFlag = AuthAdjust(users, type);
                    if (loginFlag)
                    {
                        MessageBox.Show($"登录成功，欢迎{userType} {userName}");
                        ViewManage.ChangeView(this, new DashBoardView(userName, type));
                    }
                    else
                    {
                        MessageBox.Show($"登录失败，您的账号并不是{userType}，请切换账号类型或者输入正确的帐号密码");
                    }
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
        #endregion
        
        
        #region 根据选择的登陆帐号类型和数据库中的账号类型判断用户是否有权限登录
        public bool AuthAdjust(List<user> users, int type)
        {
            int usertype = users[0].UserType;
            bool flag = false;
            if (type == 1)
            {
                flag = true;
            }
            else if (type == 2)
            {
                if (usertype != 1)
                {
                    flag = true;
                }
            }
            else
            {
                if (type == usertype)
                {
                    flag = true;
                }
            }
            return flag;
        }
        #endregion

        
    }
}