using csharp.Models;

namespace csharp.Strategies
{
    public class CommonQualityAdjustment : IQualityAdjustmentStrategy
    {
        private readonly IQualityAdjustmentStrategy _nextQualityAdjustmentStrategy;

        public CommonQualityAdjustment() : this(new AgedItemQualityAdjustment()) { }

        public CommonQualityAdjustment(IQualityAdjustmentStrategy nextQualityAdjustmentStrategy)
        {
            _nextQualityAdjustmentStrategy = nextQualityAdjustmentStrategy;
        }

        public IProduct WithAdjustment(IProduct product)
        {
            if (!product.Is(ProductCategory.Common)) return _nextQualityAdjustmentStrategy.WithAdjustment(product);

            return product.WithAdjustedQuality(-1);
        }
    }
}