using csharp;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests
{
    [TestClass]
    public class ProductCommonTests
    {
        [TestMethod, TestCategory("Unit")]
        public void GivenCommonItemShouldReturnTrue()
        {
            Item item = new Item { Name = "common", SellIn = 10, Quality = 40 };
            IProduct product = new Product(item);

            bool common = product.Common();
            common.Should().BeTrue();
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenLegendaryItemShouldReturnFalse()
        {
            Item item = new Item { Name = "ragnaros", SellIn = 10, Quality = 40 };
            IProduct product = new Product(item);

            bool common = product.Common();
            common.Should().BeFalse();
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenAgedItemShouldReturnFalse()
        {
            Item item = new Item { Name = "aged", SellIn = 10, Quality = 40 };
            IProduct product = new Product(item);

            bool common = product.Common();
            common.Should().BeFalse();
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenEventTicketShouldReturnFalse()
        {
            Item item = new Item { Name = "backstage", SellIn = 10, Quality = 40 };
            IProduct product = new Product(item);

            bool common = product.Common();
            common.Should().BeFalse();
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenConjuredItemShouldReturnFalse()
        {
            Item item = new Item { Name = "conjured", SellIn = 10, Quality = 40 };
            IProduct product = new Product(item);

            bool common = product.Common();
            common.Should().BeFalse();
        }
    }
}