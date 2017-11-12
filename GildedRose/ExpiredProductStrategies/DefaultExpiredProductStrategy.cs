namespace csharp.ExpiredProductStrategies
{
    public class DefaultExpiredProductStrategy : IExpiredProductStrategy
    {
        public IProduct Expired(IProduct product)
        {
            if (product.Item().SellIn > -1) return product;

            return new Product(new Item
            {
                Name = product.Item().Name,
                Quality = product.Quality() - 1,
                SellIn = product.Item().SellIn
            });
        }
    }
}