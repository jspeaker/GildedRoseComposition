namespace csharp.Quality
{
    public class LegendaryProductQuality : IQualityStrategy
    {
        private readonly IProduct _product;

        public LegendaryProductQuality(IProduct product)
        {
            _product = product;
        }

        public int Quality()
        {
            return _product.Quality();
        }
    }
}