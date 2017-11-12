using System;
using csharp.Specialists;

namespace csharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new ShopKeep().Greet();
            new Illusionist().CastAgeProducts(31);
            Console.ReadLine();
        }
    }
}
