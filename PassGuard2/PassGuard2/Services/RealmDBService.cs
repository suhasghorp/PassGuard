using PassGuard2.Models;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassGuard2.Services
{
    public class RealmDBService : IDataStore<Record>
    {
        protected Realm RealmInstance;

         
        public RealmDBService()
        {
            RealmInstance = Realm.GetInstance();
        }

        public bool SaveUser(string Username, string Password)
        {
            try
            {
                RealmInstance.Write(() =>
                {
                    RealmInstance.Add(new User { Username = Username, Password = Password });
                });
                return true;
            }catch
            {
                return false;
            }

        }

        public bool DeleteUsersAndRecords()
        {
            try
            {
                RealmInstance.Write(() =>
                {
                    RealmInstance.RemoveAll<User>();
                    RealmInstance.RemoveAll<Record>();
                });
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int GetNumberOfUsers()
        {
            return RealmInstance.All<User>().Count();
        }

        public User GetUser(string Username, string Password)
        {
            return RealmInstance.All<User>().Where(d => d.Username == Username && d.Password == Password).FirstOrDefault();

        }

        public async Task<bool> AddRecordAsync(Record record)
        {

            var records = RealmInstance.All<Record>().ToList();
            var maxRecordId = 0;
            if (records.Count != 0)
            {
                maxRecordId = records.Max(s => s.Id);
            }
            record.Id = maxRecordId + 1;

            RealmInstance.Write(() =>
            {
                RealmInstance.Add(record);
            });


            records.Add(record);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateRecordAsync(Record record)
        {
            var records = RealmInstance.All<Record>().ToList();
            var oldRecord = records.Where((Record arg) => arg.Id == record.Id).FirstOrDefault();
            RealmInstance.Write(() =>
            {
                RealmInstance.Remove(oldRecord);
            });
            RealmInstance.Write(() =>
            {
                RealmInstance.Add(record);
            });

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteRecordAsync(int id)
        {
            var records = RealmInstance.All<Record>().ToList();
            var oldRecord = records.Where((Record arg) => arg.Id == id).FirstOrDefault();
            RealmInstance.Write(() =>
            {
                RealmInstance.Remove(oldRecord);
            });

            return await Task.FromResult(true);
        }

        public async Task<Record> GetRecordAsync(int id)
        {
            var records = RealmInstance.All<Record>().ToList();
            return await Task.FromResult(records.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Record>> GetRecordsAsync(bool forceRefresh = false)
        {
            var records = RealmInstance.All<Record>().ToList();
            return await Task.FromResult(records);
        }
    }
}
