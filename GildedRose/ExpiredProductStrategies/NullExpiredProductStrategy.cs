using csharp.Products;

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
            if (ProductExpirationMatters(product)) return _nextStrategy.Expired(product);

            return product;
        }

        private bool ProductExpirationMatters(IProduct product)
        {
            if (product.DaysToSell() > -1) return false;
            if (product.Legendary()) return false;

            return !QualityHasBottomedOut(product);
        }

        private bool QualityHasBottomedOut(IProduct product)
        {
            return !product.Aged() && product.Quality() <= 0;
        }
    }
}