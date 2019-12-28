using System.Collections.Generic;
using System.Linq;

namespace TheCheckoutKata
{
    public class Checkout
    {
        private string _scannedItem;
        private readonly IEnumerable<Item> _validItems;

        public Checkout(IEnumerable<Item> validItems)
        {
            _validItems = validItems;
        }

        public void Scan(string item)
        {
            _scannedItem = item;
        }

        public int GetTotalPrice()
        {
            if (string.IsNullOrWhiteSpace(_scannedItem))
            {
                return 0;
            }

            return _validItems.Single(i => i.Sku == _scannedItem).Price;
        }
    }
}
