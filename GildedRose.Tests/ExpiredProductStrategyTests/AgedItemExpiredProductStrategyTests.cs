using csharp;
using csharp.ExpiredProductStrategies;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests.ExpiredProductStrategyTests
{
    [TestClass]
    public class AgedItemExpiredProductStrategyTests
    {
        [TestMethod, TestCategory("Unit")]
        public void GivenAgedItemExpiredProductStrategyShouldIncreaseQuality()
        {
            Item item = new Item { Name = "Aged Brie", SellIn = -1, Quality = 0 };
            IProduct product = new Product(item);

            IExpiredProductStrategy agedItemExpiredProductStrategy = new AgedItemExpiredProductStrategy();
            IProduct actual = agedItemExpiredProductStrategy.Expired(product);

            actual.Item().Name.Should().Be(item.Name);
            actual.Item().SellIn.Should().Be(item.SellIn);
            actual.Quality().Should().Be(1);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenAgedItemExpiredProductWithMaxQualityStrategyShouldReturnSameObject()
        {
            Item item = new Item { Name = "Aged Brie", SellIn = -1, Quality = 50 };
            IProduct product = new Product(item);

            IExpiredProductStrategy agedItemExpiredProductStrategy = new AgedItemExpiredProductStrategy();
            IProduct actual = agedItemExpiredProductStrategy.Expired(product);

            actual.Item().Should().Be(item);
        }
    }
}