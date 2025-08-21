using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CRM.Kernel.Models
{
    public class ShopComputerModel
    {
        Generator Generator = new Generator();
        Random Random = new Random();
        bool isWorking = false;

        public List<CashDesk> CashDesks { get; set; } = new List<CashDesk>();
        public List<Cart> Carts { get; set; } = new List<Cart>();
        public List<Receipt> Receipts { get; set; } = new List<Receipt>();
        public List<Sell> Sells { get; set; } = new List<Sell>();
        public Queue<Seller> Sellers { get; set; } = new Queue<Seller>();

        public int CustomerSpeed { get; set; } = 100;
        public int CashDeskSpeed { get; set; } = 100;

        public ShopComputerModel()
        {
            var sellers = Generator.GetNewSellers(20);
            Generator.GetNewProducts(1000);
            Generator.GetNewCustomers(100);

            foreach (var seller in sellers)
                Sellers.Enqueue(seller);

            for (int i = 0; i < 3; i++)
                CashDesks.Add(new CashDesk(CashDesks.Count, Sellers.Dequeue()));
        }

        public void Start()
        {
            isWorking = true;
            Task.Run(() => CreateCarts(10, CustomerSpeed));

            var cashdeskTasks = CashDesks.Select(c => new Task(() => CashDesksWork(c, CashDeskSpeed)));

            foreach (var task in cashdeskTasks)
                task.Start();
        }

        public void Stop() => isWorking = false;

        private void CashDesksWork(CashDesk cashDesk, int sleep) 
        {
            while (isWorking)
            {
                if (CashDesks.Count > 0)
                    cashDesk.Dequeue();

                Thread.Sleep(sleep);
            }
        }

        private void CreateCarts(int customersCount, int sleep) 
        {
            while (isWorking)
            {
                var customers = Generator.GetNewCustomers(customersCount);

                foreach (var customer in customers)
                {
                    var cart = new Cart(customer);

                    foreach (var product in Generator.GetRandomProducts(10, 30))
                        cart.Add(product);

                    var cash = CashDesks[Random.Next(CashDesks.Count)];
                    cash.Enqueue(cart);
                }

                Thread.Sleep(sleep);
            }
        }
    }
}
