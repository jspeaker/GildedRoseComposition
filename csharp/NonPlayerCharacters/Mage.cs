using System.Collections.Generic;
using csharp.Data;
using csharp.Models;

namespace csharp.NonPlayerCharacters
{
    public interface IMage
    {
        void CastAgeProducts();
    }

    public class Mage : IMage
    {
        private readonly IInventory _inventory;

        public Mage(IInventory inventory)
        {
            _inventory = inventory;
        }

        public void CastAgeProducts()
        {
            IList<IProduct> products = _inventory.Products();
            for (int i = 0; i < products.Count; i++)
            {
                products[i] = products[i]
                    .AgedProduct()
                    .WithAdjustedQuality();
            }
        }
    }
}
