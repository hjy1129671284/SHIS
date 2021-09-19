using System.Windows;

namespace MyApp.SHIS.View
{
    public partial class RetrPwdView
    {
        public RetrPwdView()
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