using System.Collections.Generic;

namespace CRM.Kernel.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Count { get; set; }

        public virtual ICollection<Sell> Sells { get; set; }

        public override string ToString() => Name;
    }
}
