namespace TheCheckoutKata
{
    public class Checkout
    {
        private string _scannedItem;

        public Checkout()
        {
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

            if(_scannedItem == "B")
            {
                return 30;
            }

            return 50;
        }
    }
}
