using System.Collections.Generic;
using csharp.NonPlayerCharacters;

namespace csharp.tests.Fakes
{
    public class FakeParchment : IParchment
    {
        public List<string> Inscriptions = new List<string>();

        public void Inscribe(string message)
        {
            Inscriptions.Add(message);
        }
    }
}