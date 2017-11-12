using System;

namespace csharp.Logging
{
    public interface ILogDestination
    {
        void WriteLine(string message);
    }

    public class ConsoleWrapper : ILogDestination
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}