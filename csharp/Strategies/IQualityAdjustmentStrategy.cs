using csharp.Models;

namespace csharp.Strategies
{
    public interface IQualityAdjustmentStrategy
    {

        IProduct WithAdjustment(IProduct product);
    }
}