﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PassGuard2.Views;
using PassGuard2.Services;

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
            else
            {
                if (new RealmDBService().GetNumberOfUsers() == 0)
                {
                    MainPage = new NavigationPage(new RegisterPage())
                    {
                        BarBackgroundColor = Color.FromHex("#301536"),
                        BarTextColor = Color.White
                    };
                }
                else
                {
                    MainPage = new NavigationPage(new LoginPage())
                    {
                        BarBackgroundColor = Color.FromHex("#301536"),
                        BarTextColor = Color.White
                    };
                }

            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            IsUserLoggedIn = false;
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            IsUserLoggedIn = false;
        }

        
    }
}
