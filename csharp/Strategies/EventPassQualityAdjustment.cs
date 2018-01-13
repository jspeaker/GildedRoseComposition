using csharp.Models;

namespace csharp.Strategies
{
    public class EventPassQualityAdjustment : IQualityAdjustmentStrategy
    {
        private readonly IQualityAdjustmentStrategy _nextQualityAdjustmentStrategy;

        public EventPassQualityAdjustment() : this(new ConjurationQualityAdjustment()) { }

        public EventPassQualityAdjustment(IQualityAdjustmentStrategy nextQualityAdjustmentStrategy)
        {
            _nextQualityAdjustmentStrategy = nextQualityAdjustmentStrategy;
        }

        public IProduct WithAdjustment(IProduct product)
        {
            if (!product.Is(ProductCategory.EventPass)) return _nextQualityAdjustmentStrategy.WithAdjustment(product);

            return product.WithAdjustedQuality(product.EventPassQualityAddend());
        }
    }
}