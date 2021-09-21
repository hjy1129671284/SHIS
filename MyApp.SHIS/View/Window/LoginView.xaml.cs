using System.Windows;
using SqlSugar;
using System.Diagnostics;
using System.Windows.Input;
using Models;
using DbType = SqlSugar.DbType;
using MyApp.SHIS.Commom;

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
            
            //SqlSugar 注入
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

            // 创建实体
            // db.DbFirst.IsCreateAttribute().CreateClassFile("D:\\C Sharp\\demo\\SHIS\\MyApp.SHIS\\Models", "Models");
            
            // 创建表
            // db.CodeFirst.SetStringDefaultLength(200).InitTables(typeof(pati_user));
            
            //查询表的所有

            string userName = NameTextBox.Text;

            if (scope.Queryable<user>().Any(it => it.UserName == userName))
            {
                var result = scope.Queryable<user>().Where(it => it.UserName == userName).ToList();

                bool loginFlag = result[0].UserPwd == PasswordBox.Password;
            
                if (loginFlag)
                {
                    MessageBox.Show($"登录成功，欢迎 {userName}");
                    ViewManage.ChangeView(this, new DashBoardView(true, userName));
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