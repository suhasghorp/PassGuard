using PassGuard2.Models;
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
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage ()
		{
			InitializeComponent ();
		}

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            string Username = entry_regUsername.Text;
            string Password = entry_regPassword.Text;
            string Password_again = entry_regPassword_again.Text;

            if (string.IsNullOrEmpty(Username))
            {
                await DisplayAlert("Register", "Please enter Username", "OK");
                return;
            }
            if (string.IsNullOrEmpty(Password))
            {
                await DisplayAlert("Register", "Please enter Password", "OK");
                return;
            }
            if (string.IsNullOrEmpty(Password_again))
            {
                await DisplayAlert("Register", "Please re-enter Password", "OK");
                return;
            }

            if (Password != Password_again)
            {
                await DisplayAlert("Register", "Both passwords do not match. Please enter Passwords again.", "OK");
                return;
            }

            bool ret = new RealmDBService().DeleteUsersAndRecords();
            if (!ret)
            {
                await DisplayAlert("Register", "Registration Failed", "OK");
                return;
            }
            
            ret = new RealmDBService().SaveUser(Username, Password);
            if (ret)
            {
                await DisplayAlert("Register", "Registration Successful", "OK");
                App.Current.MainPage = new LoginPage();
            }
            else
            {
                await DisplayAlert("Register", "Registration Failed", "OK");
            }
            return;
        }
    }
}