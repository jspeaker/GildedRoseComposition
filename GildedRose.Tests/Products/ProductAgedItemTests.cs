﻿using csharp.Products;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests.Products
{
    [TestClass]
    public class ProductAgedItemTests
    {
        [TestMethod, TestCategory("Unit")]
        public void GivenAgedItemeShouldReturnTrue()
        {
            Item item = new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 };
            IProduct product = new Product(item);

            bool agedItem = product.Aged();
            agedItem.Should().BeTrue();
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenNonAgedItemShouldReturnFalse()
        {
            Item item = new Item { Name = "Foo", SellIn = 0, Quality = 50 };
            IProduct product = new Product(item);

            bool agedItem = product.Aged();
            agedItem.Should().BeFalse();
        }
    }
}