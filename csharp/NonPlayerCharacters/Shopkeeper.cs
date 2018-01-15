namespace csharp.NonPlayerCharacters
{
    public interface IShopkeeper
    {
        void Greet();
    }

    public class Shopkeeper : IShopkeeper
    {
        private readonly IScrivener _scrivener;

        public Shopkeeper() : this(new Scribe()) { }

        public Shopkeeper(IScrivener scrivener)
        {
            _scrivener = scrivener;
        }

        public void Greet()
        {
            _scrivener.Inscribe("OMGHAI!");
        }
    }
}