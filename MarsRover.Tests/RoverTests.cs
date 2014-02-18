using System;
using NUnit.Framework;
using System.Linq;

namespace MarsRover.Tests
{
    [TestFixture]
    public class RoverTests
    {
        private Planet planet;
        private Point pointAtZeroZero;

        [SetUp]
        public void SetUp()
        {
            planet = new Planet(50, Enumerable.Empty<Point>());
            pointAtZeroZero = new Point { X = 0, Y = 0};
        }

        [Test]
        public void TestMoveRoverForwardFacingNorth()
        {
            var rover = new Rover(pointAtZeroZero, 'N', planet);
            rover.MoveForward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo("0,1"));
        }

        [Test]
        public void TestMoveRoverForwardFacingEast()
        {
            var rover = new Rover(pointAtZeroZero, 'E', planet);
            rover.MoveForward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo("1,0"));
        }

        [Test]
        public void TestMoveRoverForwardFacingSouth()
        {
            var rover = new Rover(pointAtZeroZero, 'S', planet);
            rover.MoveForward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo("0,-1"));
        }

        [Test]
        public void TestMoveRoverForwardFacingWest()
        {
            var rover = new Rover(pointAtZeroZero, 'W', planet);
            rover.MoveForward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo("-1,0"));
        }

        [Test]
        public void TestMoveRoverForwardWithUndefinedDirection()
        {
            var rover = new Rover(pointAtZeroZero, 'Z', planet);
            var exception = Assert.Throws<InvalidOperationException>(new TestDelegate(() => rover.MoveForward()));
            Assert.That(exception.Message, Is.EqualTo("Current direction of rover is unrecognizable"));
        }

        [Test]
        public void TestMoveRoverBackwardFacingNorth()
        {
            var rover = new Rover(pointAtZeroZero, 'N', planet);
            rover.MoveBackward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo("0,-1"));
        }

        [Test]
        public void TestMoveRoverBackwardFacingSouth()
        {
            var rover = new Rover(pointAtZeroZero, 'S', planet);
            rover.MoveBackward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo("0,1"));
        }

        [Test]
        public void TestMoveRoverBackwardFacingEast()
        {
            var rover = new Rover(pointAtZeroZero, 'E', planet);
            rover.MoveBackward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo("-1,0"));
        }

        [Test]
        public void TestMoveRoverBackwardFacingWest()
        {
            var rover = new Rover(pointAtZeroZero, 'W', planet);
            rover.MoveBackward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo("1,0"));
        }

        [Test]
        public void TestMoveRoverBackwordWithUndefinedDirection()
        {
            var rover = new Rover(pointAtZeroZero, 'Z', planet);
            var exception = Assert.Throws<InvalidOperationException>(new TestDelegate(() => rover.MoveBackward()));
            Assert.That(exception.Message, Is.EqualTo("Current direction of rover is unrecognizable"));
        }

        [Test]
        public void TestTurnRoverRightFromNorth()
        {
            var rover = new Rover(pointAtZeroZero, 'N', planet);
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
            var rover = new Rover(pointAtZeroZero, 'N', planet);
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
            var rover = new Rover(new Point { X = 25, Y = 0 }, 'E', planet);
            rover.MoveForward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo("-25,0"));
        }

        [Test]
        public void TestRoverWrapsAroundXAxisMovingEastBackward()
        {
            var rover = new Rover(new Point { X = 25, Y = 0 }, 'W', planet);
            rover.MoveBackward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo("-25,0"));
        }

        [Test]
        public void TestRoverWrapsAroundXAxisMovingWestForward()
        {
            var rover = new Rover(new Point { X = -25, Y = 0 }, 'W', planet);
            rover.MoveForward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo("25,0"));
        }

        [Test]
        public void TestRoverWrapsAroundYAxisMovingNorthForward()
        {
            var rover = new Rover(new Point { X = 0, Y = 25 }, 'N', planet);
            rover.MoveForward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo("0,-25"));
        }

        [Test]
        public void TestRoverWrapsAroundYAxisMovingNorthBackward()
        {
            var rover = new Rover(new Point { X = 0, Y = 25 }, 'S', planet);
            rover.MoveBackward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo("0,-25"));
        }

        [Test]
        public void TestRoverWrapsAroundYAxisMovingSouthForward()
        {
            var rover = new Rover(new Point { X = 0, Y = -25 }, 'S', planet);
            rover.MoveForward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo("0,25"));
        }

        [Test]
        public void TestRoverEncountersObstacleMovingPositively()
        {
            var planetWithObstacles = new Planet(50, new Point[] { new Point { X = 2, Y = 2 } });
            var rover = new Rover(new Point { X = 2, Y = 1 }, 'N', planetWithObstacles);

            var exception = Assert.Throws<BlockedByObstacleException>(new TestDelegate(() => rover.MoveForward()));
            Assert.That(exception.Message, Is.EqualTo("Obstacle was encountered at 2,2, rover stopped at 2,1"));
        }

        [Test]
        public void TestRoverEncountersObstacleMovingNegatively()
        {
            var planetWithObstacles = new Planet(50, new Point[] { new Point { X = 2, Y = 2 } });
            var rover = new Rover(new Point { X = 3, Y = 2 }, 'W', planetWithObstacles);

            var exception = Assert.Throws<BlockedByObstacleException>(new TestDelegate(() => rover.MoveForward()));
            Assert.That(exception.Message, Is.EqualTo("Obstacle was encountered at 2,2, rover stopped at 3,2"));
        }
    }
}
