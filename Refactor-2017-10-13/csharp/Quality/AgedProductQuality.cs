namespace csharp.Quality
{
    public class AgedProductQuality : IQualityStrategy
    {
        private readonly IProduct _product;

        public AgedProductQuality(IProduct product)
        {
            _product = product;
        }

        public int Quality()
        {
            if (_product.Quality() >= 50) return 50;

            return _product.Quality() + 1;
        }
    }
}