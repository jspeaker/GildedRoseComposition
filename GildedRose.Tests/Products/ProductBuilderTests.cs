using System.Collections.Generic;
using System.Linq;
using csharp.Products;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests.Products
{
    [TestClass]
    public class ProductBuilderTests
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnProduct()
        {
            IProductBuilder productBuilder = new ProductBuilder();

            IProduct product = productBuilder.Build("name", 1, 2);

            product.Name().Should().Be("name");
            product.Quality().Should().Be(1);
            product.DaysToSell().Should().Be(2);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnProducts()
        {
            IProductBuilder productBuilder = new ProductBuilder();

            IList<IProduct> products = productBuilder.Build(new List<Item>
            {
                new Item{ Name = "name1", Quality = 1, SellIn = 2 },
                new Item{ Name = "name2", Quality = 2, SellIn = 4 },
            }).ToList();

            products.First().Name().Should().Be("name1");
            products.First().Quality().Should().Be(1);
            products.First().DaysToSell().Should().Be(2);

            products.Last().Name().Should().Be("name2");
            products.Last().Quality().Should().Be(2);
            products.Last().DaysToSell().Should().Be(4);
        }
    }
}