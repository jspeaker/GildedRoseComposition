using System.Collections.Generic;
using csharp.Logging;

namespace GildedRose.Tests.Logging
{
    public class FakeLogDestination : ILogDestination
    {
        public List<string> Messages = new List<string>();

        public void WriteLine(string message)
        {
            Messages.Add(message);
        }
    }
}