using NUnit.Framework;

namespace TheCheckoutKata.Tests
{
    public class CheckoutTests
    {
        [Test]
        public void GetTotalPrice_WithZeroItems_IsZeroByDefault()
        {
            var checkout = new Checkout();
            var result = checkout.GetTotalPrice();
            Assert.That(result, Is.Zero);
        }

        [Test]
        public void GetTotalPrice_WithItemAScanned_IsPriceOfItemA()
        {
            var checkout = new Checkout();
            checkout.Scan("A");
            var result = checkout.GetTotalPrice();
            Assert.That(result, Is.EqualTo(50));
        }

        [Test]
        public void GetTotalPrice_WithItemBScanned_IsPriceOfItemB()
        {
            var checkout = new Checkout();
            checkout.Scan("B");
            var result = checkout.GetTotalPrice();
            Assert.That(result, Is.EqualTo(30));
        }
    }
}