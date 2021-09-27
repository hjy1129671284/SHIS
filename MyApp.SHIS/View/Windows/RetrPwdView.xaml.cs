using System.Diagnostics;
using System.Windows;
using Models;
using MyApp.SHIS.Commom;
using SqlSugar;

namespace MyApp.SHIS.View.Windows
{
    public partial class RetrPwdView
    {
        public RetrPwdView()
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
            if (scope.Queryable<user>().Any(it => it.UserName == userName))
            {
                var result = scope.Queryable<user>().Where(it => it.UserName == userName).ToList();
                MessageBox.Show($"用户{userName},您好,您的密码可能是{result[0].UserPwd}");
            }
            else
            {
                MessageBox.Show("此账号不存在，请尝试注册账号");
            }

        }
    }
}