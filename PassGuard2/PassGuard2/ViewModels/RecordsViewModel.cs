using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using PassGuard2.Models;
using PassGuard2.Views;
using PassGuard2.Services;

namespace PassGuard2.ViewModels
{
    public class RecordsViewModel : BaseViewModel
    {
        public ObservableCollection<Record> Records { get; set; }
        public Command LoadRecordsCommand { get; set; }

        public RecordsViewModel()
        {
            Title = "Records";
            Records = new ObservableCollection<Record>();
            LoadRecordsCommand = new Command(async () => await ExecuteLoadRecordsCommand());
            

            MessagingCenter.Subscribe<NewRecordPage, Record>(this, "AddRecord", async (obj, record) =>
            {
                var newRecord = record as Record;
                Records.Add(newRecord);
                //await DataStore.AddRecordAsync(newRecord);
                await new RealmDBService().AddRecordAsync(newRecord);
            });

            MessagingCenter.Subscribe<RecordDetailPage, Record>(this, "DeleteRecord", async (obj, record) =>
            {
                var delRecord = record as Record;
                Records.Remove(delRecord);
                //await DataStore.AddRecordAsync(newRecord);
                await new RealmDBService().DeleteRecordAsync(delRecord.Id);
            });

        }

        async Task ExecuteLoadRecordsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Records.Clear();
                var records = await new RealmDBService().GetRecordsAsync(true);
                foreach (var record in records)
                {
                    Records.Add(record);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}