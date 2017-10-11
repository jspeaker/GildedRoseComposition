namespace csharp
{
    public class Product : IProduct
    {
        private readonly Item _item;

        public Product(Item item)
        {
            _item = item;
        }

        public IProduct ReducedQualityProduct()
        {
            if (_item.Quality < 1) return this;
            if (!Common()) return this;

            return new Product(new Item
            {
                Name = _item.Name,
                Quality = _item.Quality - 1,
                SellIn = _item.SellIn
            });
        }

        public IProduct IncreasedQualityProduct()
        {
            if (Common() && Quality() > 0) return this;
            if (Quality() >= 50) return this;

            return new Product(new Item
            {
                Name = _item.Name,
                Quality = _item.Quality + 1,
                SellIn = _item.SellIn
            });
        }

        public IProduct IncreasedQualityBackstagePass()
        {
            if (!BackstagePass()) return this;
            if (_item.Quality > 49) return this;
            if (_item.SellIn > 10) return this;

            IProduct advanceBackstagePass = AdvanceBackstagePass(this, 10);
            advanceBackstagePass = AdvanceBackstagePass(advanceBackstagePass, 5);

            return advanceBackstagePass;
        }

        private IProduct AdvanceBackstagePass(IProduct product, int daysInAdvance)
        {
            if (product.Item().SellIn > daysInAdvance) return product;
            if (product.Item().Quality > 49) return product;

            return new Product(new Item
            {
                Name = product.Item().Name,
                Quality = product.Item().Quality + 1,
                SellIn = product.Item().SellIn
            });
        }

        public Item Item()
        {
            return _item;
        }

        public bool Common()
        {
            return !Legendary() && !Cheese() && !BackstagePass();
        }

        public bool Legendary()
        {
            return _item.Name.Equals("Sulfuras, Hand of Ragnaros");
        }

        public bool Cheese()
        {
            return _item.Name.Equals("Aged Brie");
        }

        public bool BackstagePass()
        {
            return _item.Name.Contains("Backstage");
        }

        public int Quality()
        {
            return _item.Quality;
        }
    }

    public interface IProduct
    {
        Item Item();

        bool Common();
        bool BackstagePass();
        bool Cheese();
        bool Legendary();
        int Quality();

        IProduct ReducedQualityProduct();
        IProduct IncreasedQualityProduct();
        IProduct IncreasedQualityBackstagePass();
    }
}