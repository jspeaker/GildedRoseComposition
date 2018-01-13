using csharp.Models;
using csharp.Strategies;
using csharp.tests.Fakes;
using FluentAssertions;
using NUnit.Framework;

namespace csharp.tests.Strategies
{
    [TestFixture]
    public class DefaultQualityAdjustmentTests
    {
        private IQualityAdjustmentStrategy _qualityAdjustment;

        [SetUp]
        public void Setup()
        {
            _qualityAdjustment = new DefaultQualityAdjustment();
        }

        [Test, Category("Unit")]
        public void ShouldNotAffectProduct()
        {
            // arrange
            IProduct product = new Product(_qualityAdjustment, FakeItem.Instance());

            // act
            IProduct actual = product.WithAdjustedQuality();

            // assert
            actual.Should().Be(product);
        }
    }
}