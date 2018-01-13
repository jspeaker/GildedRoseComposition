namespace csharp.NonPlayerCharacters
{
    public interface IShopkeeper
    {
        void Greet();
    }

    public class Shopkeeper : IShopkeeper
    {
        private readonly IParchment _parchment;

        public Shopkeeper() : this(new Parchment()) { }

        public Shopkeeper(IParchment parchment)
        {
            _parchment = parchment;
        }

        public void Greet()
        {
            _parchment.Inscribe("OMGHAI!");
        }
    }
}