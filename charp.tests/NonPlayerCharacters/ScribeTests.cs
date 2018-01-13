using csharp.Data;
using csharp.NonPlayerCharacters;
using csharp.tests.Fakes;
using FluentAssertions;
using NUnit.Framework;

namespace csharp.tests.NonPlayerCharacters
{
    [TestFixture]
    public class ScribeTests
    {
        [Test, Category("Unit")]
        public void ShouldInscribeProductInformationForTheSpecifiedDay()
        {
            // arrange
            IInventory fakeInventory = new FakeInventory();
            FakeParchment fakeParchment = new FakeParchment();
            IScribe scribe = new Scribe(fakeInventory, fakeParchment);

            // act
            scribe.LetItBeWritten(10);

            // assert
            fakeParchment.Inscriptions.Should().HaveCount(4);
            fakeParchment.Inscriptions[0].Should().Be("-------- day 10 --------");
            fakeParchment.Inscriptions[1].Should().Be("name, sellIn, quality");
            fakeParchment.Inscriptions[2].Should().Be(fakeInventory.Products()[0].ToString());
            fakeParchment.Inscriptions[3].Should().Be(string.Empty);
        }
    }
}