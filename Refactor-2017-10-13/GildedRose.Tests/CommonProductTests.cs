using csharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace GildedRose.Tests
{
    [TestClass]
    public class CommonProductTests
    {
        [TestMethod, TestCategory("Unit")]
        public void GivenCommonProductWithQualityTwentyShouldAdjustQualityToNineteen()
        {
            IProduct product = new Product(new Item
            {
                Name = "Foo",
                Quality = 20,
                SellIn = 1
            });

            IProduct adjustedProduct = product.AdjustedProduct();

            adjustedProduct.Quality().Should().Be(19);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenCommonProductWithQualityZeroShouldNotAdjustQuality()
        {
            IProduct product = new Product(new Item
            {
                Name = "Foo",
                Quality = 0,
                SellIn = 1
            });

            IProduct adjustedProduct = product.AdjustedProduct();

            adjustedProduct.Quality().Should().Be(0);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenExpiredCommonProductWithQualityAdjustedQualityNineteenShouldAdjustQualityToEighteen()
        {
            IProduct product = new Product(new Item
            {
                Name = "Foo",
                Quality = 20,
                SellIn = -1
            });

            IProduct adjustedProduct = product.AdjustedProduct();

            adjustedProduct.Quality().Should().Be(18);
        }
    }
}
