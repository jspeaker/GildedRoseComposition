using System.Collections.Generic;
using System.Linq;

namespace csharp.Products
{
    public interface IProductLife
    {
        IEnumerable<IProduct> WithIncreasedAge(IEnumerable<IProduct> products);
    }

    public class ProductLife : IProductLife
    {
        public IEnumerable<IProduct> WithIncreasedAge(IEnumerable<IProduct> products)
        {
            return products.Select(product => product
                .WithAdjustedQuality()
                .WithReducedSellIn()
                .WithExpirationAdjustment());
        }
    }
}
