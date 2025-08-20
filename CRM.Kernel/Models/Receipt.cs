using System;
using System.Collections.Generic;

namespace CRM.Kernel.Models
{
    public class Receipt
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public int SellerId { get; set; }

        public virtual Seller Seller { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Sell> Sells { get; set; }

        public decimal Price { get; set; }

        public override string ToString() => $"#{Id} от {CreatedAt.ToString("dd.MM.yy hh:mm:ss")}";
    }
}
