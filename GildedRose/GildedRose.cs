using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        private readonly IList<Item> _items;
        private readonly IProductBuilder _productBuilder;

        public GildedRose(IList<Item> items) : this(items, new ProductBuilder()) { }

        public GildedRose(IList<Item> items, IProductBuilder productBuilder)
        {
            _items = items;
            _productBuilder = productBuilder;
        }

        public IEnumerable<Item> UpdateQuality()
        {
            foreach (Item item in _items)
            {
                IProduct product = _productBuilder.Build(item.Name, item.Quality, item.SellIn)
                    .WithAdjustedQuality()
                    .WithReducedSellIn()
                    .WithExpirationAdjustment();

                yield return product.Item();
            }
        }
    }
}
