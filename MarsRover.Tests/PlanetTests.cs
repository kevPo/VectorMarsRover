using System;
using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class PlanetTests
    {
        [Test]
        public void TestPlanetCreatesCorrectBorders()
        {
            var planet = new Planet(50, new Point[] {});
            Assert.That(planet.PositiveBorder, Is.EqualTo(25));
            Assert.That(planet.NegativeBorder, Is.EqualTo(-25));
        }

        [Test]
        public void TestPlanetCreatesCorrectBordersForOddSizes()
        {
            var planet = new Planet(15, new Point[] {});
            Assert.That(planet.PositiveBorder, Is.EqualTo(7));
            Assert.That(planet.NegativeBorder, Is.EqualTo(-7));
        }
    }
}
