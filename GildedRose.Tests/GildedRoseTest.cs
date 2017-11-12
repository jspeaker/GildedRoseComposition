using System.Collections.Generic;
using System.Linq;
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

            List<Item> updatedItems = app.UpdateQuality().ToList();

            Assert.AreEqual("foo", updatedItems[0].Name);
            Assert.AreEqual(-1, updatedItems[0].SellIn);
        }
    }
}
