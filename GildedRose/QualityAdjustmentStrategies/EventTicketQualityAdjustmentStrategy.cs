namespace csharp.QualityAdjustmentStrategies
{
    public class EventTicketQualityAdjustmentStrategy : IQualityAdjustmentStrategy
    {
        private readonly IQualityAdjustmentStrategy _nextStrategy;
        private readonly IQualityCop _qualityCop;
        private readonly IProductBuilder _productBuilder;

        public EventTicketQualityAdjustmentStrategy() : this(new ConjuredItemQualityAdjustmentStrategy(), new QualityCop(), new ProductBuilder()) { }

        public EventTicketQualityAdjustmentStrategy(IQualityAdjustmentStrategy nextStrategy, IQualityCop qualityCop, IProductBuilder productBuilder)
        {
            _nextStrategy = nextStrategy;
            _qualityCop = qualityCop;
            _productBuilder = productBuilder;
        }

        public IProduct Adjust(IProduct product)
        {
            if (!product.Ticket()) return _nextStrategy.Adjust(product);

            return _qualityCop.EnforceMaximum(_productBuilder.Build(product.Name(), product.Quality() + EventQualityIncrement(product), product.DaysToSell()));
        }

        private int EventQualityIncrement(IProduct product)
        {
            if (product.DaysToSell() < 6) return 3;
            if (product.DaysToSell() < 11) return 2;
            return 1;
        }
    }
}