using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PassGuard2.Models;
using PassGuard2.Views;
using PassGuard2.ViewModels;

namespace PassGuard2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecordsPage : ContentPage
    {
        RecordsViewModel viewModel;

        public RecordsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new RecordsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var record = args.SelectedItem as Record;
            if (record == null)
                return;

            await Navigation.PushAsync(new RecordDetailPage(new RecordDetailViewModel(record)));

            // Manually deselect item.
            RecordsListView.SelectedItem = null;
        }

        async void AddRecord_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new NavigationPage(new NewRecordPage()));
            await Navigation.PushAsync(new NewRecordPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Records.Count == 0)
                viewModel.LoadRecordsCommand.Execute(null);
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            //thats all you need to make a search  

            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                RecordsListView.ItemsSource = viewModel.Records;
            }

            else
            {
                RecordsListView.ItemsSource = viewModel.Records.Where(x => x.Name.ToUpper().StartsWith(e.NewTextValue.ToUpper()));
            }
        }



    }
}