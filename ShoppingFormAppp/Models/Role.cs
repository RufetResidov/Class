using System;
using System.Collections.Generic;

#nullable disable

namespace ShoppingFormAppp.Models
{
    public partial class Role
    {
        public Role()
        {
            UserToRoles = new HashSet<UserToRole>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserToRole> UserToRoles { get; set; }
    }
}
