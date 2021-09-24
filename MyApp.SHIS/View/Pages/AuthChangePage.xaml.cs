using System.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Models;
using MyApp.SHIS.Repository.Repository;
using MyApp.SHIS.Services.Services;

namespace MyApp.SHIS.View.Pages
{
    public partial class AuthChangePage : Page
    {
        public AuthChangePage()
        {
            InitializeComponent();
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            string userName = UserNameTextBox.Text;
            UserService userService = new UserService(new UserRepository());
            var result = await userService.QueryAsync(it => it.UserName == userName);
            if (result != null && result.Count > 0)
            {
                DataGrid.ItemsSource = result;
            }
            else
            {
                MessageBox.Show($"没找到{userName}");
            }
        }

        public void ChangeAuthButton_OnClick(object sender, RoutedEventArgs e)
        {
            string userName = UserNameTextBox.Text;
            
            string targetTypeString = AuthComboBox.SelectionBoxItem.ToString();
            switch (targetTypeString)
            {
                case "管理员":  UpdateUserType(userName, 0).Wait(); break;
                case "普通用户":  UpdateUserType(userName, 1).Wait(); break;
                case "病人":   UpdateUserType(userName, 2).Wait(); break;
                case "医生":   UpdateUserType(userName, 3).Wait(); break;
                case "药师":  UpdateUserType(userName, 4).Wait(); break;
                case "挂号员":  UpdateUserType(userName, 5).Wait(); break;
                case "收费员":  UpdateUserType(userName, 6).Wait(); break;
                case "护士":  UpdateUserType(userName, 7).Wait(); break;
            }
        }
        
        public async Task UpdateUserType(string userName, int userType)
        {
            UserService userService = new UserService(new UserRepository());
            var user = await userService.QueryAsync(it => it.UserName == userName);
            user[0].UserType = userType;
            await userService.EditAsync(user[0]);
        }


        private void UserNameTextBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                ButtonBase_OnClick(this, new RoutedEventArgs());
            }
        }
        
    }
}