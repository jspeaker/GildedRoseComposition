using csharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace GildedRose.Tests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod, TestCategory("Unit")]
        public void GivenProductShouldAdjustQuality()
        {
            IProduct product = new Product(new Item
            {
                Name = "Foo",
                Quality = 10,
                SellIn = 1
            });

            IProduct adjustedProduct = product.AdjustedProduct();

            adjustedProduct.Quality().Should().Be(9);
        }
    }
}
