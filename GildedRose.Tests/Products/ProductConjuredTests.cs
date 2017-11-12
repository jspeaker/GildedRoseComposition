using csharp.Products;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests.Products
{
    [TestClass]
    public class ProductConjuredTests
    {
        [TestMethod, TestCategory("Unit")]
        public void GivenConjuredItemShouldReturnTrue()
        {
            Item item = new Item { Name = "Conjured Mana Cakes", SellIn = 10, Quality = 40 };
            IProduct product = new Product(item);

            bool conjured = product.Conjured();
            conjured.Should().BeTrue();
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenNonConjuredItemShouldReturnFalse()
        {
            Item item = new Item { Name = "Mana Cakes", SellIn = 10, Quality = 40 };
            IProduct product = new Product(item);

            bool conjured = product.Conjured();
            conjured.Should().BeFalse();
        }
    }
}