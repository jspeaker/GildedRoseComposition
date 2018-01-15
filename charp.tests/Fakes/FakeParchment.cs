using csharp.Materials;
using System.Collections.Generic;

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