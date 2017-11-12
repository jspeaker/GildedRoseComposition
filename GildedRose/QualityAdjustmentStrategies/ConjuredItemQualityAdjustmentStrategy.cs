using csharp.Products;

namespace csharp.QualityAdjustmentStrategies
{
    public class ConjuredItemQualityAdjustmentStrategy : IQualityAdjustmentStrategy
    {
        private readonly IQualityAdjustmentStrategy _nextStrategy;
        private readonly IProductBuilder _productBuilder;

        public ConjuredItemQualityAdjustmentStrategy() : this(new CommonQualityAdjustmentStrategy(), new ProductBuilder()) { }

        public ConjuredItemQualityAdjustmentStrategy(IQualityAdjustmentStrategy nextStrategy, IProductBuilder productBuilder)
        {
            _nextStrategy = nextStrategy;
            _productBuilder = productBuilder;
        }

        public IProduct Adjust(IProduct product)
        {
            if (!product.Conjured()) return _nextStrategy.Adjust(product);

            return _productBuilder.Build(product.Name(), product.Quality() - 2, product.DaysToSell());
        }
    }
}