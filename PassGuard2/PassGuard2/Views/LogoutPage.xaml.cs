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
	public partial class LogoutPage : ContentPage
	{
		public LogoutPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            App.IsUserLoggedIn = false;
            App.Current.MainPage = new LoginPage();
        }
    }
}