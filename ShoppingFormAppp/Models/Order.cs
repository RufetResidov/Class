using System;
using System.Collections.Generic;

#nullable disable

namespace ShoppingFormAppp.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? UserId { get; set; }
        public int? Count { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public decimal? TotalPrice { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
