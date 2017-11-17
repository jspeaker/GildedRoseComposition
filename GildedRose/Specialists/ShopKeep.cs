using System;
using csharp.Logging;

namespace csharp.Specialists
{
    public interface IShopKeep
    {
        void Greet();
    }

    public class ShopKeep : IShopKeep
    {
        private readonly ILogDestination _logDestination;

        public ShopKeep() : this(new ConsoleWrapper()) { }

        public ShopKeep(ILogDestination logDestination)
        {
            _logDestination = logDestination;
        }

        public void Greet()
        {
            _logDestination.WriteLine("OMGHAI!");
        }
    }
}