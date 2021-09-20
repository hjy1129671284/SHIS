using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using Models;
using MyApp.SHIS.Repository;
using MyApp.SHIS.Repository.IRepository;
using MyApp.SHIS.Repository.Repository;
using MyApp.SHIS.Services;
using MyApp.SHIS.Services.IServices;
using MyApp.SHIS.Services.Services;
using SqlSugar;
using SqlSugar.IOC;

namespace MyApp.SHIS.View
{
    public partial class IndexPage : Page
    {
        public IndexPage()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
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
            
            // var result = DbScoped.Sugar.Queryable<user>().ToDataTable();
            //
            // DataGrid.ItemsSource = result.DefaultView;

            IUserRepository _iuserRepository = new UserRepository();

            IUserService _iuserService = new UserService(_iuserRepository);
            var result = _iuserRepository.QueryAsync();
            DataGrid.ItemsSource = result.Result;
        }
    }
}