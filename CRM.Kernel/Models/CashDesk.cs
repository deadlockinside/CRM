using System;
using System.Collections.Generic;

namespace CRM.Kernel.Models
{
    public class CashDesk
    {
        private Context _db;

        public int Number { get; set; }

        public Seller Seller { get; set; }

        public Queue<Cart> Queue { get; set; }

        public int MaxQueueLength { get; set; }

        public int ExitCustomer { get; set; }

        public bool IsModel { get; set; }

        public CashDesk(int number, Seller seller)
        {
            Number = number;
            Seller = seller;
            Queue = new Queue<Cart>();
            IsModel = true;
            _db = new Context();
        }

        public void Enqueue(Cart cart) 
        { 
            if (Queue.Count <= MaxQueueLength) 
            {
                Queue.Enqueue(cart);
            }
            else 
            {
                ExitCustomer++;
            }
        }

        public decimal Dequeue() 
        {
            decimal sum = 0;
            var cart = Queue.Dequeue();

            if (cart != null) 
            {
                var receipt = new Receipt
                {
                    SellerId = Seller.Id,
                    Seller = Seller,
                    CustomerId = cart.Customer.Id,
                    Customer = cart.Customer,
                    CreatedAt = DateTime.Now
                };

                if (!IsModel) 
                { 
                    _db.Receipts.Add(receipt);
                    _db.SaveChanges();
                }
                else 
                {
                    receipt.Id = 0;
                }

                var sells = new List<Sell>();

                foreach(Product product in cart) 
                {
                    if (product.Count > 0)
                    {
                        var sell = new Sell
                        {
                            ReceiptId = receipt.Id,
                            Receipt = receipt,
                            ProductId = product.Id,
                            Product = product
                        };

                        sells.Add(sell);

                        if (!IsModel)
                            _db.Sells.Add(sell);

                        product.Count--;
                        sum += product.Price;
                    }
                }

                if (!IsModel)
                    _db.SaveChanges();
            }

            return sum;
        }
    }
}
