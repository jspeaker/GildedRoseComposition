using csharp;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests
{
    [TestClass]
    public class ProductLegendaryTests
    {
        [TestMethod, TestCategory("Unit")]
        public void GivenLegendaryItemLegendaryShouldReturnTrue()
        {
            Item item = new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80};
            IProduct product = new Product(item);

            bool legendary = product.Legendary();
            legendary.Should().BeTrue();
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenNonLegendaryItemLegendaryShouldReturnTrue()
        {
            Item item = new Item { Name = "Foo", SellIn = 0, Quality = 50 };
            IProduct product = new Product(item);

            bool legendary = product.Legendary();
            legendary.Should().BeFalse();
        }
    }
}