using System;

namespace csharp.Materials
{
    public class Parchment : IParchment
    {
        public void Inscribe(string message)
        {
            Console.WriteLine(message);
        }
    }
}