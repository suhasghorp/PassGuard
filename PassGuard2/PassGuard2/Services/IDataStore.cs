using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PassGuard2.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddRecordAsync(T record);
        Task<bool> UpdateRecordAsync(T record);
        Task<bool> DeleteRecordAsync(int id);
        Task<T> GetRecordAsync(int id);
        Task<IEnumerable<T>> GetRecordsAsync(bool forceRefresh = false);
    }
}
