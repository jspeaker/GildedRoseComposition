using System.Linq;
using csharp.Logging;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests.Logging
{
    [TestClass]
    public class LogTests
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldPrintMessage()
        {
            FakeLogDestination logDestinationDestination = new FakeLogDestination();
            ILog log = new Log(logDestinationDestination);

            log.Print("message");

            logDestinationDestination.Messages.First().Should().Be("message");
        }
    }
}