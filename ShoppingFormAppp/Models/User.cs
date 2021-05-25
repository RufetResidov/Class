using System;
using System.Collections.Generic;

#nullable disable

namespace ShoppingFormAppp.Models
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
            UserToRoles = new HashSet<UserToRole>();
        }

        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<UserToRole> UserToRoles { get; set; }
    }
}
