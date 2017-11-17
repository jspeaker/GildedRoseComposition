using System.Collections.Generic;
using csharp.Logging;
using csharp.Products;
using csharp.Specialists;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests.Specialists
{
    [TestClass]
    public class ScribeTests
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldInscribeTheDay()
        {
            FakeLog fakeLog = new FakeLog();
            Scribe scribe = new Scribe(fakeLog);
            scribe.InscribeProductInformation(new List<IProduct>
            {
                new Product(new Item
                {
                    Name = "name",
                    Quality = 1,
                    SellIn = 2
                })
            }, 3);

            fakeLog.Messages[0].Should().Be("-------- day 3 --------");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldInscribeTheHeader()
        {
            FakeLog fakeLog = new FakeLog();
            Scribe scribe = new Scribe(fakeLog);
            scribe.InscribeProductInformation(new List<IProduct>
            {
                new Product(new Item
                {
                    Name = "name",
                    Quality = 1,
                    SellIn = 2
                })
            }, 3);

            fakeLog.Messages[1].Should().Be("name, sellIn, quality");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldInscribeTheProductInformation()
        {
            FakeLog fakeLog = new FakeLog();
            Scribe scribe = new Scribe(fakeLog);
            scribe.InscribeProductInformation(new List<IProduct>
            {
                new Product(new Item
                {
                    Name = "name",
                    Quality = 1,
                    SellIn = 2
                })
            }, 3);

            fakeLog.Messages[2].Should().Be("name, 2, 1");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldInscribeBlankLine()
        {
            FakeLog fakeLog = new FakeLog();
            Scribe scribe = new Scribe(fakeLog);
            scribe.InscribeProductInformation(new List<IProduct>
            {
                new Product(new Item
                {
                    Name = "name",
                    Quality = 1,
                    SellIn = 2
                })
            }, 3);

            fakeLog.Messages[3].Should().Be(string.Empty);
        }
    }

    public class FakeLog : ILog
    {
        public List<string> Messages = new List<string>();

        public void Print(string message)
        {
            Messages.Add(message);
        }
    }
}