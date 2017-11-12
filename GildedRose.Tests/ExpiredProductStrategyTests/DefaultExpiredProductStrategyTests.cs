using csharp;
using csharp.ExpiredProductStrategies;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests.ExpiredProductStrategyTests
{
    [TestClass]
    public class DefaultExpiredProductStrategyTests
    {
        [TestMethod, TestCategory("Unit")]
        public void ProductQualityShouldBeReducedByOne()
        {
            Item item = new Item { Name = "Foo", SellIn = 2, Quality = 50 };
            IProduct product = new Product(item);

            IExpiredProductStrategy defaultExpiredProductStrategy = new DefaultExpiredProductStrategy();
            IProduct actual = defaultExpiredProductStrategy.Expired(product);
            actual.Quality().Should().Be(49);
        }
    }
}