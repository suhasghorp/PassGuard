﻿using PassGuard2.Models;
using PassGuard2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PassGuard2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
            if (new RealmDBService().GetNumberOfUsers() > 0)
            {
                RegisterButton.IsVisible = false;
            }
		}

        private async void LoginButton_OnClicked(object sender, EventArgs e)
        {
            string Username = entry_Username.Text;
            string Password = entry_Password.Text;


            var isValid = AreCredentialsCorrect(Username, Password);
            if (isValid)
            {
                App.IsUserLoggedIn = true;
                if (Device.iOS == Device.RuntimePlatform)
                {
                    await Navigation.PopToRootAsync();
                }
                Application.Current.MainPage = new MainPage();
            }
            else
            {
                await DisplayAlert("Login", "Login Failed", "OK");
                entry_Password.Text = string.Empty;
            }


           
        }

        bool AreCredentialsCorrect(string Username, string Password)
        {
            User user = new RealmDBService().GetUser(Username, Password);
            if (user == null)
                return false;
            return true;
        }

        private async void RegisterButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}