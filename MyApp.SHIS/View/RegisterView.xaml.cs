using System.Windows;
using SqlSugar;
using MyApp.SHIS.Commom;
using System.Diagnostics;
using Models;

namespace MyApp.SHIS.View
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

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            SqlSugarScope scope = new SqlSugarScope(new ConnectionConfig()
            {
                ConnectionString = "server=localhost;port=3306;uid=root;pwd=hjyhjyhjy;database=his",
                DbType = DbType.MySql,
                IsAutoCloseConnection = true
            });

            //调试SQL事件，可以删掉
            scope.Aop.OnLogExecuting = (sql, pars) =>
            {
                Trace.WriteLine(sql); //输出sql,查看执行sql
            };

            string userName = NameTextBox.Text;
            string pwd1 = PasswordBox1.Password;
            string pwd2 = PasswordBox2.Password;

            if (scope.Queryable<user>().Any(it => it.UserName == userName))
            {
                MessageBox.Show("帐号已存在，注册失败");
            }
            else
            {
                if (pwd1 == pwd2)
                {
                    // 插入数据
                    scope.Insertable(new user() { UserName = userName, UserPwd = pwd1, UserType = "1"}).ExecuteCommand();
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