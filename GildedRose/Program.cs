using System;
using csharp.Specialists;

namespace csharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new ShopKeep().Greet();
            new Accountant().WriteInventoryProjectionReport(31);

            Console.ReadLine();
        }
    }
}
