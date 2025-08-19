using System;
using System.Collections.Generic;

namespace CRM.Kernel.Models
{
    public class Generator
    {
        private Random _random = new Random();

        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Seller> Sellers { get; set; } = new List<Seller>();

        public List<Customer> GetNewCustomers(int count)
        {
            var result = new List<Customer>();

            for (int i = 0; i < count; i++)
            {
                var customer = new Customer
                {
                    Id = Customers.Count,
                    Name = GetRandomText()
                };

                Customers.Add(customer);
                result.Add(customer);
            }

            return result;
        }

        public List<Seller> GetNewSellers(int count)
        {
            var result = new List<Seller>();

            for (int i = 0; i < count; i++)
            {
                var seller = new Seller
                {
                    Id = Sellers.Count,
                    Name = GetRandomText()
                };

                Sellers.Add(seller);
                result.Add(seller);
            }

            return result;
        }

        public List<Product> GetNewProducts(int count) 
        {
            var result = new List<Product>();

            for (int i = 0; i < count; i++) 
            {
                var product = new Product 
                { 
                    Id = Products.Count,
                    Name = GetRandomText(),
                    Count = _random.Next(10, 1000),
                    Price = Convert.ToDecimal(_random.Next(5, 1000) + _random.NextDouble()),
                };

                Products.Add(product);
                result.Add(product);
            }

            return result;
        }

        public List<Product> GetRandomProducts(int min, int max) 
        {
            var result = new List<Product>();
            var count = _random.Next(min, max);

            for (int i = 0; i < count; i++) 
            {
                result.Add(Products[_random.Next(Products.Count - 1)]);
            }

            return result;
        }

        private string GetRandomText() => Guid.NewGuid().ToString().Substring(0, 5);
    }
}
