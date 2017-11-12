namespace csharp.ExpiredProductStrategies
{
    public class NullExpiredProductStrategy : IExpiredProductStrategy
    {
        private readonly IExpiredProductStrategy _nextStrategy;

        public NullExpiredProductStrategy() : this(new AgedItemExpiredProductStrategy()) { }

        public NullExpiredProductStrategy(IExpiredProductStrategy nextStrategy)
        {
            _nextStrategy = nextStrategy;
        }

        public IProduct Expired(IProduct product)
        {
            if (product.DaysToSell() > -1 || product.Legendary() || product.Quality() <= 0 && !product.Aged()) return product;

            return _nextStrategy.Expired(product);
        }
    }
}