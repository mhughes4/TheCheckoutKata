using NUnit.Framework;
using System.Collections.Generic;

namespace TheCheckoutKata.Tests
{
    public class CheckoutTests
    {
        [Test]
        public void GetTotalPrice_WithZeroItems_IsZeroByDefault()
        {
            var validItems = new List<Item>
            {
                new Item {Sku = "A", Price = 50},
                new Item {Sku = "B", Price = 30},
                new Item {Sku = "C", Price = 20},
                new Item {Sku = "D", Price = 15}
            };
            var checkout = new Checkout(validItems);
            var result = checkout.GetTotalPrice();
            Assert.That(result, Is.Zero);
        }

        [TestCase("A", 50)]
        [TestCase("B", 30)]
        [TestCase("C", 20)]
        [TestCase("D", 15)]
        public void GetTotalPrice_WithSingleScannedItem_IsPriceOfItem(string scannedItem, int expectedTotal)
        {
            var validItems = new List<Item>
            {
                new Item {Sku = "A", Price = 50},
                new Item {Sku = "B", Price = 30},
                new Item {Sku = "C", Price = 20},
                new Item {Sku = "D", Price = 15}
            };
            var checkout = new Checkout(validItems);
            checkout.Scan(scannedItem);
            var result = checkout.GetTotalPrice();
            Assert.That(result, Is.EqualTo(expectedTotal));
        }
    }
}