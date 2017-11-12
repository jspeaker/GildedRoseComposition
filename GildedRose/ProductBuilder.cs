namespace csharp
{
    public interface IProductBuilder
    {
        IProduct Build(string name, int quality, int daysToSell);
    }

    public class ProductBuilder : IProductBuilder
    {
        public IProduct Build(string name, int quality, int daysToSell)
        {
            return new Product(new Item
            {
                Name = name,
                Quality = quality,
                SellIn = daysToSell
            });
        }
    }
}