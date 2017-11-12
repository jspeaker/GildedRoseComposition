using csharp.QualityAdjustmentStrategies;

namespace csharp.ExpiredProductStrategies
{
    public class AgedItemExpiredProductStrategy : IExpiredProductStrategy
    {
        private readonly IExpiredProductStrategy _nextStrategy;
        private readonly IQualityCop _qualityCop;
        private readonly IProductBuilder _productBuilder;

        public AgedItemExpiredProductStrategy() : this(new EventTicketExpiredProductStrategy(), new QualityCop(), new ProductBuilder()) { }

        public AgedItemExpiredProductStrategy(IExpiredProductStrategy nextStrategy, IQualityCop qualityCop, IProductBuilder productBuilder)
        {
            _nextStrategy = nextStrategy;
            _qualityCop = qualityCop;
            _productBuilder = productBuilder;
        }

        public IProduct Expired(IProduct product)
        {
            if (!product.Aged()) return _nextStrategy.Expired(product);

            return _qualityCop.EnforceMaximum(_productBuilder.Build(product.Name(), product.Quality() + 1, product.DaysToSell()));

        }
    }
}