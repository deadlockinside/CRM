using System.Data.Entity;

namespace CRM.Kernel.Models
{
    public class Context : DbContext
    {
        public Context() : base ("CRMConnection") { }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Receipt> Receipts { get; set; }

        public DbSet<Sell> Sells { get; set; }

        public DbSet<Seller> Sellers { get; set; }
    }
}
