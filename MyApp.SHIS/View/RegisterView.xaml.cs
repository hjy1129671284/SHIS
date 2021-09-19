using System.Windows;
using SqlSugar;



namespace MyApp.SHIS.View
{
    public partial class RegisterView : Window
    {
        public RegisterView()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            LoginView lv = new LoginView();
            lv.Top = this.Top;
            lv.Left = this.Left;
            lv.Show();
            this.Close();
        }
    }
}