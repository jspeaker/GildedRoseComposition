using csharp.Models;

namespace csharp.tests
{
    public static class FakeItem
    {
        public static Item Instance(string name = "foo", int sellIn = 1, int quality = 1)
        {
            return new Item { Name = name, SellIn = sellIn, Quality = quality };
        }
    }
}