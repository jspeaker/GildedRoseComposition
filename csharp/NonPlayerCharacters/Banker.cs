using csharp.Data;

namespace csharp.NonPlayerCharacters
{
    public interface IBanker
    {
        void Report(int daysToReport);
    }

    public class Banker : IBanker
    {
        private readonly IMage _mage;
        private readonly IScrivener _scrivener;
        private readonly IInventory _inventory;

        public Banker() : this(new Inventory())  { }

        private Banker(IInventory inventory) : this(new Mage(inventory), new Scribe(), inventory) { }

        public Banker(IMage mage, IScrivener scrivener, IInventory inventory)
        {
            _mage = mage;
            _scrivener = scrivener;
            _inventory = inventory;
        }

        public void Report(int daysToReport)
        {
            for (int day = 0; day < daysToReport; day++)
            {
                _scrivener.Inscribe("-------- day " + day + " --------");
                _scrivener.Inscribe("name, sellIn, quality");


                _inventory.Products().ForEach(p => _scrivener.Inscribe(p.ToString()));

                _scrivener.Inscribe(string.Empty);

                _mage.CastAgeProducts();
            }
        }
    }
}