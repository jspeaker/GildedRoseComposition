namespace csharp.QualityAdjustmentStrategies
{
    public interface IQualityCop
    {
        IProduct EnforceMaximum(IProduct product);
    }

    public class QualityCop : IQualityCop
    {
        public IProduct EnforceMaximum(IProduct product)
        {
            if (product.Quality() <= 50) return product;
            return new Product(new Item
            {
                Name = product.Name(),
                Quality = 50,
                SellIn = product.DaysToSell()
            });
        }
    }
}