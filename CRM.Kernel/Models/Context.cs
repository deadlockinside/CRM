using System.Data.Entity;

namespace CRM.Kernel.Models
{
    public class Context : DbContext
    {
        public Context() : base ("CRMConnection") 
        {
            // я знаю, что так нельзя. Это временное решение для разработки!
            Database.SetInitializer<Context>(null);
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Receipt> Receipts { get; set; }

        public DbSet<Sell> Sells { get; set; }

        public DbSet<Seller> Sellers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Комментарий в конструкторе выше :)
            Database.SetInitializer<Context>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}
