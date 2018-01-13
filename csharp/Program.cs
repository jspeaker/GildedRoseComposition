using System;
using csharp.NonPlayerCharacters;

namespace csharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new Shopkeeper().Greet();
            new Banker().Report(31);
            Console.Read();
        }
    }
}
