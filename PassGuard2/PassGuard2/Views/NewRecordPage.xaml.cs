using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PassGuard2.Models;

namespace PassGuard2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewRecordPage : ContentPage
    {
        public Record Record { get; set; }

        public NewRecordPage()
        {
            InitializeComponent();

            Record = new Record
            {
                Category = string.Empty,
                Name = string.Empty,
                Url = @"http://",
                Login = string.Empty,
                Password = string.Empty,
                Notes = string.Empty
            };

            BindingContext = this;

            entry_category.Keyboard = Keyboard.Create(KeyboardFlags.CapitalizeWord);
            entry_name.Keyboard = Keyboard.Create(KeyboardFlags.CapitalizeWord);
            entry_url.Keyboard = Keyboard.Url;
            entry_login.Keyboard = Keyboard.Create(KeyboardFlags.CapitalizeNone);
            entry_password.Keyboard = Keyboard.Create(KeyboardFlags.CapitalizeNone);
            entry_notes.Keyboard = Keyboard.Create(KeyboardFlags.CapitalizeWord);

        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Record.Category))
                Record.Category = "Miscellaneous";

            if (Record.Url == @"http://")
                Record.Url = @"http://no_url_provided";

            if (string.IsNullOrEmpty(Record.Name))
            {
                await DisplayAlert("New Record", "Please enter Name for the record", "OK");
                return;
            }
            if (string.IsNullOrEmpty(Record.Login))
            {
                await DisplayAlert("New Record", "Please enter Login for the record", "OK");
                return;
            }
            if (string.IsNullOrEmpty(Record.Password))
            {
                await DisplayAlert("New Record", "Please enter Password for the record", "OK");
                return;
            }


            MessagingCenter.Send(this, "AddRecord", Record);
            await Navigation.PopAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}