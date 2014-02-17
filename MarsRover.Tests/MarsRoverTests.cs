using System;
using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class MarsRoverTests
    {
        [Test]
        public void TestMarsRoverInitialization()
        {
            var marsRover = new MarsRover(100, "0,0", "N");
            Assert.That(marsRover.GetRoverPosition(), Is.EqualTo("0,0"));
        }
    }
}
