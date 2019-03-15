using System;
using System.Collections.Generic;
using System.Text;

namespace PassGuard2.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Logout
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
