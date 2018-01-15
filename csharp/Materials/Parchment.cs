using System;

namespace csharp.Materials
{
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