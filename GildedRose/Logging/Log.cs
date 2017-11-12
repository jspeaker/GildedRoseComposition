namespace csharp.Logging
{
    public interface ILog
    {
        void Print(string message);
    }

    public class Log : ILog
    {
        private readonly ILogDestination _logDestination;

        public Log() : this(new ConsoleWrapper()) { }

        public Log(ILogDestination logDestination)
        {
            _logDestination = logDestination;
        }

        public void Print(string message)
        {
            _logDestination.WriteLine(message);
        }
    }
}