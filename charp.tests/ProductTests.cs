using csharp.Models;
using csharp.Strategies;
using FluentAssertions;
using NUnit.Framework;

namespace csharp.tests
{
    [TestFixture]
    public class ProductTests
    {
        private IQualityAdjustmentStrategy _qualityAdjustment;

        [SetUp]
        public void Setup()
        {
            _qualityAdjustment = new CommonQualityAdjustment(new DefaultQualityAdjustment());
        }

        [Test, Category("Unit")]
        public void GivenEventPassLifetimeTen_WhenAskingEventPassQualityAddend_ShouldReturnOne()
        {
            // arrange
            const string largeSack = "Concert Ticket";
            const int sellIn = 10;
            const int quality = 10;

            IProduct product = new Product(_qualityAdjustment, FakeItem.Instance(largeSack, sellIn, quality));

            // act
            int actual = product.EventPassQualityAddend();

            // assert
            actual.Should().Be(1);
        }

        [Test, Category("Unit")]
        public void GivenEventPassLifetimeNine_WhenAskingEventPassQualityAddend_ShouldReturnTwo()
        {
            // arrange
            const string largeSack = "Concert Ticket";
            const int sellIn = 9;
            const int quality = 10;

            IProduct product = new Product(_qualityAdjustment, FakeItem.Instance(largeSack, sellIn, quality));

            // act
            int actual = product.EventPassQualityAddend();

            // assert
            actual.Should().Be(2);
        }

        [Test, Category("Unit")]
        public void GivenEventPassLifetimeFour_WhenAskingEventPassQualityAddend_ShouldReturnThree()
        {
            // arrange
            const string largeSack = "Concert Ticket";
            const int sellIn = 4;
            const int quality = 10;

            IProduct product = new Product(_qualityAdjustment, FakeItem.Instance(largeSack, sellIn, quality));

            // act
            int actual = product.EventPassQualityAddend();

            // assert
            actual.Should().Be(3);
        }

        [Test, Category("Unit")]
        public void GivenEventPasExpired_WhenAskingEventPassQualityAddend_ShouldReturnInverseOfQuality()
        {
            // arrange
            const string largeSack = "Concert Ticket";
            const int sellIn = -1;
            const int quality = 10;

            IProduct product = new Product(_qualityAdjustment, FakeItem.Instance(largeSack, sellIn, quality));

            // act
            int actual = product.EventPassQualityAddend();

            // assert
            actual.Should().Be(-10);
        }

        [Test, Category("Unit")]
        public void GivenEventPassAtMaximumQuality_WhenAskingEventPassQualityAddend_ShouldReturnZero()
        {
            // arrange
            const string largeSack = "Concert Ticket";
            const int sellIn = 10;
            const int quality = 50;

            IProduct product = new Product(_qualityAdjustment, FakeItem.Instance(largeSack, sellIn, quality));

            // act
            int actual = product.EventPassQualityAddend();

            // assert
            actual.Should().Be(0);
        }

        [Test, Category("Unit")]
        public void GivenProduct_WhenAskingForReport_ShouldOutputCorrectInformation()
        {
            // arrange
            const string largeSack = "Large Sack";
            const int sellIn = 10;
            const int quality = 10;

            IProduct product = new Product(_qualityAdjustment, FakeItem.Instance(largeSack, sellIn, quality));

            // act
            string actual = product.ToString();

            // assert
            actual.Should().Be($"{largeSack}, {sellIn}, {quality}");
        }
    }
}
