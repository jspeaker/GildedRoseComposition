using csharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace GildedRose.Tests
{
    [TestClass]
    public class AgedProductTests
    {
        [TestMethod, TestCategory("Unit")]
        public void GivenAgedProductWithQualityTwentyShouldAdjustQualityToTwentyOne()
        {
            IProduct product = new Product(new Item
            {
                Name = "Aged Brie",
                Quality = 20,
                SellIn = 1
            });

            IProduct adjustedProduct = product.AdjustedProduct();

            adjustedProduct.Quality().Should().Be(21);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenAgedProductWithQualityFiftyShouldNotAdjustQuality()
        {
            IProduct product = new Product(new Item
            {
                Name = "Aged Brie",
                Quality = 50,
                SellIn = 1
            });

            IProduct adjustedProduct = product.AdjustedProduct();

            adjustedProduct.Quality().Should().Be(50);
        }
    }
}
