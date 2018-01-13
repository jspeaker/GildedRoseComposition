using csharp.Models;
using csharp.Strategies;
using FluentAssertions;
using NUnit.Framework;

namespace csharp.tests.Strategies
{
    [TestFixture]
    public class EventPassQualityAdjustmentTests
    {
        private IQualityAdjustmentStrategy _qualityAdjustment;

        [SetUp]
        public void Setup()
        {
            _qualityAdjustment = new EventPassQualityAdjustment(new DefaultQualityAdjustment());
        }

        [Test, Category("Unit")]
        public void GivenEventPassWithLifetimeElevenDays_WhenAdjustingEventPassQuality_ThenItShouldReturnCorrectProduct()
        {
            // arrange
            IProduct product = new Product(_qualityAdjustment, FakeItem.Instance("Backstage passes to a TAFKAL80ETC concert", 11, 10));

            // act
            IProduct actual = product.WithAdjustedQuality();

            // assert
            actual.ToString().Should().Be("Backstage passes to a TAFKAL80ETC concert, 11, 11");
        }

        [Test, Category("Unit")]
        public void GivenEventPassWithLifetimeNineDays_WhenAdjustingEventPassQuality_ThenItShouldReturnCorrectProduct()
        {
            // arrange
            IProduct product = new Product(_qualityAdjustment, FakeItem.Instance("Backstage passes to a TAFKAL80ETC concert", 9, 10));

            // act
            IProduct actual = product.WithAdjustedQuality();

            // assert
            actual.ToString().Should().Be("Backstage passes to a TAFKAL80ETC concert, 9, 12");
        }

        [Test, Category("Unit")]
        public void GivenEventPassWithLifetimeFourDays_WhenAdjustingEventPassQuality_ThenItShouldReturnCorrectProduct()
        {
            // arrange
            IProduct product = new Product(_qualityAdjustment, FakeItem.Instance("Backstage passes to a TAFKAL80ETC concert", 4, 10));

            // act
            IProduct actual = product.WithAdjustedQuality();

            // assert
            actual.ToString().Should().Be("Backstage passes to a TAFKAL80ETC concert, 4, 13");
        }

        [Test, Category("Unit")]
        public void GivenEventPassWithLifetimeFiveDaysAndFortyNineQuality_WhenAdjustingEventPassQuality_ThenItShouldReturnCorrectProduct()
        {
            // arrange
            IProduct product = new Product(_qualityAdjustment, FakeItem.Instance("Backstage passes to a TAFKAL80ETC concert", 5, 49));

            // act
            IProduct actual = product.WithAdjustedQuality();

            // assert
            actual.ToString().Should().Be("Backstage passes to a TAFKAL80ETC concert, 5, 50");
        }

        [Test, Category("Unit")]
        public void GivenEventPassWithLifetimeFiveDaysAndMaxQuality_WhenAdjustingEventPassQuality_ThenItShouldNotAffectProduct()
        {
            // arrange
            IProduct product = new Product(_qualityAdjustment, FakeItem.Instance("Backstage passes to a TAFKAL80ETC concert", 5, 50));

            // act
            IProduct actual = product.WithAdjustedQuality();

            // assert
            actual.Should().Be(product);
        }

        [Test, Category("Unit")]
        public void GivenCommonItemWithLifetimeAndQuality_WhenAdjustingEventPassQuality_ThenItShouldNotAffectProduct()
        {
            // arrange
            IProduct product = new Product(_qualityAdjustment, FakeItem.Instance("Large Sack", 10, 10));

            // act
            IProduct actual = product.WithAdjustedQuality();

            // assert
            actual.Should().Be(product);
        }
    }
}