using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PassGuard2.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PassGuard2
{
    public partial class App : Application
    {
        public static bool IsUserLoggedIn = false;
        public App()
        {
            InitializeComponent();
            IsUserLoggedIn = false;
            // The root page of your application
            if (IsUserLoggedIn)
            {
                MainPage = new NavigationPage(new MainPage());
            }
            else MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
