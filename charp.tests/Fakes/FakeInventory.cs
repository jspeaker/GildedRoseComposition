using System.Collections.Generic;
using csharp.Data;
using csharp.Models;

namespace csharp.tests.Fakes
{
    public class FakeInventory : IInventory
    {
        private static readonly List<IProduct> TheProducts = new List<IProduct>
        {
            new Product("Iron Spike", 10, 20)
        };

        public List<IProduct> Products()
        {
            return TheProducts;
        }
    }
}