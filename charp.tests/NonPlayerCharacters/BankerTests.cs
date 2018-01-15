using csharp.NonPlayerCharacters;
using csharp.tests.Fakes;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

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
            FakeScrivener fakeScrivener = new FakeScrivener();
            IBanker banker = new Banker(fakeMage, fakeScrivener, new FakeInventory());

            // act
            banker.Report(10);

            // assert
            fakeMage.ProductsAged.Should().HaveCount(10);
            fakeScrivener.Messages.Should().HaveCount(40);
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

    public class FakeScrivener : IScrivener
    {
        public List<int> DaysWritten = new List<int>();
        public List<string> Messages = new List<string>();

        public void LetItBeWritten(int day)
        {
            DaysWritten.Add(day);
        }

        public void Inscribe(string message)
        {
            Messages.Add(message);
        }
    }
}