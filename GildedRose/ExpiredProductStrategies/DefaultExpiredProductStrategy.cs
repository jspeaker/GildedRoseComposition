namespace csharp.ExpiredProductStrategies
{
    public class DefaultExpiredProductStrategy : IExpiredProductStrategy
    {
        public IProduct Expired(IProduct product)
        {
            return new Product(new Item
            {
                Name = product.Item().Name,
                Quality = product.Quality() - 1,
                SellIn = product.Item().SellIn
            });
        }
    }
}