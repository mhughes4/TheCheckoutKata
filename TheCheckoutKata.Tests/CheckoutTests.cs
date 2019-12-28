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
                new Item {Sku = "A", Price = 50}
            };
            var checkout = new Checkout(validItems);
            var result = checkout.GetTotalPrice();
            Assert.That(result, Is.Zero);
        }

        [Test]
        public void GetTotalPrice_WithItemAScanned_IsPriceOfItemA()
        {
            var validItems = new List<Item>
            {
                new Item {Sku = "A", Price = 50}
            };
            var checkout = new Checkout(validItems);
            checkout.Scan("A");
            var result = checkout.GetTotalPrice();
            Assert.That(result, Is.EqualTo(50));
        }

        [Test]
        public void GetTotalPrice_WithItemBScanned_IsPriceOfItemB()
        {
            var validItems = new List<Item>
            {
                new Item {Sku = "B", Price = 30}
            };
            var checkout = new Checkout(validItems);
            checkout.Scan("B");
            var result = checkout.GetTotalPrice();
            Assert.That(result, Is.EqualTo(30));
        }
    }
}