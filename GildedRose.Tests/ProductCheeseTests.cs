﻿using csharp;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests
{
    [TestClass]
    public class ProductCheeseTests
    {
        [TestMethod, TestCategory("Unit")]
        public void GivenCheeseItemCheeseShouldReturnTrue()
        {
            Item item = new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 };
            IProduct product = new Product(item);

            bool cheese = product.Cheese();
            cheese.Should().BeTrue();
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenNonCheeseItemCheeseShouldReturnTrue()
        {
            Item item = new Item { Name = "Foo", SellIn = 0, Quality = 50 };
            IProduct product = new Product(item);

            bool cheese = product.Cheese();
            cheese.Should().BeFalse();
        }
    }
}