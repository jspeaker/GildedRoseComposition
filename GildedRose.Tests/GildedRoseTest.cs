using System.Collections.Generic;
using csharp;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void ShouldReturnItemWithCorrectSellInTimeframe()
        {
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            csharp.GildedRose app = new csharp.GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual("foo", items[0].Name);
            Assert.AreEqual(-1, items[0].SellIn);
        }
    }
}
