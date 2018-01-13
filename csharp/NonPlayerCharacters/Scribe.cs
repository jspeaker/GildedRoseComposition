using System;
using csharp.Data;

namespace csharp.NonPlayerCharacters
{
    public interface IScribe
    {
        void LetItBeWritten(int day);
    }

    public class Scribe : IScribe
    {
        private readonly IInventory _inventory;

        public Scribe(IInventory inventory)
        {
            _inventory = inventory;
        }

        public void LetItBeWritten(int day)
        {
            WriteHeader(day);
            WriteBody();
            WriteFooter();
        }

        private void WriteHeader(int day)
        {
            Console.WriteLine("-------- day " + day + " --------");
            Console.WriteLine("name, sellIn, quality");
        }

        private void WriteBody()
        {
            _inventory.Products().ForEach(p => Console.WriteLine(p.ToString()));
        }

        private static void WriteFooter()
        {
            Console.WriteLine("");
        }
    }
}