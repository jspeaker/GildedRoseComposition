using csharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace GildedRose.Tests
{
    [TestClass]
    public class ConcertTicketProductTests
    {
        [TestMethod, TestCategory("Unit")]
        public void GivenBackstagePassWithQualityOneShouldAdjustQualityToTwo()
        {
            IProduct product = new Product(new Item
            {
                Name = "Backstage pass",
                Quality = 1,
                SellIn = 30
            });

            IProduct adjustedProduct = product.AdjustedProduct();

            adjustedProduct.Quality().Should().Be(2);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenBackstagePassWithQualityFiftyShouldNotAdjustQuality()
        {
            IProduct product = new Product(new Item
            {
                Name = "Backstage pass",
                Quality = 50,
                SellIn = 1
            });

            IProduct adjustedProduct = product.AdjustedProduct();

            adjustedProduct.Quality().Should().Be(50);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenBackstagePassWithQualityTenAndSellInTenShouldAdjustQualityToTwelve()
        {
            IProduct product = new Product(new Item
            {
                Name = "Backstage pass",
                Quality = 10,
                SellIn = 10
            });

            IProduct adjustedProduct = product.AdjustedProduct();

            adjustedProduct.Quality().Should().Be(12);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenBackstagePassWithQualityTenAndSellInExpiredShouldAdjustQualityToZero()
        {
            IProduct product = new Product(new Item
            {
                Name = "Backstage pass",
                Quality = 10,
                SellIn = -1
            });

            IProduct adjustedProduct = product.AdjustedProduct();

            adjustedProduct.Quality().Should().Be(0);
        }
    }
}
