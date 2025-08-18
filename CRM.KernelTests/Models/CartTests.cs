using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CRM.Kernel.Models.Tests
{
    [TestClass()]
    public class CartTests
    {
        [TestMethod()]
        public void CartTest()
        {
            // arrange
            var customer = new Customer 
            {
                Id = 1,
                Name = "test user"
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

            var cart = new Cart(customer);

            var expectedResult = new List<Product>() 
            {
                product1, product1, product2
            };

            // act
            cart.Add(product1);
            cart.Add(product1);
            cart.Add(product2);

            var cartresult = cart.GetAll();

            // assert
            Assert.AreEqual(expectedResult.Count, cartresult.Count);

            for (int i = 0; i < expectedResult.Count; i++)
                Assert.AreEqual(expectedResult[i], cartresult[i]);
        }
    }
}