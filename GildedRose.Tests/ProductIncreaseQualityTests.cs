using csharp;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests
{
    [TestClass]
    public class ProductIncreaseQualityTests
    {
        [TestMethod, TestCategory("Unit")]
        public void GivenNonCommonItemWithQualityIncreaseQualityShouldIncreaseQuality()
        {
            Item item = new Item { Name = "Aged Brie", SellIn = 2, Quality = 1 };
            IProduct product = new Product(item);

            IProduct newProduct = product.WithIncreasedQuality();
            newProduct.Quality().Should().Be(2);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenCommonItemWithNoQualityIncreaseQualityShouldIncreaseQuality()
        {
            Item item = new Item { Name = "Foo", SellIn = 2, Quality = 0 };
            IProduct product = new Product(item);

            IProduct newProduct = product.WithIncreasedQuality();
            newProduct.Quality().Should().Be(1);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenNonCommonItemWithQualityofFiftyIncreaseQualityShouldNotIncreaseQuality()
        {
            Item item = new Item { Name = "Aged Brie", SellIn = 2, Quality = 50 };
            IProduct product = new Product(item);

            IProduct newProduct = product.WithIncreasedQuality();
            newProduct.Quality().Should().Be(50);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenBackstagePassWith49QualityAndSellIn11IncreaseBackstagePassQualityShouldNotIncreaseValue()
        {
            Item item = new Item { Name = "Backstage pass", SellIn = 11, Quality = 49 };
            IProduct product = new Product(item);

            IProduct newProduct = product.EventTicketWithIncreasedQuality();

            newProduct.Quality().Should().Be(49);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenBackstagePassWith49QualityAndSellIn10IncreaseBackstagePassQualityShouldIncreaseValueBy1()
        {
            Item item = new Item { Name = "Backstage pass", SellIn = 10, Quality = 49 };
            IProduct product = new Product(item);

            IProduct newProduct = product.EventTicketWithIncreasedQuality();

            newProduct.Quality().Should().Be(50);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenBackstagePassWith49QualityAndSellIn5IncreaseBackstagePassQualityShouldIncreaseValueBy1()
        {
            Item item = new Item { Name = "Backstage pass", SellIn = 5, Quality = 49 };
            IProduct product = new Product(item);

            IProduct newProduct = product.EventTicketWithIncreasedQuality();

            newProduct.Quality().Should().Be(50);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenBackstagePassWith48QualityAndSellIn5IncreaseBackstagePassQualityShouldIncreaseValueBy2()
        {
            Item item = new Item { Name = "Backstage pass", SellIn = 5, Quality = 48 };
            IProduct product = new Product(item);

            IProduct newProduct = product.EventTicketWithIncreasedQuality();

            newProduct.Quality().Should().Be(50);
        }
    }
}