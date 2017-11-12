namespace csharp.QualityAdjustmentStrategies
{
    public class AgedItemQualityAdjustmentStrategy : IQualityAdjustmentStrategy
    {
        private readonly IQualityAdjustmentStrategy _nextStrategy;
        private readonly IQualityCop _qualityCop;
        private readonly IProductBuilder _productBuilder;

        public AgedItemQualityAdjustmentStrategy() : this(new EventTicketQualityAdjustmentStrategy(), new QualityCop(), new ProductBuilder()) { }

        public AgedItemQualityAdjustmentStrategy(IQualityAdjustmentStrategy nextStrategy, IQualityCop qualityCop, IProductBuilder productBuilder)
        {
            _nextStrategy = nextStrategy;
            _qualityCop = qualityCop;
            _productBuilder = productBuilder;
        }

        public IProduct Adjust(IProduct product)
        {
            if (!product.Aged()) return _nextStrategy.Adjust(product);

            return _qualityCop.EnforceMaximum(_productBuilder.Build(product.Name(), product.Quality() + 1, product.DaysToSell()));
        }
    }
}