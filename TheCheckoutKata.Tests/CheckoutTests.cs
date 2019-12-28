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
    }
}