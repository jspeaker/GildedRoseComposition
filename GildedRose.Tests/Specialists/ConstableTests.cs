using csharp.Products;
using csharp.Specialists;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests.Specialists
{
    [TestClass]
    public class ConstableTests
    {
        [TestMethod, TestCategory("Unit")]
        public void GivenQualityUnderMax_ShouldNotAdjustQuality()
        {
            IConstable constable = new Constable();
            IProduct product = new Product(new Item
            {
                Name = "name",
                Quality = 49,
                SellIn = 10
            });

            IProduct actual = constable.EnforceMaximumQuality(product);

            actual.Should().Be(product);
            actual.Quality().Should().Be(49);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenQualityOverMax_ShouldAdjustQuality()
        {
            IConstable constable = new Constable();
            IProduct product = new Product(new Item
            {
                Name = "name",
                Quality = 51,
                SellIn = 10
            });

            IProduct actual = constable.EnforceMaximumQuality(product);

            actual.Should().NotBe(product);
            actual.Quality().Should().Be(50);
        }
    }
}