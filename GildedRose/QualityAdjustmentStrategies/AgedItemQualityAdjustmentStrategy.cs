using csharp.Products;
using csharp.Specialists;

namespace csharp.QualityAdjustmentStrategies
{
    public class AgedItemQualityAdjustmentStrategy : IQualityAdjustmentStrategy
    {
        private readonly IQualityAdjustmentStrategy _nextStrategy;
        private readonly IConstable _constable;
        private readonly IProductBuilder _productBuilder;

        public AgedItemQualityAdjustmentStrategy() : this(new EventTicketQualityAdjustmentStrategy(), new Constable(), new ProductBuilder()) { }

        public AgedItemQualityAdjustmentStrategy(IQualityAdjustmentStrategy nextStrategy, IConstable constable, IProductBuilder productBuilder)
        {
            _nextStrategy = nextStrategy;
            _constable = constable;
            _productBuilder = productBuilder;
        }

        public IProduct Adjust(IProduct product)
        {
            if (!product.Aged()) return _nextStrategy.Adjust(product);

            return _constable.EnforceMaximumQuality(_productBuilder.Build(product.Name(), product.Quality() + 1, product.DaysToSell()));
        }
    }
}