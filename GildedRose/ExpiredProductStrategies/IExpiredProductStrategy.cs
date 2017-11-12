namespace csharp.ExpiredProductStrategies
{
    public interface IExpiredProductStrategy
    {
        IProduct Expired(IProduct product);
    }
}