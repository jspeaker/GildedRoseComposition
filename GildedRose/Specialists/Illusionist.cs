using System.Collections.Generic;
using System.Linq;
using csharp.Products;

namespace csharp.Specialists
{
    public interface IIllusionist
    {
        IList<IProduct> CastAgeProducts(IList<IProduct> products);
    }

    public class Illusionist : IIllusionist
    {
        private readonly IProductLife _productLife;

        public Illusionist() : this(new ProductLife()) { }

        public Illusionist(IProductLife productLife)
        {
            _productLife = productLife;
        }

        public IList<IProduct> CastAgeProducts(IList<IProduct> products)
        {
            return _productLife.WithIncreasedAge(products).ToList();
        }
    }
}