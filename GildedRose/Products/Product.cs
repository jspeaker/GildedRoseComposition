using System;
using csharp.ExpiredProductStrategies;
using csharp.QualityAdjustmentStrategies;

namespace csharp.Products
{
    public class Product : IProduct
    {
        private readonly Item _item;
        private readonly IExpiredProductStrategy _expiredProductStrategyChain;
        private readonly IQualityAdjustmentStrategy _qualityAdjustmentStrategyChain;

        public Product(Item item) : this(item, new NullExpiredProductStrategy(), new NullQualityAdjustmentStrategy()) { }

        public Product(Item item, IExpiredProductStrategy expiredProductStrategyChain, IQualityAdjustmentStrategy qualityAdjustmentStrategyChain)
        {
            _item = item;
            _expiredProductStrategyChain = expiredProductStrategyChain;
            _qualityAdjustmentStrategyChain = qualityAdjustmentStrategyChain;
        }

        public IProduct WithAdjustedQuality()
        {
            return _qualityAdjustmentStrategyChain.Adjust(this);
        }

        public IProduct WithReducedSellIn()
        {
            if (Legendary()) return this;

            return new Product(new Item
            {
                Name = _item.Name,
                Quality = _item.Quality,
                SellIn = _item.SellIn - 1
            });
        }

        public IProduct WithExpirationAdjustment()
        {
            return _expiredProductStrategyChain.Expired(this);
        }

        public Item Item()
        {
            return _item;
        }

        public bool Common()
        {
            return !Legendary() && !Aged() && !Ticket() && !Conjured();
        }

        public bool Legendary()
        {
            return _item.Name.IndexOf("ragnaros", StringComparison.CurrentCultureIgnoreCase) > -1;
        }

        public bool Conjured()
        {
            return _item.Name.IndexOf("conjured", StringComparison.CurrentCultureIgnoreCase) > -1;
        }

        public bool Aged()
        {
            return _item.Name.IndexOf("aged", StringComparison.CurrentCultureIgnoreCase) > -1;
        }

        public bool Ticket()
        {
            return _item.Name.IndexOf("backstage", StringComparison.CurrentCultureIgnoreCase) > -1;
        }

        public int Quality()
        {
            return _item.Quality;
        }

        public string Name()
        {
            return _item.Name;
        }

        public int DaysToSell()
        {
            return _item.SellIn;
        }
    }

    public interface IProduct
    {
        Item Item();

        bool Common();
        bool Ticket();
        bool Aged();
        bool Legendary();
        bool Conjured();

        string Name();
        int Quality();
        int DaysToSell();

        IProduct WithAdjustedQuality();
        IProduct WithReducedSellIn();
        IProduct WithExpirationAdjustment();
    }
}