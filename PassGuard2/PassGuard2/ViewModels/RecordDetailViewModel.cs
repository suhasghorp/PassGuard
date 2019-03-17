using System;

using PassGuard2.Models;

namespace PassGuard2.ViewModels
{
    public class RecordDetailViewModel : BaseViewModel
    {
        public Record Record { get; set; }
        public RecordDetailViewModel(Record record = null)
        {
            Title = record?.Name;
            Record = record;
        }
    }
}