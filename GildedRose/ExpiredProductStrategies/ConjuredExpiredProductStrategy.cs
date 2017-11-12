namespace csharp.ExpiredProductStrategies
{
    public class ConjuredExpiredProductStrategy : IExpiredProductStrategy
    {
        private readonly IExpiredProductStrategy _nextStrategy;

        public ConjuredExpiredProductStrategy() : this(new DefaultExpiredProductStrategy()) { }

        public ConjuredExpiredProductStrategy(IExpiredProductStrategy nextStrategy)
        {
            _nextStrategy = nextStrategy;
        }

        public IProduct Expired(IProduct product)
        {
            if (!product.Conjured()) return _nextStrategy.Expired(product);

            if (product.Item().SellIn > -1) return product;

            return new Product(new Item
            {
                Name = product.Item().Name,
                Quality = product.Quality() - 2,
                SellIn = product.Item().SellIn
            });
        }
    }
}