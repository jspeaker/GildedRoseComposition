namespace csharp.Quality
{
    public class ConcertTicketProductQuality : IQualityStrategy
    {
        private readonly IProduct _product;

        public ConcertTicketProductQuality(IProduct product)
        {
            _product = product;
        }

        public int Quality()
        {
            if (_product.Quality() >= 50) return _product.Quality();

            return _product.Quality() + Increment();
        }

        private int Increment()
        {
            if (_product.SellIn() < 0) return -_product.Quality();

            if (_product.SellIn() > 10) return 1;

            if (_product.SellIn() > 5) return 2;

            return 3;
        }
    }
}