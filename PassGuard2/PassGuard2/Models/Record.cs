using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace PassGuard2.Models
{
    public class Record : RealmObject
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Notes { get; set; }

    }
}
