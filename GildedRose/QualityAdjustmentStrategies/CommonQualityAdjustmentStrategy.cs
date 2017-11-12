using csharp.Products;

namespace csharp.QualityAdjustmentStrategies
{
    public class CommonQualityAdjustmentStrategy : IQualityAdjustmentStrategy
    {
        private readonly IProductBuilder _productBuilder;

        public CommonQualityAdjustmentStrategy() : this(new ProductBuilder()) { }

        public CommonQualityAdjustmentStrategy(IProductBuilder productBuilder)
        {
            _productBuilder = productBuilder;
        }

        public IProduct Adjust(IProduct product)
        {
            return _productBuilder.Build(product.Name(), product.Quality() - 1, product.DaysToSell());
        }
    }
}