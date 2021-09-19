using System.Windows;
using SqlSugar;
using System;
using System.Data;
using System.Text;
using Models;
using DbType = SqlSugar.DbType;

namespace MyApp.SHIS.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "server=localhost;port=3306;uid=root;pwd=hjyhjyhjy;database=his",
                DbType = DbType.MySql,
                IsAutoCloseConnection = true
            });

            //调试SQL事件，可以删掉
            db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql); //输出sql,查看执行sql
            };

            // 创建实体
            // db.DbFirst.IsCreateAttribute().CreateClassFile("D:\\C Sharp\\demo\\SHIS\\MyApp.SHIS\\Models", "Models");
            
            // 创建表
            // db.CodeFirst.SetStringDefaultLength(200).InitTables(typeof(pati_user));
            
            //查询表的所有

            if (db.Queryable<user>().Any(it => it.UserName == NameTextBox.Text))
            {
                var result = db.Queryable<user>().Where(it => it.UserName == NameTextBox.Text).First();

                bool loginFlag = result.UserPwd == PasswordBox.Password;
            
                if (loginFlag)
                {
                    MessageBox.Show("登录成功");
                }
                else
                {
                    MessageBox.Show("登录失败");
                }
            }
            else
            {
                MessageBox.Show("帐号不存在");
            }
            

            //插入
            // db.Insertable(new Student() { SchoolId = 1, Name = "jack" }).ExecuteCommand();

            //更新
            // db.Updateable(new Student() { Id = 1, SchoolId = 2, Name = "jack2" }).ExecuteCommand();

            //删除
            // db.Deleteable<Student>().Where(it => it.Id == 1).ExecuteCommand();
        }
    }
}