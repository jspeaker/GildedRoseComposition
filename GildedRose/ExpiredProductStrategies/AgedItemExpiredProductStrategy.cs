using csharp.Products;
using csharp.Specialists;

namespace csharp.ExpiredProductStrategies
{
    public class AgedItemExpiredProductStrategy : IExpiredProductStrategy
    {
        private readonly IExpiredProductStrategy _nextStrategy;
        private readonly IConstable _constable;
        private readonly IProductBuilder _productBuilder;

        public AgedItemExpiredProductStrategy() : this(new EventTicketExpiredProductStrategy(), new Constable(), new ProductBuilder()) { }

        public AgedItemExpiredProductStrategy(IExpiredProductStrategy nextStrategy, IConstable constable, IProductBuilder productBuilder)
        {
            _nextStrategy = nextStrategy;
            _constable = constable;
            _productBuilder = productBuilder;
        }

        public IProduct Expired(IProduct product)
        {
            if (!product.Aged()) return _nextStrategy.Expired(product);

            return _constable.EnforceMaximumQuality(_productBuilder.Build(product.Name(), product.Quality() + 1, product.DaysToSell()));
        }
    }
}