using csharp;
using csharp.ExpiredProductStrategies;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests.ExpiredProductStrategyTests
{
    [TestClass]
    public class EventTicketExpiredProductStrategyTests
    {
        [TestMethod, TestCategory("Unit")]
        public void GivenExpiredEventTicketStrategyShouldReduceQualityToZero()
        {
            Item item = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = -1,
                Quality = 20
            };
            IProduct product = new Product(item);

            IExpiredProductStrategy eventTicketExpiredProductStrategy = new EventTicketExpiredProductStrategy();
            IProduct actual = eventTicketExpiredProductStrategy.Expired(product);

            actual.Item().Name.Should().Be(item.Name);
            actual.Item().SellIn.Should().Be(item.SellIn);
            actual.Quality().Should().Be(0);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenExpiredEventTicketStrategyAndProductWithZeroQualtiyShouldReturnSameObject()
        {
            Item item = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = -1,
                Quality = 0
            };
            IProduct product = new Product(item);

            IExpiredProductStrategy eventTicketExpiredProductStrategy = new EventTicketExpiredProductStrategy();
            IProduct actual = eventTicketExpiredProductStrategy.Expired(product);

            actual.Item().Should().Be(item);
        }
    }
}