using csharp;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests
{
    [TestClass]
    public class ProductExpiredTests
    {
        [TestMethod, TestCategory("Unit")]
        public void GivenCommonExpiredItemShouldReduceQuality()
        {
            Item item = new Item { Name = "Foo", SellIn = -1, Quality = 50 };
            IProduct product = new Product(item);

            IProduct actual = product.WithExpirationAdjustment();

            actual.Quality().Should().Be(49);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenConjuredExpiredItemShouldReduceQualityByTwo()
        {
            Item item = new Item { Name = "Conjured", SellIn = -1, Quality = 50 };
            IProduct product = new Product(item);

            IProduct actual = product.WithExpirationAdjustment();

            actual.Quality().Should().Be(48);
        }
        
        [TestMethod, TestCategory("Unit")]
        public void GivenCommonExpiredItemWithNoQualityShouldNotReduceQuality()
        {
            Item item = new Item { Name = "Foo", SellIn = -1, Quality = 0 };
            IProduct product = new Product(item);

            IProduct actual = product.WithExpirationAdjustment();

            actual.Quality().Should().Be(0);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenCommonNonExpiredItemShouldNotReduceQuality()
        {
            Item item = new Item { Name = "Foo", SellIn = 0, Quality = 50 };
            IProduct product = new Product(item);

            IProduct actual = product.WithExpirationAdjustment();

            actual.Quality().Should().Be(50);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenExpiredEventTicketItemQualityShouldBeReducedToZero()
        {
            Item item = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = -1,
                Quality = 20
            };
            Product product = new Product(item);

            IProduct actual = product.WithExpirationAdjustment();

            actual.Quality().Should().Be(0);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenExpiredAgedItemWithNonMaxQualityShouldIncreaseQuality()
        {
            Item item = new Item
            {
                Name = "Aged Brie",
                SellIn = -1,
                Quality = 0
            };
            IProduct product = new Product(item);

            IProduct actual = product.WithExpirationAdjustment();

            actual.Quality().Should().Be(1);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenExpiredAgedItemWithMaxQualityShouldNotIncreaseQuality()
        {
            Item item = new Item
            {
                Name = "Aged Brie",
                SellIn = -1,
                Quality = 50
            };
            IProduct product = new Product(item);

            IProduct actual = product.WithExpirationAdjustment();

            actual.Quality().Should().Be(50);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenExpiredLegendaryItemShouldNotReduceQuality()
        {
            Item item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 };
            IProduct product = new Product(item);

            IProduct actual = product.WithExpirationAdjustment();
            actual.Quality().Should().Be(80);
        }
    }
}