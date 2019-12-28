using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

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
            var item = validItems.Single(vi => vi.Sku == scannedItem);
            checkout.Scan(item);
            var result = checkout.GetTotalPrice();
            Assert.That(result, Is.EqualTo(expectedTotal));
        }

        [Test]
        public void GetTotalPrice_WithScannedItemsOfSameType_IsTotalOfItems()
        {
            var validItems = new List<Item>
            {
                new Item {Sku = "A", Price = 50},
                new Item {Sku = "B", Price = 30},
                new Item {Sku = "C", Price = 20},
                new Item {Sku = "D", Price = 15}
            };
            var checkout = new Checkout(validItems);
            checkout.Scan(new Item { Sku = "A", Price = 50 });
            checkout.Scan(new Item { Sku = "A", Price = 50 });
            var result = checkout.GetTotalPrice();
            Assert.That(result, Is.EqualTo(100));
        }

        [Test]
        public void GetTotalPrice_WithScannedItemsOfDifferentTypes_IsTotalOfItems()
        {
            var validItems = new List<Item>
            {
                new Item {Sku = "A", Price = 50},
                new Item {Sku = "B", Price = 30},
                new Item {Sku = "C", Price = 20},
                new Item {Sku = "D", Price = 15}
            };
            var checkout = new Checkout(validItems);
            checkout.Scan(new Item { Sku = "A", Price = 50 });
            checkout.Scan(new Item { Sku = "B", Price = 30 });
            var result = checkout.GetTotalPrice();
            Assert.That(result, Is.EqualTo(80));
        }

        [Test]
        public void GetTotalPrice_WithInvalidItem_DoesNotAffectTotal()
        {
            var validItems = new List<Item>
            {
                new Item {Sku = "A", Price = 50},
                new Item {Sku = "B", Price = 30},
                new Item {Sku = "C", Price = 20},
                new Item {Sku = "D", Price = 15}
            };
            var checkout = new Checkout(validItems);
            checkout.Scan(new Item { Sku = "A", Price = 50 });
            checkout.Scan(new Item { Sku = "E", Price = 30 });
            var result = checkout.GetTotalPrice();
            Assert.That(result, Is.EqualTo(50));
        }
    }
}