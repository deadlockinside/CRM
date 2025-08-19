using System;
using System.Collections.Generic;
using System.Linq;

namespace CRM.Kernel.Models
{
    public class ShopComputerModel
    {
        Generator Generator = new Generator();
        Random Random = new Random();

        public List<CashDesk> CashDesks { get; set; } = new List<CashDesk>();
        public List<Cart> Carts { get; set; } = new List<Cart>();
        public List<Receipt> Receipts { get; set; } = new List<Receipt>();
        public List<Sell> Sells { get; set; } = new List<Sell>();
        public Queue<Seller> Sellers { get; set; } = new Queue<Seller>();

        public ShopComputerModel()
        {
            var sellers = Generator.GetNewSellers(20);
            Generator.GetNewProducts(1000);
            Generator.GetNewCustomers(100);

            foreach (var seller in sellers) 
            {
                Sellers.Enqueue(seller);
            }

            for (int i = 0; i < 3; i++) 
            {
                CashDesks.Add(new CashDesk(CashDesks.Count, Sellers.Dequeue()));
            }
        }

        public void Start()
        {
            var customers = Generator.GetNewCustomers(10);
            var carts = new Queue<Cart>();

            foreach (var customer in customers) 
            {
                var cart = new Cart(customer);

                foreach(var product in Generator.GetRandomProducts(10, 30)) 
                {
                    cart.Add(product);
                }

                carts.Enqueue(cart);
            }

            while (carts.Count > 0)
            {
                var cash = CashDesks[Random.Next(CashDesks.Count - 1)];
                cash.Enqueue(carts.Dequeue());
            }

            while (true) 
            {
                var cash = CashDesks[Random.Next(CashDesks.Count - 1)];
                var money = cash.Dequeue();
            }
        }
    }
}
