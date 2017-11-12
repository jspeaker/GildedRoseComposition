using csharp.Products;

namespace csharp.QualityAdjustmentStrategies
{
    public interface IQualityAdjustmentStrategy
    {
        IProduct Adjust(IProduct product);
    }
}