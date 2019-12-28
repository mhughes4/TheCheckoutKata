using NUnit.Framework;
using System.Collections.Generic;

namespace TheCheckoutKata.Tests
{
    public class CheckoutTests
    {
        private readonly Item _itemA = new ItemA();
        private readonly Item _itemB = new ItemB();
        private readonly Item _itemC = new ItemC();
        private readonly Item _itemD = new ItemD();
        private readonly Item _itemE = new ItemE();

        [Test]
        public void GetTotalPrice_WithZeroItems_IsZeroByDefault()
        {
            var validItems = new List<Item>
            {
                _itemA,
                _itemB,
                _itemC,
                _itemD
            };
            var checkout = new Checkout(validItems);
            var result = checkout.GetTotalPrice();
            Assert.That(result, Is.Zero);
        }

        [Test]
        public void GetTotalPrice_WithSingleScannedItem_IsPriceOfItem()
        {
            var validItems = new List<Item>
            {
                _itemA,
                _itemB,
                _itemC,
                _itemD
            };
            var itemsToScan = new List<Item>
            {
                _itemA,
                _itemB,
                _itemC,
                _itemD
            };
            foreach(var item in itemsToScan)
            {
                var checkout = new Checkout(validItems);
                checkout.Scan(item);
                Assert.That(checkout.GetTotalPrice(), Is.EqualTo(item.Price));
            }
        }

        [Test]
        public void GetTotalPrice_WithScannedItemsOfSameType_IsTotalOfItems()
        {
            var validItems = new List<Item>
            {
                _itemA,
                _itemB,
                _itemC,
                _itemD
            };
            var checkout = new Checkout(validItems);
            checkout.Scan(_itemA);
            checkout.Scan(_itemA);
            var result = checkout.GetTotalPrice();
            Assert.That(result, Is.EqualTo(100));
        }

        [Test]
        public void GetTotalPrice_WithScannedItemsOfDifferentTypes_IsTotalOfItems()
        {
            var validItems = new List<Item>
            {
                _itemA,
                _itemB,
                _itemC,
                _itemD
            };
            var checkout = new Checkout(validItems);
            checkout.Scan(_itemA);
            checkout.Scan(_itemB);
            var result = checkout.GetTotalPrice();
            Assert.That(result, Is.EqualTo(80));
        }

        [Test]
        public void GetTotalPrice_WithInvalidItem_DoesNotAffectTotal()
        {
            var validItems = new List<Item>
            {
                _itemA,
                _itemB,
                _itemC,
                _itemD
            };
            var checkout = new Checkout(validItems);
            checkout.Scan(_itemA);
            checkout.Scan(_itemE);
            var result = checkout.GetTotalPrice();
            Assert.That(result, Is.EqualTo(_itemA.Price));
        }
    }
}