using System.Collections.Generic;

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
            foreach (IProduct product in products)
            {
                yield return product
                    .WithAdjustedQuality()
                    .WithReducedSellIn()
                    .WithExpirationAdjustment();
            }
        }
    }
}
