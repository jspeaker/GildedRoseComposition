using System;

namespace csharp.NonPlayerCharacters
{
    public interface IShopkeeper
    {
        void Greet();
    }

    public class Shopkeeper : IShopkeeper
    {
        public void Greet()
        {
            Console.WriteLine("OMGHAI!");
        }
    }
}