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
        List<Task> tasks = new List<Task>();

        CancellationTokenSource cancellationTokenSource;
        CancellationToken cancellationToken;

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

            cancellationTokenSource = new CancellationTokenSource();
            cancellationToken = cancellationTokenSource.Token;

            foreach (var seller in sellers)
                Sellers.Enqueue(seller);

            for (int i = 0; i < 3; i++)
                CashDesks.Add(new CashDesk(CashDesks.Count, Sellers.Dequeue(), null));
        }

        public void Start()
        {
            isWorking = true;

            tasks.Add(new Task(() => CreateCarts(10, cancellationToken)));

            tasks.AddRange(CashDesks.Select(c => new Task(() => CashDesksWork(c, cancellationToken))));

            foreach (var task in tasks)
                task.Start();
        }

        public void Stop()
        {
            cancellationTokenSource.Cancel();
        }

        private void CashDesksWork(CashDesk cashDesk, CancellationToken cancellationToken) 
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                if (CashDesks.Count > 0)
                    cashDesk.Dequeue();

                Thread.Sleep(CashDeskSpeed);
            }
        }

        private void CreateCarts(int customersCount, CancellationToken cancellationToken) 
        {
            while (!cancellationToken.IsCancellationRequested)
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

                Thread.Sleep(CustomerSpeed);
            }
        }
    }
}
