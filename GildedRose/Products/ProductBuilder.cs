using System.Collections.Generic;
using System.Linq;

namespace csharp.Products
{
    public interface IProductBuilder
    {
        IEnumerable<IProduct> Build(IEnumerable<Item> items);
        IProduct Build(string name, int quality, int daysToSell);
    }

    public class ProductBuilder : IProductBuilder
    {
        public IEnumerable<IProduct> Build(IEnumerable<Item> items)
        {
            return items.Select(i => Build(i.Name, i.Quality, i.SellIn));
        }

        public IProduct Build(string name, int quality, int daysToSell)
        {
            return new Product(new Item
            {
                Name = name,
                Quality = quality,
                SellIn = daysToSell
            });
        }
    }
}