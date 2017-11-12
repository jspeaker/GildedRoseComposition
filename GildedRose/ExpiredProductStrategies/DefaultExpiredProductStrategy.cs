namespace csharp.ExpiredProductStrategies
{
    public class DefaultExpiredProductStrategy : IExpiredProductStrategy
    {
        private readonly IProductBuilder _productBuilder;

        public DefaultExpiredProductStrategy() : this(new ProductBuilder()) { }

        public DefaultExpiredProductStrategy(IProductBuilder productBuilder)
        {
            _productBuilder = productBuilder;
        }

        public IProduct Expired(IProduct product)
        {
            if (product.DaysToSell() > -1) return product;

            return _productBuilder.Build(product.Name(), product.Quality() - 1, product.DaysToSell());
        }
    }
}