using System.Collections.Generic;
using csharp.Data;
using csharp.Models;
using FluentAssertions;
using NUnit.Framework;

namespace csharp.tests.Data
{
    [TestFixture]
    public class InventoryTests
    {
        [Test, Category("Unit")]
        public void ShouldReturnProducts()
        {
            // arrange
            IInventory inventory = new Inventory();

            // act
            List<IProduct> products = inventory.Products();

            // assert
            products.Count.Should().BeGreaterThan(0);
        }

        [Test, Category("Unit")]
        public void ProductsShouldBeMutable()
        {
            // arrange
            IInventory inventory = new Inventory();
            List<IProduct> products = inventory.Products();
            string initialDescription = products[0].ToString();

            // act
            products[0] = products[0].AgedProduct().WithAdjustedQuality();
            string updatedDescription = products[0].ToString();

            // assert
            initialDescription.Should().NotBe(updatedDescription);
        }
    }
}