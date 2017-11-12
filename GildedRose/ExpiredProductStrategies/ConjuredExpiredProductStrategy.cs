using csharp.Products;

namespace csharp.ExpiredProductStrategies
{
    public class ConjuredExpiredProductStrategy : IExpiredProductStrategy
    {
        private readonly IExpiredProductStrategy _nextStrategy;
        private readonly IProductBuilder _productBuilder;

        public ConjuredExpiredProductStrategy() : this(new DefaultExpiredProductStrategy(), new ProductBuilder()) { }

        public ConjuredExpiredProductStrategy(IExpiredProductStrategy nextStrategy, IProductBuilder productBuilder)
        {
            _nextStrategy = nextStrategy;
            _productBuilder = productBuilder;
        }

        public IProduct Expired(IProduct product)
        {
            if (!product.Conjured()) return _nextStrategy.Expired(product);

            if (product.DaysToSell() > -1) return product;

            return _productBuilder.Build(product.Name(), product.Quality() - 2, product.DaysToSell());
        }
    }
}