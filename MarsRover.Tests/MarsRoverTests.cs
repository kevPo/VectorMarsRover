using System;
using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class MarsRoverTests
    {
        [Test]
        public void TestMarsRoverInitializationAtZeroZero()
        {
            var marsRover = new MarsRover(100, "0,0", "N");
            Assert.That(marsRover.GetRoverPosition(), Is.EqualTo("0,0"));
        }

        [Test]
        public void TestMarsRoverInitializationAtFourFour()
        {
            var marsRover = new MarsRover(100, "4,4", "N");
            Assert.That(marsRover.GetRoverPosition(), Is.EqualTo("4,4"));
        }
    }
}
