namespace CRM.Kernel.Models
{
    public class Sell
    {
        public int Id { get; set; }

        public int ReceiptId { get; set; }

        public int ProductId { get; set; }

        public virtual Receipt Receipt { get; set; }

        public virtual Product Product { get; set; }
    }
}
