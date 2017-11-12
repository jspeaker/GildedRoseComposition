using csharp.Products;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests.Products
{
    [TestClass]
    public class ProductWithReducedSellInTests
    {
        [TestMethod, TestCategory("Unit")]
        public void GivenNonLegendaryItemShouldReduceSellInTimeframe()
        {
            Item item = new Item { Name = "Foo", SellIn = 5, Quality = 50 };
            IProduct product = new Product(item);

            IProduct actual = product.WithReducedSellIn();

            actual.DaysToSell().Should().Be(4);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenLegendaryItemShouldNotReduceSellInTimeframe()
        {
            Item item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };
            IProduct product = new Product(item);

            IProduct actual = product.WithReducedSellIn();

            actual.DaysToSell().Should().Be(0);
        }
    }
}