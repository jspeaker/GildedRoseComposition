using csharp;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests
{
    [TestClass]
    public class ProductReduceQualityTests
    {
        [TestMethod, TestCategory("Unit")]
        public void GivenNormalItemWithQualityReduceQualityShouldReduceQualityOfProduct()
        {
            Item item = new Item { Name = "Foo", SellIn = 2, Quality = 50 };
            IProduct product = new Product(item);

            IProduct newProduct = product.WithReducedQuality();
            newProduct.Quality().Should().Be(49);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenNormalItemWithZeroQualityReduceQualityShouldNotReduceQualityOfProduct()
        {
            Item item = new Item { Name = "Foo", SellIn = 2, Quality = 0 };
            IProduct product = new Product(item);

            IProduct newProduct = product.WithReducedQuality();
            newProduct.Quality().Should().Be(0);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenLegendaryItemWithQualityReduceQualityShouldNotReduceQualityOfProduct()
        {
            Item item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };
            IProduct product = new Product(item);

            IProduct newProduct = product.WithReducedQuality();
            newProduct.Quality().Should().Be(80);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenCheeseItemWithQualityReduceQualityShouldNotReduceQualityOfProduct()
        {
            Item item = new Item { Name = "Aged Brie", SellIn = 2, Quality = 1 };
            IProduct product = new Product(item);

            IProduct newProduct = product.WithReducedQuality();
            newProduct.Quality().Should().Be(1);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenBackstagePassItemWithQualityReduceQualityShouldNotReduceQualityOfProduct()
        {
            Item item = new Item { Name = "Backstage pass", SellIn = 2, Quality = 1 };
            IProduct product = new Product(item);

            IProduct newProduct = product.WithReducedQuality();
            newProduct.Quality().Should().Be(1);
        }
    }
}