using csharp.Materials;

namespace csharp.NonPlayerCharacters
{
    public interface IScrivener
    {
        void Inscribe(string message);
    }

    public class Scribe : IScrivener
    {
        private readonly IParchment _parchment;

        public Scribe() : this((IParchment) new Parchment()) { }

        public Scribe(IParchment parchment)
        {
            _parchment = parchment;
        }

        public void Inscribe(string message)
        {
            _parchment.Inscribe(message);
        }
    }
}