using System.Runtime.Remoting.Lifetime;

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
            if (product.Item().SellIn > -1 || product.Legendary() || product.Item().Quality <= 0 && !product.AgedItem()) return product;

            return _nextStrategy.Expired(product);
        }
    }
}