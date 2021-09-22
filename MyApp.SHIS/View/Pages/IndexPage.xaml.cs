using System;
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

namespace MyApp.SHIS.View.Pages
{
    public partial class IndexPage : Page
    {
        public IndexPage()
        {
            InitializeComponent();
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            
            UserService _iuserService = new UserService(new UserRepository());
            DataGrid.ItemsSource = await _iuserService.QueryAsync();
            
        }
    }
}