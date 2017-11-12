using csharp.ExpiredProductStrategies;
using csharp.Products;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests.ExpiredProductStrategyTests
{
    [TestClass]
    public class ConjuredExpiredProductStrategyTests
    {
        [TestMethod, TestCategory("Unit")]
        public void ExpiredProductQualityShouldBeReducedByTwo()
        {
            Item item = new Item { Name = "Conjured", SellIn = -1, Quality = 50 };
            IProduct product = new Product(item);

            IExpiredProductStrategy defaultExpiredProductStrategy = new ConjuredExpiredProductStrategy();
            IProduct actual = defaultExpiredProductStrategy.Expired(product);
            actual.Quality().Should().Be(48);
        }

        [TestMethod, TestCategory("Unit")]
        public void NonExpiredProductQualityShouldNotBeReduced()
        {
            Item item = new Item { Name = "Conjured", SellIn = 2, Quality = 50 };
            IProduct product = new Product(item);

            IExpiredProductStrategy defaultExpiredProductStrategy = new ConjuredExpiredProductStrategy();
            IProduct actual = defaultExpiredProductStrategy.Expired(product);
            actual.Quality().Should().Be(50);
        }
    }
}