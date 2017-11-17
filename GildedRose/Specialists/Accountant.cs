using System.Collections.Generic;
using System.Linq;
using csharp.Products;

namespace csharp.Specialists
{
    public interface IAccountant
    {
        void WriteInventoryProjectionReport(int days);
    }

    public class Accountant : IAccountant
    {
        private readonly IInventory _inventory;
        private readonly IIllusionist _illusionist;
        private readonly IScribe _scribe;

        public Accountant() : this(new Inventory(), new Illusionist(), new Scribe()) { }

        public Accountant(IInventory inventory, IIllusionist illusionist, IScribe scribe)
        {
            _inventory = inventory;
            _illusionist = illusionist;
            _scribe = scribe;
        }

        public void WriteInventoryProjectionReport(int days)
        {
            IList<IProduct> products = _inventory.Products().ToList();
            for (int day = 0; day < 31; day++)
            {
                _scribe.InscribeProductInformation(products, day);
                products = _illusionist.CastAgeProducts(products).ToList();
            }
        }
    }
}