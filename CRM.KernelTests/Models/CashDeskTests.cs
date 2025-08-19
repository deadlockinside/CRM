using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CRM.Kernel.Models.Tests
{
    [TestClass()]
    public class CashDeskTests
    {
        [TestMethod()]
        public void CashDeskTest()
        {
            // arrange
            var customer1 = new Customer 
            {
                Id = 1,
                Name = "test user 1",
            };

            var customer2 = new Customer
            {
                Id = 2,
                Name = "test user 2",
            };

            var seller = new Seller 
            {
                Id = 1,
                Name = "test seller",
            };

            var product1 = new Product
            {
                Id = 1,
                Name = "pr1",
                Price = 100,
                Count = 10
            };

            var product2 = new Product
            {
                Id = 2,
                Name = "pr2",
                Price = 200,
                Count = 20
            };

            var cart1 = new Cart(customer1);
            var cart2 = new Cart(customer2);
            var cashdesk = new CashDesk(1, seller);
            cashdesk.MaxQueueLength = 10;

            cart1.Add(product1);
            cart1.Add(product1);
            cart1.Add(product2);

            cart2.Add(product1);
            cart2.Add(product2);
            cart2.Add(product2);

            cashdesk.Enqueue(cart1);
            cashdesk.Enqueue(cart2);

            var cart1ExpectedResult = 400;
            var cart2ExpectedResult = 500;

            // act
            var cart1ActualResult = cashdesk.Dequeue();
            var cart2ActualResult = cashdesk.Dequeue();

            // assert
            Assert.AreEqual(cart1ExpectedResult, cart1ActualResult);
            Assert.AreEqual(cart2ExpectedResult, cart2ActualResult);
            Assert.AreEqual(7, product1.Count);
            Assert.AreEqual(17, product2.Count);
        }
    }
}