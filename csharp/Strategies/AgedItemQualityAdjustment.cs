using csharp.Models;

namespace csharp.Strategies
{
    public class AgedItemQualityAdjustment : IQualityAdjustmentStrategy
    {
        private readonly IQualityAdjustmentStrategy _nextQualityAdjustmentStrategy;

        public AgedItemQualityAdjustment() : this(new EventPassQualityAdjustment()) { }

        public AgedItemQualityAdjustment(IQualityAdjustmentStrategy nextQualityAdjustmentStrategy)
        {
            _nextQualityAdjustmentStrategy = nextQualityAdjustmentStrategy;
        }

        public IProduct WithAdjustment(IProduct product)
        {
            if (!product.Is(ProductCategory.AgedItem)) return _nextQualityAdjustmentStrategy.WithAdjustment(product);

            return product.WithAdjustedQuality(1);
        }
    }
}