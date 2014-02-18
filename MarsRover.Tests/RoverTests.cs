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
            var rover = new Rover("0,0", 'N', 50);
            rover.MoveForward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo("0,1"));
        }

        [Test]
        public void TestMoveRoverForwardFacingEast()
        {
            var rover = new Rover("0,0", 'E', 50);
            rover.MoveForward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo("1,0"));
        }

        [Test]
        public void TestMoveRoverForwardFacingSouth()
        {
            var rover = new Rover("0,0", 'S', 50);
            rover.MoveForward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo("0,-1"));
        }

        [Test]
        public void TestMoveRoverForwardFacingWest()
        {
            var rover = new Rover("0,0", 'W', 50);
            rover.MoveForward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo("-1,0"));
        }

        [Test]
        public void TestMoveRoverForwardWithUndefinedDirection()
        {
            var rover = new Rover("0,0", 'Z', 50);
            var exception = Assert.Throws<InvalidOperationException>(new TestDelegate(() => rover.MoveForward()));
            Assert.That(exception.Message, Is.EqualTo("Current direction of rover is unrecognizable"));
        }

        [Test]
        public void TestMoveRoverBackwardFacingNorth()
        {
            var rover = new Rover("0,0", 'N', 50);
            rover.MoveBackward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo("0,-1"));
        }

        [Test]
        public void TestMoveRoverBackwardFacingSouth()
        {
            var rover = new Rover("0,0", 'S', 50);
            rover.MoveBackward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo("0,1"));
        }

        [Test]
        public void TestMoveRoverBackwardFacingEast()
        {
            var rover = new Rover("0,0", 'E', 50);
            rover.MoveBackward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo("-1,0"));
        }

        [Test]
        public void TestMoveRoverBackwardFacingWest()
        {
            var rover = new Rover("0,0", 'W', 50);
            rover.MoveBackward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo("1,0"));
        }

        [Test]
        public void TestMoveRoverBackwordWithUndefinedDirection()
        {
            var rover = new Rover("0,0", 'Z', 50);
            var exception = Assert.Throws<InvalidOperationException>(new TestDelegate(() => rover.MoveBackward()));
            Assert.That(exception.Message, Is.EqualTo("Current direction of rover is unrecognizable"));
        }

        [Test]
        public void TestTurnRoverRightFromNorth()
        {
            var rover = new Rover("0,0", 'N', 50);
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
            var rover = new Rover("0,0", 'N', 50);
            rover.TurnLeft();
            rover.TurnLeft();
            rover.TurnLeft();
            rover.TurnLeft();
            rover.MoveForward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo("0,1"));
        }

        [Test]
        public void TestRoverWrapsAroundXAxisMovingEastForward()
        {
            var rover = new Rover("25,0", 'E', 50);
            rover.MoveForward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo("-25,0"));
        }

        [Test]
        public void TestRoverWrapsAroundXAxisMovingEastBackward()
        {
            var rover = new Rover("25,0", 'W', 50);
            rover.MoveBackward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo("-25,0"));
        }

        [Test]
        public void TestRoverWrapsAroundXAxisMovingWestForward()
        {
            var rover = new Rover("-25,0", 'W', 50);
            rover.MoveForward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo("25,0"));
        }

        [Test]
        public void TestRoverWrapsAroundYAxisMovingNorthForward()
        {
            var rover = new Rover("0,25", 'N', 50);
            rover.MoveForward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo("0,-25"));
        }

        [Test]
        public void TestRoverWrapsAroundYAxisMovingNorthBackward()
        {
            var rover = new Rover("0,25", 'S', 50);
            rover.MoveBackward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo("0,-25"));
        }

        [Test]
        public void TestRoverWrapsAroundYAxisMovingSouthForward()
        {
            var rover = new Rover("0,-25", 'S', 50);
            rover.MoveForward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo("0,25"));
        }
    }
}
