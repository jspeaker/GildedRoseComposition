using csharp.NonPlayerCharacters;
using csharp.tests.Fakes;
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
            FakeParchment fakeParchment = new FakeParchment();
            IShopkeeper shopkeeper = new Shopkeeper(fakeParchment);

            // act
            shopkeeper.Greet();

            // assert
            fakeParchment.Inscriptions[0].Should().Be("OMGHAI!");
        }
    }
}