using System.Collections.Generic;
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
            FakeLog logDestination = new FakeLog();
            ILog log = new Log(logDestination);

            log.Print("message");

            logDestination.Messages.First().Should().Be("message");
        }
    }

    public class FakeLog : ILogDestination
    {
        public List<string> Messages = new List<string>();

        public void WriteLine(string message)
        {
            Messages.Add(message);
        }
    }
}