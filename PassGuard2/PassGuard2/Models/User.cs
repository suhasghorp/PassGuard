using System;
using System.Collections.Generic;
using System.Text;
using Realms;

namespace PassGuard2.Models
{
    public class User : RealmObject
    {
        [PrimaryKey]
        public string UserID { get; set; } = Guid.NewGuid().ToString();
        public string Username { get; set; }
        public string Password { get; set; }

        public User() { }

        public User(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }

        public bool CheckInformation()
        {
            if (!string.IsNullOrEmpty(this.Username) && !string.IsNullOrEmpty(this.Password))
            {
                return true;
            }
            return false;
        }
    }
}
