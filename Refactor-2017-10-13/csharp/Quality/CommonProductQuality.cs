namespace csharp.Quality
{
    public class CommonProductQuality : IQualityStrategy
    {
        private readonly IProduct _product;

        public CommonProductQuality(IProduct product)
        {
            _product = product;
        }

        public int Quality()
        {
            if (_product.Quality() < 1) return 0;

            return _product.Quality() - 1;
        }
    }
}