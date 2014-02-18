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
    }
}
