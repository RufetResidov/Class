using System;
using System.Collections.Generic;

#nullable disable

namespace ShoppingFormAppp.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Fullname { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
