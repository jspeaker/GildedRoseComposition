using System.Collections.Generic;
using System.Linq;
using csharp.Products;
using NUnit.Framework;

namespace GildedRose.Tests.Products
{
    [TestFixture]
    public class ProductLifeTests
    {
        [Test]
        public void ShouldReturnItemWithCorrectProperties()
        {
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            IEnumerable<IProduct> products = new ProductBuilder().Build(items);
            IProductLife productProductLife = new ProductLife();

            List<IProduct> actual = productProductLife.WithIncreasedAge(products).ToList();

            Assert.AreEqual("foo", actual.First().Name());
            Assert.AreEqual(-1, actual.First().DaysToSell());
            Assert.AreEqual(0, actual.First().Quality());
        }
    }
}
