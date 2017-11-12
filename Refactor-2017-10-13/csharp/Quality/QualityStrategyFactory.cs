namespace csharp.Quality
{
    public interface IQualityStrategyFactory
    {
        IQualityStrategy Strategy(IProduct product);
    }

    public class QualityStrategyFactory : IQualityStrategyFactory
    {
        public IQualityStrategy Strategy(IProduct product)
        {
            if (product.Aged()) return new AgedProductQuality(product);

            if (product.Legendary()) return new LegendaryProductQuality(product);

            if (product.ConcertTicket()) return new ConcertTicketProductQuality(product);

            return new CommonProductQuality(product);
        }
    }
}