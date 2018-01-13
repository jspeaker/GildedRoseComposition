using System.Collections.Generic;
using csharp.NonPlayerCharacters;
using NUnit.Framework;
using FluentAssertions;

namespace csharp.tests.NonPlayerCharacters
{
    [TestFixture]
    public class BankerTests
    {
        [Test, Category("Unit")]
        public void ShouldDelegateJobsToOtherNpcs
            ()
        {
            // arrange
            FakeMage fakeMage = new FakeMage();
            FakeScribe fakeScribe = new FakeScribe();
            IBanker banker = new Banker( fakeMage, fakeScribe);

            // act
            banker.Report(10);

            // assert
            fakeMage.ProductsAged.Should().HaveCount(10);
            fakeScribe.DaysWritten.Should().HaveCount(10);
        }
    }

    public class FakeMage : IMage
    {
        public List<bool> ProductsAged = new List<bool>();

        public void CastAgeProducts()
        {
            ProductsAged.Add(true);
        }
    }

    public class FakeScribe : IScribe
    {
        public List<int> DaysWritten = new List<int>();

        public void LetItBeWritten(int day)
        {
            DaysWritten.Add(day);
        }
    }
}