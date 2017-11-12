using csharp.ExpiredProductStrategies;
using csharp.Products;
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

            actual.Name().Should().Be(item.Name);
            actual.DaysToSell().Should().Be(item.SellIn);
            actual.Quality().Should().Be(1);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenAgedItemExpiredProductWithMaxQualityStrategyShouldNotIncreaseQuality()
        {
            Item item = new Item { Name = "Aged Brie", SellIn = -1, Quality = 50 };
            IProduct product = new Product(item);

            IExpiredProductStrategy agedItemExpiredProductStrategy = new AgedItemExpiredProductStrategy();
            IProduct actual = agedItemExpiredProductStrategy.Expired(product);

            actual.Quality().Should().Be(50);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenAgedItemExpiredProductWithGreaterThanMaxQualityStrategyShouldReduceQualityToMax()
        {
            Item item = new Item { Name = "Aged Brie", SellIn = -1, Quality = 51 };
            IProduct product = new Product(item);

            IExpiredProductStrategy agedItemExpiredProductStrategy = new AgedItemExpiredProductStrategy();
            IProduct actual = agedItemExpiredProductStrategy.Expired(product);

            actual.Quality().Should().Be(50);
        }
    }
}