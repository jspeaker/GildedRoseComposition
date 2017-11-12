using csharp.Products;

namespace csharp.QualityAdjustmentStrategies
{
    public class NullQualityAdjustmentStrategy : IQualityAdjustmentStrategy
    {
        private readonly IQualityAdjustmentStrategy _nextStrategy;

        public NullQualityAdjustmentStrategy() : this(new AgedItemQualityAdjustmentStrategy()) { }

        public NullQualityAdjustmentStrategy(IQualityAdjustmentStrategy nextStrategy)
        {
            _nextStrategy = nextStrategy;
        }

        public IProduct Adjust(IProduct product)
        {
            if (product.Aged()) return _nextStrategy.Adjust(product);
            if (!product.Legendary() && product.Quality() > 0) return _nextStrategy.Adjust(product);

            return product;
        }
    }
}