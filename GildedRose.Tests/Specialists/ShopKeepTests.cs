using csharp.Specialists;
using FluentAssertions;
using GildedRose.Tests.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests.Specialists
{
    [TestClass]
    public class ShopKeepTests
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldGreet()
        {
            FakeLogDestination fakeLogDestination = new FakeLogDestination();
            IShopKeep shopKeep = new ShopKeep(fakeLogDestination);
            shopKeep.Greet();
            fakeLogDestination.Messages[0].Should().Be("OMGHAI!");
        }
    }
}