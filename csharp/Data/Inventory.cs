using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using csharp.Models;

namespace csharp.Data
{
    public interface IInventory
    {
        List<IProduct> Products();
    }

    public class Inventory : IInventory
    {
        public List<IProduct> Products()
        {
            List<IProduct> products = (List<IProduct>) MemoryCache.Default.Get("Inventory");
            if (products != null) return products;

            products = Items().Select(i => (IProduct) new Product(i.Name, i.Quality, i.SellIn)).ToList();
            MemoryCache.Default.Set("Inventory", products, DateTimeOffset.MaxValue);

            return products;
        }

        private IEnumerable<Item> Items()
        {
            return new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };
        }
    }
}