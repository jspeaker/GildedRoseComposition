using System.Collections.Generic;
using System.Linq;
using ApprovalUtilities.Utilities;
using csharp.Products;
using csharp.Specialists;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests.Specialists
{
    [TestClass]
    public class AccountantTests
    {
        [TestMethod, TestCategory("Unit")]
        public void GivenSpecifiedNumberOfDays_ShouldWriteProjectionsReportOfCorrectLength()
        {
            FakeScribe fakeScribe = new FakeScribe();
            IAccountant accountant = new Accountant(new Inventory(), new Illusionist(), fakeScribe);
            accountant.WriteInventoryProjectionReport(10);

            fakeScribe.Inscriptions.Count.Should().Be(10);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenSpecifiedNumberOfDays_ProductsShouldVaryThroughoutReport()
        {
            const int days = 3;
            FakeScribe fakeScribe = new FakeScribe();
            IAccountant accountant = new Accountant(new Inventory(), new Illusionist(), fakeScribe);
            accountant.WriteInventoryProjectionReport(days);
            IEnumerable<IProduct> dayZeroProducts = fakeScribe.Inscriptions.GetValueOrDefault(0).ToList();
            IEnumerable<IProduct> dayOneProducts = fakeScribe.Inscriptions.GetValueOrDefault(1).ToList();
            IEnumerable<IProduct> dayTwoProducts = fakeScribe.Inscriptions.GetValueOrDefault(2).ToList();

            dayZeroProducts.First().Quality().Should().NotBe(dayOneProducts.First().Quality());
            dayOneProducts.First().Quality().Should().NotBe(dayTwoProducts.First().Quality());
        }
    }

    public class FakeScribe : IScribe
    {
        public Dictionary<int, IEnumerable<IProduct>> Inscriptions = new Dictionary<int, IEnumerable<IProduct>>();

        public void InscribeProductInformation(IEnumerable<IProduct> products, int day)
        {
            Inscriptions.Add(day, products);
        }
    }
}