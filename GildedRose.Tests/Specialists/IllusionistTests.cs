using System.Collections.Generic;
using System.Linq;
using csharp.Products;
using csharp.Specialists;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests.Specialists
{
    [TestClass]
    public class IllusionistTests
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldAgeProducts()
        {
            IIllusionist illusionist = new Illusionist();
            List<IProduct> products = new List<IProduct>()
            {
                new Product(new Item
                {
                    Name = "name",
                    Quality = 10,
                    SellIn = 10
                })
            };
            IList<IProduct> agedProducts = illusionist.CastAgeProducts(products);

            products.Should().NotBeSameAs(agedProducts);

            agedProducts.First().Name().Should().Be(products.First().Name());
            agedProducts.First().DaysToSell().Should().Be(9);
            agedProducts.First().Quality().Should().Be(9);
        }
    }
}