using csharp.NonPlayerCharacters;
using csharp.tests.Fakes;
using FluentAssertions;
using NUnit.Framework;

namespace csharp.tests.NonPlayerCharacters
{
    [TestFixture]
    public class MageTests
    {
        [Test, Category("Unit")]
        public void ShouldAgeProduct()
        {
            // arrange
            FakeInventory fakeInventory = new FakeInventory();
            IMage mage = new Mage(fakeInventory);

            // act
            mage.CastAgeProducts();

            // assert
            fakeInventory.Products()[0].ToString().Should().Be("Iron Spike, 19, 9");
        }
    }
}