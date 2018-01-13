using csharp.Models;
using csharp.Strategies;
using FluentAssertions;
using NUnit.Framework;

namespace csharp.tests.Strategies
{
    [TestFixture]
    public class ConjurationQualityAdjustmentTests
    {
        private IQualityAdjustmentStrategy _qualityAdjustment;

        [SetUp]
        public void Setup()
        {
            _qualityAdjustment = new ConjurationQualityAdjustment(new DefaultQualityAdjustment());
        }

        [Test, Category("Unit")]
        public void GivenConjuredItem_WhenAdjustingConjuredProductQuality_ThenItShouldReturnCorrectProduct()
        {
            // arrange
            IProduct product = new Product(_qualityAdjustment, FakeItem.Instance("Conjured Mana Cake", 10, 10));

            // act
            IProduct actual = product.WithAdjustedQuality();

            // assert
            actual.ToString().Should().Be("Conjured Mana Cake, 10, 8");
        }

        [Test, Category("Unit")]
        public void GivenConjuredItemZeroQuality_WhenAdjustingConjuredQuality_ThenItShouldNotAffectProduct()
        {
            // arrange
            IProduct product = new Product(_qualityAdjustment, FakeItem.Instance("Conjured Mana Cake", 10, 0));

            // act
            IProduct actual = product.WithAdjustedQuality();

            // assert
            actual.Should().Be(product);
        }

        [Test, Category("Unit")]
        public void GivenNonConjuredItem_WhenAdjustingConjuredProductQuality_ThenItShouldNotAffectProduct()
        {
            // arrange
            IProduct product = new Product(_qualityAdjustment, FakeItem.Instance("Copper Ingot", 10, 10));

            // act
            IProduct actual = product.WithAdjustedQuality();

            // assert
            actual.Should().Be(product);
        }
    }
}