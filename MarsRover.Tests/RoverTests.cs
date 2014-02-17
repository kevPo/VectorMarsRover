using System;
using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class RoverTests
    {
        [Test]
        public void TestMoveRoverForward()
        {
            var rover = new Rover("0,0", 'N');
            rover.MoveForward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo("0,1"));
        }

        [Test]
        public void TestMoveRoverForwardFacingEastward()
        {
            var rover = new Rover("0,0", 'E');
            rover.MoveForward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo("1,0"));
        }

        [Test]
        public void TestMoveRoverForwardFacingSouth()
        {
            var rover = new Rover("0,0", 'S');
            rover.MoveForward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo("0,-1"));
        }

        [Test]
        public void TestMoveRoverForwardFacingWest()
        {
            var rover = new Rover("0,0", 'W');
            rover.MoveForward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo("-1,0"));
        }

        [Test]
        public void TestMoveRoverForwardWithUndefinedDirection()
        {
            var rover = new Rover("0,0", 'Z');
            var exception = Assert.Throws<InvalidOperationException>(new TestDelegate(() => rover.MoveForward()));
            Assert.That(exception.Message, Is.EqualTo("Current direction of rover is unrecognizable"));
        }
    }
}
