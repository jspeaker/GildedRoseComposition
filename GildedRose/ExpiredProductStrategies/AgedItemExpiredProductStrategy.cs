namespace csharp.ExpiredProductStrategies
{
    public class AgedItemExpiredProductStrategy : IExpiredProductStrategy
    {
        private readonly IExpiredProductStrategy _nextStrategy;

        public AgedItemExpiredProductStrategy() : this(new EventTicketExpiredProductStrategy()) { }

        public AgedItemExpiredProductStrategy(IExpiredProductStrategy nextStrategy)
        {
            _nextStrategy = nextStrategy;
        }

        public IProduct Expired(IProduct product)
        {
            if (!product.AgedItem()) return _nextStrategy.Expired(product);

            if (product.Quality() == 50) return product;

            return new Product(new Item
            {
                Name = product.Item().Name,
                Quality = product.Quality() + 1,
                SellIn = product.Item().SellIn
            });
        }
    }
}