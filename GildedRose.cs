using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                IProduct product = new Product(item);

                item.Quality = product.ReducedQualityProduct().Quality();
                item.Quality = product.IncreasedQualityProduct().Quality();
                item.Quality = product.IncreasedQualityBackstagePass().Quality();

                if (!product.Legendary())
                {
                    item.SellIn = item.SellIn - 1;
                }

                if (item.SellIn < 0)
                {
                    if (!product.Cheese())
                    {
                        if (!product.BackstagePass())
                        {
                            if (product.Quality() > 0)
                            {
                                if (!product.Legendary())
                                {
                                    item.Quality = product.Quality() - 1;
                                }
                            }
                        }
                        else
                        {
                            item.Quality = 0;
                        }
                    }
                    else
                    {
                        if (product.Quality() < 50)
                        {
                            item.Quality = product.Quality() + 1;
                        }
                    }
                }
            }
        }
    }
}
