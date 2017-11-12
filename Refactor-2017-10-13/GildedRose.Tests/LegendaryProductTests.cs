using csharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace GildedRose.Tests
{
    [TestClass]
    public class LegendaryProductTests
    {
        [TestMethod, TestCategory("Unit")]
        public void GivenLegendaryProductWithQualityEightyShouldNotAdjustQuality()
        {
            IProduct product = new Product(new Item
            {
                Name = "Sulfuras, Hand of Ragnaros",
                Quality = 80,
                SellIn = 1
            });

            IProduct adjustedProduct = product.AdjustedProduct();

            adjustedProduct.Quality().Should().Be(80);
        }
    }
}
