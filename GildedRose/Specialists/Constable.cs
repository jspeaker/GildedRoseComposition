using csharp.Products;

namespace csharp.Specialists
{
    public interface IConstable
    {
        IProduct EnforceMaximumQuality(IProduct product);
    }

    public class Constable : IConstable
    {
        public IProduct EnforceMaximumQuality(IProduct product)
        {
            if (product.Quality() <= 50) return product;

            return new Product(new Item
            {
                Name = product.Name(),
                Quality = 50,
                SellIn = product.DaysToSell()
            });
        }
    }
}