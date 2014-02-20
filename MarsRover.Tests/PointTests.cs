using System;
using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class PointTests
    {
        [Test]
        public void TestToString()
        {
            var point = new Point { X = 3, Y = 1 };
            Assert.That(point.ToString(), Is.EqualTo("3,1"));
        }

        [Test]
        public void TestConstructorWithRawValuesSetsCoordinates()
        {
            var point = new Point("5,3");
            Assert.That(point.X, Is.EqualTo(5));
            Assert.That(point.Y, Is.EqualTo(3));
        }
    }
}
