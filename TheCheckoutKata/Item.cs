namespace TheCheckoutKata
{
    public class Item
    {
        public string Sku { get; set; }
        public int Price { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Item item &&
                   Sku == item.Sku &&
                   Price == item.Price;
        }
    }
}