using csharp.Models;
using csharp.Strategies;
using FluentAssertions;
using NUnit.Framework;

namespace csharp.tests.Strategies
{
    [TestFixture]
    public class AgedItemQualityAdjustmentTests
    {
        private IQualityAdjustmentStrategy _qualityAdjustment;

        [SetUp]
        public void Setup()
        {
            _qualityAdjustment = new AgedItemQualityAdjustment(new DefaultQualityAdjustment());
        }

        [Test, Category("Unit")]
        public void GivenAgedItemWithLifetimeAndQuality_WhenAdjustingAgedItemQuality_ThenItShouldReturnCorrectProduct()
        {
            // arrange
            IProduct product = new Product(_qualityAdjustment, FakeItem.Instance("Aged Brie", 10, 10));

            // act
            IProduct actual = product.WithAdjustedQuality();

            // assert
            actual.ToString().Should().Be("Aged Brie, 10, 11");
        }

        [Test, Category("Unit")]
        public void GivenAgedItemWithLifetimeAndMaximumQuality_WhenAdjustingAgedItemQuality_ThenItShouldNotAffectProduct()
        {
            // arrange
            IProduct product = new Product(_qualityAdjustment, FakeItem.Instance("Aged Brie", 10, 50));

            // act
            IProduct actual = product.WithAdjustedQuality();

            // assert
            actual.Should().Be(product);
        }

        [Test, Category("Unit")]
        public void GivenConjuredItem_WhenAdjustingAgedItemQuality_ThenItShouldNotAffectProduct()
        {
            // arrange
            IProduct product = new Product(_qualityAdjustment, FakeItem.Instance("Conjured Mana Cake", 10, 10));

            // act
            IProduct actual = product.WithAdjustedQuality();

            // assert
            actual.Should().Be(product);
        }

        [Test, Category("Unit")]
        public void GivenCommonItemWithLifetimeAndQuality_WhenAdjustingAgedItemQuality_ThenItShouldNotAffectProduct()
        {
            // arrange
            IProduct product = new Product(_qualityAdjustment, FakeItem.Instance("Large Sack", 10, 10));

            // act
            IProduct actual = product.WithAdjustedQuality();

            // assert
            actual.Should().Be(product);
        }

        [Test, Category("Unit")]
        public void GivenLegendaryItemWithLifetimeAndQuality_WhenAdjustingAgedItemQuality_ThenItShouldNotAffectProduct()
        {
            // arrange
            IProduct product = new Product(_qualityAdjustment, FakeItem.Instance("Sulfuras, Hand of Ragnaros", -1, 40));

            // act
            IProduct actual = product.WithAdjustedQuality();

            // assert
            actual.Should().Be(product);
        }

        [Test, Category("Unit")]
        public void GivenEventPassWithLifetimeAndQuality_WhenAdjustingAgedItemQuality_ThenItShouldNotAffectProduct()
        {
            // arrange
            IProduct product = new Product(_qualityAdjustment, FakeItem.Instance("Backstage passes to a TAFKAL80ETC concert", 10, 10));

            // act
            IProduct actual = product.WithAdjustedQuality();

            // assert
            actual.Should().Be(product);
        }
    }
}