using System.Collections.Generic;
using System.Linq;

namespace TheCheckoutKata
{
    public class Checkout
    {
        private readonly IList<string> _scannedItems = new List<string>();
        private readonly IEnumerable<Item> _validItems;

        public Checkout(IEnumerable<Item> validItems)
        {
            _validItems = validItems;
        }

        public void Scan(string item)
        {
            _scannedItems.Add(item);
        }

        public int GetTotalPrice()
        {
            var total = 0;

            foreach(var item in _scannedItems)
            {
                if(_validItems.Any(vi => vi.Sku == item))
                {
                    total += _validItems.Single(vi => vi.Sku == item).Price;
                }
            }

            return total;
        }
    }
}
