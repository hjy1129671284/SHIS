using System.Windows;
using System.Windows.Controls;
using MyApp.SHIS.Repository.Repository;
using MyApp.SHIS.Services.Services;

namespace MyApp.SHIS.View.Pages
{
    public partial class CheckUserPage : Page
    {
        public CheckUserPage()
        {
            InitializeComponent();
        }


        #region 查看用户表
        private async void AllUserButton_OnClick(object sender, RoutedEventArgs e)
        {
            UserService userService = new UserService(new UserRepository());
            DataGrid.ItemsSource = await userService.QueryAsync();
        }
        
        private async void NormUserButton_OnClick(object sender, RoutedEventArgs e)
        {
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            DataGrid.ItemsSource = await normUserService.QueryAsync();
        }
        
        private async void StaffUserButton_OnClick(object sender, RoutedEventArgs e)
        {
            StaffUserService staffUserService = new StaffUserService(new StaffUserRepository());
            DataGrid.ItemsSource = await staffUserService.QueryAsync();
        }
        
        private async void PatiUserButton_OnClick(object sender, RoutedEventArgs e)
        {
            PatiUserService patiUserService = new PatiUserService(new PatiUserRepository());
            DataGrid.ItemsSource = await patiUserService.QueryAsync();
        }
        
        private async void DoctUserButton_OnClick(object sender, RoutedEventArgs e)
        {
            DoctUserService doctUserService = new DoctUserService(new DoctUserRepository());
            DataGrid.ItemsSource = await doctUserService.QueryAsync();
        }
        
        private async void PhstUserButton_OnClick(object sender, RoutedEventArgs e)
        {
            StaffUserService staffUserService = new StaffUserService(new StaffUserRepository());
            DataGrid.ItemsSource = await staffUserService.QueryAsync(it => it.StafType==3);
        }
        
        private async void RgstUserButton_OnClick(object sender, RoutedEventArgs e)
        {
            StaffUserService staffUserService = new StaffUserService(new StaffUserRepository());
            DataGrid.ItemsSource = await staffUserService.QueryAsync(it => it.StafType==4);
        }
        
        private async void TollUserButton_OnClick(object sender, RoutedEventArgs e)
        {
            StaffUserService staffUserService = new StaffUserService(new StaffUserRepository());
            DataGrid.ItemsSource = await staffUserService.QueryAsync(it => it.StafType==5);
        }
        
        private async void NurseUserButton_OnClick(object sender, RoutedEventArgs e)
        {
            StaffUserService staffUserService = new StaffUserService(new StaffUserRepository());
            DataGrid.ItemsSource = await staffUserService.QueryAsync(it => it.StafType==6);
        }
        #endregion
       
    }
}