using csharp.NonPlayerCharacters;
using FluentAssertions;
using NUnit.Framework;

namespace csharp.tests.NonPlayerCharacters
{
    [TestFixture]
    public class ShopkeeperTests
    {
        [Test, Category("Unit")]
        public void ShouldGreet()
        {
            // arrange
            FakeScrivener fakeScrivener = new FakeScrivener();
            IShopkeeper shopkeeper = new Shopkeeper(fakeScrivener);

            // act
            shopkeeper.Greet();

            // assert
            fakeScrivener.Messages[0].Should().Be("OMGHAI!");
        }
    }
}