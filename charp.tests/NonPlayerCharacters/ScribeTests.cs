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
        public void ShouldInscribeMessage()
        {
            // arrange
            const string message = "message";
            FakeParchment fakeParchment = new FakeParchment();
            IScrivener scrivener = new Scribe(fakeParchment);

            // act
            scrivener.Inscribe(message);

            // assert
            fakeParchment.Inscriptions[0].Should().Be(message);
        }
    }
}