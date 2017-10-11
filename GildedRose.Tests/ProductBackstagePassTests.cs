using csharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace GildedRose.Tests
{
    [TestClass]
    public class ProductBackstagePassTests
    {
        [TestMethod, TestCategory("Unit")]
        public void GivenBackstagePassItemBackstagePassShouldReturnTrue()
        {
            Item item = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 15,
                Quality = 20
            };
            Product product = new Product(item);

            bool backstagePass = product.BackstagePass();
            backstagePass.Should().BeTrue();
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenNonBackstagePassBackstagePassShouldReturnFalse()
        {
            Item item = new Item
            {
                Name = "Foo",
                SellIn = 15,
                Quality = 20
            };
            Product product = new Product(item);

            bool backstagePass = product.BackstagePass();
            backstagePass.Should().BeFalse();
        }
    }
}