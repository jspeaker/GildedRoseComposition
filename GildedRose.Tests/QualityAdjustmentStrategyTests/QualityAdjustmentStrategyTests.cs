using csharp.Products;
using csharp.QualityAdjustmentStrategies;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests.QualityAdjustmentStrategyTests
{
    [TestClass]
    public class QualityAdjustmentStrategyTests
    {
        [TestMethod, TestCategory("Unit")]
        public void GivenConjuredItemShouldDecreaseQualityByTwo()
        {
            Item item = new Item { Name = "conjured", SellIn = 5, Quality = 20 };
            IProduct product = new Product(item);


            IQualityAdjustmentStrategy nullQualityAdjustmentStrategy = new NullQualityAdjustmentStrategy();
            IProduct actual = nullQualityAdjustmentStrategy.Adjust(product);

            actual.Quality().Should().Be(18);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenEventTicketFiveDaysFromEventShouldIncreaseQualityByThree()
        {
            Item item = new Item { Name = "backstage", SellIn = 5, Quality = 20 };
            IProduct product = new Product(item);


            IQualityAdjustmentStrategy nullQualityAdjustmentStrategy = new NullQualityAdjustmentStrategy();
            IProduct actual = nullQualityAdjustmentStrategy.Adjust(product);

            actual.Quality().Should().Be(23);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenEventTicketTenDaysFromEventShouldIncreaseQualityByTwo()
        {
            Item item = new Item { Name = "backstage", SellIn = 10, Quality = 20 };
            IProduct product = new Product(item);


            IQualityAdjustmentStrategy nullQualityAdjustmentStrategy = new NullQualityAdjustmentStrategy();
            IProduct actual = nullQualityAdjustmentStrategy.Adjust(product);

            actual.Quality().Should().Be(22);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenEventTicketElevenDaysFromEventShouldIncreaseQualityByOne()
        {
            Item item = new Item { Name = "backstage", SellIn = 11, Quality = 20 };
            IProduct product = new Product(item);


            IQualityAdjustmentStrategy nullQualityAdjustmentStrategy = new NullQualityAdjustmentStrategy();
            IProduct actual = nullQualityAdjustmentStrategy.Adjust(product);

            actual.Quality().Should().Be(21);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenEventTicketElevenDaysFromEventWithMaxQualityShouldNotIncreaseQuality()
        {
            Item item = new Item { Name = "backstage", SellIn = 11, Quality = 50 };
            IProduct product = new Product(item);

            IQualityAdjustmentStrategy nullQualityAdjustmentStrategy = new NullQualityAdjustmentStrategy();
            IProduct actual = nullQualityAdjustmentStrategy.Adjust(product);

            actual.Quality().Should().Be(50);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenEventTicketElevenDaysFromEventWithGreaterThanMaxQualityShouldDecreaseQualityToFifty()
        {
            Item item = new Item { Name = "backstage", SellIn = 11, Quality = 51 };
            IProduct product = new Product(item);

            IQualityAdjustmentStrategy nullQualityAdjustmentStrategy = new NullQualityAdjustmentStrategy();
            IProduct actual = nullQualityAdjustmentStrategy.Adjust(product);

            actual.Quality().Should().Be(50);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenAgedItemWithQualityShouldIncreaseQuality()
        {
            Item item = new Item { Name = "aged", SellIn = 2, Quality = 20 };
            IProduct product = new Product(item);

            IQualityAdjustmentStrategy nullQualityAdjustmentStrategy = new NullQualityAdjustmentStrategy();
            IProduct actual = nullQualityAdjustmentStrategy.Adjust(product);

            actual.Quality().Should().Be(21);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenAgedItemWithMaxQualityShouldNotIncreaseQuality()
        {
            Item item = new Item { Name = "aged", SellIn = 2, Quality = 50 };
            IProduct product = new Product(item);

            IQualityAdjustmentStrategy nullQualityAdjustmentStrategy = new NullQualityAdjustmentStrategy();
            IProduct actual = nullQualityAdjustmentStrategy.Adjust(product);

            actual.Quality().Should().Be(50);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenExpiredAgedItemWithNearlyMaxQualityShouldOnlyIncreaseQualityToMax()
        {
            Item item = new Item { Name = "aged", SellIn = -1, Quality = 49 };
            IProduct product = new Product(item);

            IQualityAdjustmentStrategy nullQualityAdjustmentStrategy = new NullQualityAdjustmentStrategy();
            IProduct actual = nullQualityAdjustmentStrategy.Adjust(product);

            actual.Quality().Should().Be(50);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenAgedItemWithNoQualityShouldIncreaseQuality()
        {
            Item item = new Item { Name = "aged", SellIn = 2, Quality = 0 };
            IProduct product = new Product(item);

            IQualityAdjustmentStrategy nullQualityAdjustmentStrategy = new NullQualityAdjustmentStrategy();
            IProduct actual = nullQualityAdjustmentStrategy.Adjust(product);

            actual.Quality().Should().Be(1);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenLegendaryItemShouldNotModifyQuality()
        {
            Item item = new Item { Name = "ragnaros", SellIn = 2, Quality = 80 };
            IProduct product = new Product(item);


            IQualityAdjustmentStrategy nullQualityAdjustmentStrategy = new NullQualityAdjustmentStrategy();
            IProduct actual = nullQualityAdjustmentStrategy.Adjust(product);

            actual.Quality().Should().Be(80);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenCommonItemWithQualityShouldReduceQuality()
        {
            Item item = new Item { Name = "Foo", SellIn = 2, Quality = 50 };
            IProduct product = new Product(item);


            IQualityAdjustmentStrategy nullQualityAdjustmentStrategy = new NullQualityAdjustmentStrategy();
            IProduct actual = nullQualityAdjustmentStrategy.Adjust(product);

            actual.Quality().Should().Be(49);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenCommonItemWithNoQualityShouldNotReduceQuality()
        {
            Item item = new Item { Name = "Foo", SellIn = 2, Quality = 0 };
            IProduct product = new Product(item);

            IQualityAdjustmentStrategy nullQualityAdjustmentStrategy = new NullQualityAdjustmentStrategy();
            IProduct actual = nullQualityAdjustmentStrategy.Adjust(product);

            actual.Quality().Should().Be(0);
        }
    }
}