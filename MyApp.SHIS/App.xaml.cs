using System;
using System.Globalization;
using System.Reflection;
using System.Windows;
using MyApp.SHIS.View.Windows;

namespace MyApp.SHIS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public App()
        {
            
        }

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            DashBoardView dashBoardView = new DashBoardView("", -1);
            dashBoardView.Show();
        }
    }
}