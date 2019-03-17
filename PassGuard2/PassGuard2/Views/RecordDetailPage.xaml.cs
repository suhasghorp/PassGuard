using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PassGuard2.Models;
using PassGuard2.ViewModels;

namespace PassGuard2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecordDetailPage : ContentPage
    {
        RecordDetailViewModel viewModel;

        public RecordDetailPage(RecordDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public RecordDetailPage()
        {
            InitializeComponent();

            var record = new Record
            {
                Category = "Category",
                Name = "Name",
                Url = "URL for the website",
                Login = "Login",
                Password = "Password",
                Notes = "Notes"
            };

            viewModel = new RecordDetailViewModel(record);
            BindingContext = viewModel;
        }

        async void DeleteRecord_Clicked(object sender, EventArgs args)
        {
            var answer = await DisplayAlert("Delete", "Do you want to delete " + viewModel.Record.Name + "?", "Yes", "No");
            if (answer)
            {
                MessagingCenter.Send(this, "DeleteRecord", viewModel.Record);
                await Navigation.PopAsync();
            }
        }
    }
}