using System.Collections.Generic;
using System.Linq;
using csharp.Products;

namespace csharp.Specialists
{
    public interface IIllusionist
    {
        void CastAgeProducts(int days);
    }

    public class Illusionist : IIllusionist
    {
        private readonly IScribe _scribe;
        private readonly IInventory _inventory;
        private readonly IProductLife _productLife;

        public Illusionist() : this(new Scribe(), new Inventory(), new ProductLife()) { }

        public Illusionist(IScribe scribe, IInventory inventory, IProductLife productLife)
        {
            _scribe = scribe;
            _inventory = inventory;
            _productLife = productLife;
        }

        public void CastAgeProducts(int days)
        {
            List<IProduct> products = _inventory.Products().ToList();
            for (int day = 0; day < days; day++)
            {
                _scribe.InscribeProductInformation(products, day);
                products = _productLife.WithIncreasedAge(products).ToList();
            }
        }
    }
}