using System.Collections.Generic;
using csharp.Logging;
using csharp.Products;

namespace csharp.Specialists
{
    public interface IScribe
    {
        void InscribeProductInformation(IEnumerable<IProduct> products, int day);
    }

    public class Scribe : IScribe
    {
        private readonly ILog _log;

        public Scribe() : this(new Log()) { }

        public Scribe(ILog log)
        {
            _log = log;
        }

        public void InscribeProductInformation(IEnumerable<IProduct> products, int day)
        {
            _log.Print($"-------- day {day} --------");
            _log.Print("name, sellIn, quality");
            foreach (IProduct product in products)
            {
                _log.Print($"{product.Name()}, {product.DaysToSell()}, {product.Quality()}");
            }
            _log.Print(string.Empty);
        }
    }
}