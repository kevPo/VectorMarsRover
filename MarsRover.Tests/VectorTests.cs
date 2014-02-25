using System;
using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class VectorTests
    {
        [Test]
        public void TestVectorAddition()
        {
            var vectorA = new Vector(1, 1);
            var vectorB = new Vector(3, 3);
            Assert.That(vectorA + vectorB, Is.EqualTo(new Vector(4, 4)));
        }

        [Test]
        public void TestVectorSubtraction()
        {
            var vectorA = new Vector(3, 3);
            var vectorB = new Vector(1, 1);
            Assert.That(vectorA - vectorB, Is.EqualTo(new Vector(2, 2)));
        }

        [Test]
        public void TestVectorNormalization()
        {
            var vector = new Vector((Int32)Math.Cos(Math.PI / 2), (Int32)Math.Sin(Math.PI / 2));
            Assert.That(vector.Normalize(), Is.EqualTo(new Vector(0, 1)));
        }

        [Test]
        public void TestMinusRadians()
        {
            var vector = new Vector(0, 1);
            var result = vector.MinusRadians(Math.PI / 2);
            Assert.That(result, Is.EqualTo(new Vector(1, 0)));
        }

        [Test]
        public void TestPlusRadians()
        {
            var vector = new Vector(0, 1);
            var result = vector.PlusRadians(Math.PI / 2);
            Assert.That(result, Is.EqualTo(new Vector(-1, 0)));
        }
    }
}
