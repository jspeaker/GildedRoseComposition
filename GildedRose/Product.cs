using System;
using csharp.ExpiredProductStrategies;

namespace csharp
{
    public class Product : IProduct
    {
        private readonly Item _item;
        private readonly IExpiredProductStrategy _expiredProductStrategyChain;

        public Product(Item item) : this(item, new NullExpiredProductStrategy()) { }

        public Product(Item item, IExpiredProductStrategy expiredProductStrategyChain)
        {
            _item = item;
            _expiredProductStrategyChain = expiredProductStrategyChain;
        }

        public IProduct WithReducedQuality()
        {
            if (_item.Quality < 1) return this;

            if (Conjured())
            {
                return new Product(new Item
                {
                    Name = _item.Name,
                    Quality = _item.Quality - 2,
                    SellIn = _item.SellIn
                });
            }

            if (!Common()) return this;

            return new Product(new Item
            {
                Name = _item.Name,
                Quality = _item.Quality - 1,
                SellIn = _item.SellIn
            });
        }

        public IProduct WithIncreasedQuality()
        {
            if (Common() && Quality() > 0) return this;
            if (Quality() >= 50) return this;
            if (Conjured()) return this;

            return new Product(new Item
            {
                Name = _item.Name,
                Quality = _item.Quality + 1,
                SellIn = _item.SellIn
            });
        }

        public IProduct EventTicketWithIncreasedQuality()
        {
            if (!EventTicket()) return this;
            if (_item.Quality > 49) return this;
            if (_item.SellIn > 10) return this;

            return WithEventLooming(WithEventLooming(this, 10), 5);
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

        public IProduct Expired()
        {
            return _expiredProductStrategyChain.Expired(this);
        }

        private IProduct WithEventLooming(IProduct product, int daysInAdvance)
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
            return !Legendary() && !AgedItem() && !EventTicket() && !Conjured();
        }

        public bool Legendary()
        {
            return _item.Name.IndexOf("ragnaros", StringComparison.CurrentCultureIgnoreCase) > -1;
        }

        public bool Conjured()
        {
            return _item.Name.IndexOf("conjured", StringComparison.CurrentCultureIgnoreCase) > -1;
        }

        public bool AgedItem()
        {
            return _item.Name.IndexOf("aged", StringComparison.CurrentCultureIgnoreCase) > -1;
        }

        public bool EventTicket()
        {
            return _item.Name.IndexOf("backstage", StringComparison.CurrentCultureIgnoreCase) > -1;
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
        bool EventTicket();
        bool AgedItem();
        bool Legendary();
        bool Conjured();

        int Quality();

        IProduct WithReducedQuality();
        IProduct WithIncreasedQuality();
        IProduct EventTicketWithIncreasedQuality();
        IProduct WithReducedSellIn();
        IProduct Expired();
    }
}