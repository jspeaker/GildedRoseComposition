using csharp.Models;

namespace csharp.Strategies
{
    public class ConjurationQualityAdjustment : IQualityAdjustmentStrategy
    {
        private readonly IQualityAdjustmentStrategy _nextQualityAdjustmentStrategy;

        public ConjurationQualityAdjustment() : this(new DefaultQualityAdjustment()) { }

        public ConjurationQualityAdjustment(IQualityAdjustmentStrategy nextQualityAdjustmentStrategy)
        {
            _nextQualityAdjustmentStrategy = nextQualityAdjustmentStrategy;
        }

        public IProduct WithAdjustment(IProduct product)
        {
            if (!product.Is(ProductCategory.Conjured)) return _nextQualityAdjustmentStrategy.WithAdjustment(product);

            return product.WithAdjustedQuality(-2);
        }
    }
}