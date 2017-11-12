using csharp.Products;
using csharp.Specialists;

namespace csharp.QualityAdjustmentStrategies
{
    public class EventTicketQualityAdjustmentStrategy : IQualityAdjustmentStrategy
    {
        private readonly IQualityAdjustmentStrategy _nextStrategy;
        private readonly IConstable _constable;
        private readonly IProductBuilder _productBuilder;

        public EventTicketQualityAdjustmentStrategy() : this(new ConjuredItemQualityAdjustmentStrategy(), new Constable(), new ProductBuilder()) { }

        public EventTicketQualityAdjustmentStrategy(IQualityAdjustmentStrategy nextStrategy, IConstable constable, IProductBuilder productBuilder)
        {
            _nextStrategy = nextStrategy;
            _constable = constable;
            _productBuilder = productBuilder;
        }

        public IProduct Adjust(IProduct product)
        {
            if (!product.Ticket()) return _nextStrategy.Adjust(product);

            return _constable.EnforceMaximumQuality(_productBuilder.Build(product.Name(), product.Quality() + EventQualityIncrement(product), product.DaysToSell()));
        }

        private int EventQualityIncrement(IProduct product)
        {
            if (product.DaysToSell() < 6) return 3;
            if (product.DaysToSell() < 11) return 2;
            return 1;
        }
    }
}