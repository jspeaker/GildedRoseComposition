using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        private readonly IList<Item> _items;

        public GildedRose(IList<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in _items)
            {
                IProduct product = new Product(item);

                item.Quality = product.WithReducedQuality().Quality();
                item.Quality = product.WithIncreasedQuality().Quality();
                item.Quality = product.EventTicketWithIncreasedQuality().Quality();

                item.SellIn = product.WithReducedSellIn().Item().SellIn;

                item.Quality = product.Expired().Quality();
            }
        }
    }
}
