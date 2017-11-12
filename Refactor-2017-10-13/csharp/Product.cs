using System;
using csharp.Quality;

namespace csharp
{
    public interface IProduct
    {
        IProduct AdjustedProduct();
        IProduct AdjustedExpiredProduct();

        int Quality();
        string Name();

        bool Common();
        bool Aged();
        bool Legendary();
        bool ConcertTicket();
        int SellIn();
        Item Item();
    }

    public class Product : IProduct
    {
        private readonly Item _item;
        private readonly IQualityStrategy _qualityStrategy;

        public Product(Item item) : this(item, new QualityStrategyFactory()) { }

        public Product(Item item, IQualityStrategyFactory qualityStrategyFactory)
        {
            _item = item;
            _qualityStrategy = qualityStrategyFactory.Strategy(this);
        }

        public IProduct AdjustedProduct()
        {
            return new Product(new Item
            {
                Name = _item.Name,
                Quality = _qualityStrategy.Quality(),
                SellIn = Legendary() ? _item.SellIn : _item.SellIn - 1
            });
        }

        public IProduct AdjustedExpiredProduct()
        {
            throw new NotImplementedException();
        }

        public int Quality()
        {
            return _item.Quality;
        }

        public string Name()
        {
            return _item.Name;
        }

        public int SellIn()
        {
            return _item.SellIn;
        }

        public Item Item()
        {
            return _item;
        }

        public bool Common()
        {
            if (Legendary()) return false;
            if (Aged()) return false;
            return true;
        }

        public bool Legendary()
        {
            if (Name().IndexOf("sulfuras", StringComparison.CurrentCultureIgnoreCase) == -1) return false;
            return true;
        }

        public bool ConcertTicket()
        {
            if (Name().IndexOf("backstage", StringComparison.CurrentCultureIgnoreCase) == -1) return false;
            return true;
        }

        public bool Aged()
        {
            if (Name().IndexOf("aged", StringComparison.CurrentCultureIgnoreCase) == -1) return false;
            return true;
        }
    }
}
