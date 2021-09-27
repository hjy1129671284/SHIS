/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using MyApp.SHIS.View;
using MyApp.SHIS.ViewModel.PagesViewModels;
using MyApp.SHIS.ViewModel.UserControlsViewModels;
using MyApp.SHIS.ViewModel.WindowsViewModels;

namespace MyApp.SHIS.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<DashBoardViewModel>();
            SimpleIoc.Default.Register<IDAutherViewModel>();
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<RegisterViewModel>();
            SimpleIoc.Default.Register<RetrPwdViewModel>();
            SimpleIoc.Default.Register<ItemMenu>();
            SimpleIoc.Default.Register<SubItem>();
            SimpleIoc.Default.Register<AuthChangePageViewModel>();
            SimpleIoc.Default.Register<BlankPageViewModel>();
            SimpleIoc.Default.Register<CheckUserPageViewModel>();
            SimpleIoc.Default.Register<IndexPageViewModel>();
            SimpleIoc.Default.Register<MyAccountPageViewModel>();
            SimpleIoc.Default.Register<SettingPageViewModel>();
            SimpleIoc.Default.Register<VerifiedPageViewModel>();
            
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public DashBoardViewModel DashBoard => ServiceLocator.Current.GetInstance<DashBoardViewModel>();
        public IDAutherViewModel IDAuther => ServiceLocator.Current.GetInstance<IDAutherViewModel>();
        public LoginViewModel LoginView => ServiceLocator.Current.GetInstance<LoginViewModel>();
        public RegisterViewModel Register => ServiceLocator.Current.GetInstance<RegisterViewModel>();
        public RetrPwdViewModel RetrPwd => ServiceLocator.Current.GetInstance<RetrPwdViewModel>();
        public AuthChangePageViewModel AuthChangePage => ServiceLocator.Current.GetInstance<AuthChangePageViewModel>();
        public BlankPageViewModel BlankPage => ServiceLocator.Current.GetInstance<BlankPageViewModel>();
        public CheckUserPageViewModel CheckUserPage => ServiceLocator.Current.GetInstance<CheckUserPageViewModel>();
        public IndexPageViewModel IndexPage => ServiceLocator.Current.GetInstance<IndexPageViewModel>();
        public MyAccountPageViewModel MyAccountPage => ServiceLocator.Current.GetInstance<MyAccountPageViewModel>();
        public SettingPageViewModel SettingPage => ServiceLocator.Current.GetInstance<SettingPageViewModel>();
        public VerifiedPageViewModel VerifiedPage => ServiceLocator.Current.GetInstance<VerifiedPageViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}