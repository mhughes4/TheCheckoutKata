using System.Collections.Generic;
using System.Linq;

namespace TheCheckoutKata
{
    public class Checkout
    {
        private readonly IList<Item> _scannedItems = new List<Item>();
        private readonly IEnumerable<Item> _validItems;

        public Checkout(IEnumerable<Item> validItems)
        {
            _validItems = validItems;
        }

        public void Scan(Item item)
        {
            _scannedItems.Add(item);
        }

        public int GetTotalPrice()
        {
            return _scannedItems.Sum(GetPriceOfValidItem);
        }

        private int GetPriceOfValidItem(Item scannedItem)
        {
            var scannedItemIsValid = _validItems.Any(vi => vi.Equals(scannedItem));
            return scannedItemIsValid ? scannedItem.Price : 0;
        }
    }
}
