using csharp.Products;

namespace csharp.ExpiredProductStrategies
{
    public class EventTicketExpiredProductStrategy : IExpiredProductStrategy
    {
        private readonly IExpiredProductStrategy _nextStrategy;
        private readonly IProductBuilder _productBuilder;

        public EventTicketExpiredProductStrategy() : this(new ConjuredExpiredProductStrategy(), new ProductBuilder()) { }

        public EventTicketExpiredProductStrategy(IExpiredProductStrategy nextStrategy, IProductBuilder productBuilder)
        {
            _nextStrategy = nextStrategy;
            _productBuilder = productBuilder;
        }

        public IProduct Expired(IProduct product)
        {
            if (!product.Ticket()) return _nextStrategy.Expired(product);

            if (product.Quality() == 0) return product;

            return _productBuilder.Build(product.Name(), 0, product.DaysToSell());
        }
    }
}