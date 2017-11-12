using System.Collections.Generic;
using System.Linq;
using csharp.Products;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests.Products
{
    [TestClass]
    public class InventoryTests
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnProducts()
        {
            IInventory inventory = new Inventory();
            IEnumerable<IProduct> products = inventory.Products();
            products.Count().Should().Be(9);
        }
    }
}