using PassGuard2.Models;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PassGuard2.Services
{
    public class RealmDBService
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

        public int GetNumberOfUsers()
        {
            return RealmInstance.All<User>().Count();
        }

        public User GetUser(string Username, string Password)
        {
            return RealmInstance.All<User>().Where(d => d.Username == Username && d.Password == Password).FirstOrDefault();


        }
    }
}
