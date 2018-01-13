using System;
using csharp.Strategies;

namespace csharp.Models
{
    public interface IProduct
    {
        IProduct AgedProduct();
        IProduct WithAdjustedQuality();
        IProduct WithAdjustedQuality(int qualityAddend);

        string ToString();

        bool Is(ProductCategory category);

        int EventPassQualityAddend();
    }

    public class Product : IProduct
    {
        private readonly IQualityAdjustmentStrategy _qualityAdjustmentStrategy;
        private readonly Item _item;

        private const int MaximumQuality = 50;
        private const int MinimumQuality = 0;

        public Product(string name, int quality, int lifetime) : this(new Item { Name = name, Quality = quality, SellIn = lifetime }) { }

        private Product(Item item) : this(new CommonQualityAdjustment(), item) { }

        public Product(IQualityAdjustmentStrategy qualityAdjustmentStrategy, Item item)
        {
            _qualityAdjustmentStrategy = qualityAdjustmentStrategy;
            _item = item;
        }

        public IProduct AgedProduct()
        {
            if (Legendary()) return this;

            return new Product(_item.Name, _item.Quality, _item.SellIn - 1);
        }

        public IProduct WithAdjustedQuality()
        {
            return _qualityAdjustmentStrategy.WithAdjustment(this);
        }

        public IProduct WithAdjustedQuality(int qualityAddend)
        {
            if (qualityAddend == MinimumQuality) return this;

            int adjustedQuality = _item.Quality + QualityAddendWithExpirationRule(qualityAddend);
            if (AdjustedQualityAtLowerThreshold(adjustedQuality) || AdjustedQualityAtUpperThreshold(adjustedQuality)) return this;

            return new Product(_item.Name, Math.Min(MaximumQuality, adjustedQuality), _item.SellIn);
        }

        public bool Is(ProductCategory category)
        {
            return Category().Equals(category);
        }

        public int EventPassQualityAddend()
        {
            if (_item.SellIn < 0) return -_item.Quality;
            if (AtQualityMaximum()) return 0;
            if (_item.SellIn > 9) return 1;
            if (_item.SellIn > 4) return 2;
            return 3;
        }

        private int QualityAddendWithExpirationRule(int qualityAddend)
        {
            if (_item.SellIn > -1) return qualityAddend;
            if (EventPass()) return qualityAddend;

            return qualityAddend * 2;
        }

        private bool AdjustedQualityAtUpperThreshold(int adjustedQuality)
        {
            return AtQualityMaximum() && adjustedQuality > MaximumQuality;
        }

        private bool AtQualityMaximum()
        {
            return _item.Quality > 49;
        }

        private bool AdjustedQualityAtLowerThreshold(int adjustedQuality)
        {
            return _item.Quality <= MinimumQuality && adjustedQuality < MinimumQuality;
        }

        public override string ToString()
        {
            return $"{_item.Name}, {_item.SellIn}, {_item.Quality}";
        }

        private ProductCategory Category()
        {
            if (AgedItem()) return ProductCategory.AgedItem;
            if (Conjured()) return ProductCategory.Conjured;
            if (EventPass()) return ProductCategory.EventPass;
            if (Legendary()) return ProductCategory.Legendary;
            return ProductCategory.Common;
        }

        private bool AgedItem()
        {
            return _item.Name.IndexOf("brie", StringComparison.CurrentCultureIgnoreCase) > -1;
        }

        private bool EventPass()
        {
            return _item.Name.IndexOf("concert", StringComparison.CurrentCultureIgnoreCase) > -1;
        }

        private bool Legendary()
        {
            return _item.Name.IndexOf("sulfuras", StringComparison.CurrentCultureIgnoreCase) > -1;
        }

        private bool Conjured()
        {
            return _item.Name.IndexOf("conjured", StringComparison.CurrentCultureIgnoreCase) > -1;
        }
    }
}