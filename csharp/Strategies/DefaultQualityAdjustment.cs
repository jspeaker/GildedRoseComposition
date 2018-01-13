using csharp.Models;

namespace csharp.Strategies
{
    public class DefaultQualityAdjustment : IQualityAdjustmentStrategy
    {
        public IProduct WithAdjustment(IProduct product)
        {
            return product;
        }
    }
}