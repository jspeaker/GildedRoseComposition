namespace csharp.ExpiredProductStrategies
{
    public class EventTicketExpiredProductStrategy : IExpiredProductStrategy
    {
        private readonly IExpiredProductStrategy _nextStrategy;

        public EventTicketExpiredProductStrategy() : this(new DefaultExpiredProductStrategy()) { }

        public EventTicketExpiredProductStrategy(IExpiredProductStrategy nextStrategy)
        {
            _nextStrategy = nextStrategy;
        }

        public IProduct Expired(IProduct product)
        {
            if (!product.EventTicket()) return _nextStrategy.Expired(product);

            if (product.Quality() == 0) return product;

            return new Product(new Item
            {
                Name = product.Item().Name,
                Quality = 0,
                SellIn = product.Item().SellIn
            });
        }
    }
}