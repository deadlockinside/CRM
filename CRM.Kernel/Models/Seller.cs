using System.Collections.Generic;

namespace CRM.Kernel.Models
{
    public class Seller
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Receipt> Receipts { get; set; }

        public override string ToString() => Name;
    }
}
