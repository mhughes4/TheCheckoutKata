namespace TheCheckoutKata
{
    public abstract class Item
    {
        public abstract int Price { get; }
        protected abstract string Sku { get; }

        public override bool Equals(object obj)
        {
            return obj is Item item &&
                   Sku == item.Sku &&
                   Price == item.Price;
        }
    }

    public class ItemA : Item
    {
        public override int Price => 50;
        protected override string Sku => "A";
    }

    public class ItemB : Item
    {
        public override int Price => 30;
        protected override string Sku => "B";
    }

    public class ItemC : Item
    {
        public override int Price => 20;
        protected override string Sku => "C";
    }

    public class ItemD : Item
    {
        public override int Price => 15;
        protected override string Sku => "D";
    }

    public class ItemE : Item
    {
        public override int Price => 50;
        protected override string Sku => "E";
    }
}