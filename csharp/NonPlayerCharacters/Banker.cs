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
        private readonly IScribe _scribe;

        public Banker() : this(new Inventory())  { }

        private Banker(IInventory inventory) : this(new Mage(inventory), new Scribe(inventory)) { }

        public Banker(IMage mage, IScribe scribe)
        {
            _mage = mage;
            _scribe = scribe;
        }

        public void Report(int daysToReport)
        {
            for (int day = 0; day < daysToReport; day++)
            {
                _scribe.LetItBeWritten(day);
                _mage.CastAgeProducts();
            }
        }
    }
}