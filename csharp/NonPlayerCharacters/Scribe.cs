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
        private readonly IParchment _parchment;

        public Scribe(IInventory inventory) : this(inventory, new Parchment()) { }

        public Scribe(IInventory inventory, IParchment parchment)
        {
            _inventory = inventory;
            _parchment = parchment;
        }

        public void LetItBeWritten(int day)
        {
            WriteHeader(day);
            WriteBody();
            WriteFooter();
        }

        private void WriteHeader(int day)
        {
            _parchment.Inscribe("-------- day " + day + " --------");
            _parchment.Inscribe("name, sellIn, quality");
        }

        private void WriteBody()
        {
            _inventory.Products().ForEach(p => _parchment.Inscribe(p.ToString()));
        }

        private void WriteFooter()
        {
            _parchment.Inscribe("");
        }
    }

    public interface IParchment
    {
        void Inscribe(string message);
    }

    public class Parchment : IParchment
    {
        public void Inscribe(string message)
        {
            Console.WriteLine(message);
        }
    }
}