using csharp.Models;
using csharp.Strategies;
using FluentAssertions;
using NUnit.Framework;

namespace csharp.tests.Strategies
{
    [TestFixture]
    public class CommonQualityAdjustmentTests
    {
        private IQualityAdjustmentStrategy _qualityAdjustment;

        [SetUp]
        public void Setup()
        {
            _qualityAdjustment = new CommonQualityAdjustment(new DefaultQualityAdjustment());
        }

        [Test, Category("Unit")]
        public void GivenCommonItemWithLifetimeAndQuality_WhenAdjustingCommonQuality_ThenItShouldReturnCorrectProduct()
        {
            // arrange
            IProduct product = new Product(_qualityAdjustment, FakeItem.Instance("Torch", 5, 2));

            // act
            IProduct actual = product.WithAdjustedQuality();

            // assert
            actual.ToString().Should().Be("Torch, 5, 1");
        }

        [Test, Category("Unit")]
        public void GivenCommonItemWithLifetimeAndZeroQuality_WhenAdjustingCommonQuality_ThenItShouldReturnCorrectProduct()
        {
            // arrange
            IProduct product = new Product(_qualityAdjustment, FakeItem.Instance("Torch", 5, 0));

            // act
            IProduct actual = product.WithAdjustedQuality();

            // assert
            actual.ToString().Should().Be("Torch, 5, 0");
        }

        [Test, Category("Unit")]
        public void GivenConjuredItemWithLifetimeAndQuality_WhenAdjustingCommonQuality_ThenItShouldNotAffectProduct()
        {
            // arrange
            IProduct product = new Product(_qualityAdjustment, FakeItem.Instance("Conjured Mana Cake", 5, 5));

            // act
            IProduct actual = product.WithAdjustedQuality();

            // assert
            actual.Should().Be(product);
        }

        [Test, Category("Unit")]
        public void GivenEventPassWithLifetimeAndQuality_WhenAdjustingCommonQuality_ThenItShouldNotAffectProduct()
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