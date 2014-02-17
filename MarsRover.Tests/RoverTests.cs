using System;
using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class RoverTests
    {
        [Test]
        public void TestMoveRoverForwardFacingNorth()
        {
            var rover = new Rover("0,0", 'N');
            rover.MoveForward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo("0,1"));
        }

        [Test]
        public void TestMoveRoverForwardFacingEast()
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

        [Test]
        public void TestMoveRoverBackwardFacingNorth()
        {
            var rover = new Rover("0,0", 'N');
            rover.MoveBackward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo("0,-1"));
        }

        [Test]
        public void TestMoveRoverBackwardFacingSouth()
        {
            var rover = new Rover("0,0", 'S');
            rover.MoveBackward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo("0,1"));
        }

        [Test]
        public void TestMoveRoverBackwardFacingEast()
        {
            var rover = new Rover("0,0", 'E');
            rover.MoveBackward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo("-1,0"));
        }

        [Test]
        public void TestMoveRoverBackwardFacingWest()
        {
            var rover = new Rover("0,0", 'W');
            rover.MoveBackward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo("1,0"));
        }

        [Test]
        public void TestMoveRoverBackwordWithUndefinedDirection()
        {
            var rover = new Rover("0,0", 'Z');
            var exception = Assert.Throws<InvalidOperationException>(new TestDelegate(() => rover.MoveBackward()));
            Assert.That(exception.Message, Is.EqualTo("Current direction of rover is unrecognizable"));
        }

        [Test]
        public void TestTurnRoverRightFromNorth()
        {
            var rover = new Rover("0,0", 'N');
            rover.TurnRight();
            rover.TurnRight();
            rover.TurnRight();
            rover.TurnRight();
            rover.MoveForward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo("0,1"));
        }

        [Test]
        public void TestTurnLeftFromNorth()
        {
            var rover = new Rover("0,0", 'N');
            rover.TurnLeft();
            rover.TurnLeft();
            rover.TurnLeft();
            rover.TurnLeft();
            rover.MoveForward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo("0,1"));
        }

    }
}
