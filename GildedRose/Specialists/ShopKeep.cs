using System;

namespace csharp.Specialists
{
    public interface IShopKeep
    {
        void Greet();
    }

    public class ShopKeep : IShopKeep
    {
        public void Greet()
        {
            Console.WriteLine("OMGHAI!");
        }
    }
}