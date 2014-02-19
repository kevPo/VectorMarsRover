using System;
using NUnit.Framework;
using System.Linq;

namespace MarsRover.Tests
{
    [TestFixture]
    public class RoverTests
    {
        private Planet planet;
        private RoverLocation pointAtZeroZero;

        [SetUp]
        public void SetUp()
        {
            planet = new Planet(50, Enumerable.Empty<Point>());
            pointAtZeroZero = new RoverLocation { X = 0, Y = 0};
        }

        [Test]
        [TestCase(Direction.North, "0,1")]
        [TestCase(Direction.East, "1,0")]
        [TestCase(Direction.South, "0,-1")]
        [TestCase(Direction.West, "-1,0")]
        public void TestMoveRoverForward(Direction direction, String resultingPosition)
        {
            pointAtZeroZero.Direction = direction;
            var rover = new Rover(pointAtZeroZero, planet);
            rover.MoveForward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo(resultingPosition));
        }

        [Test]
        [TestCase(Direction.South, "0,1")]
        [TestCase(Direction.East, "-1,0")]
        [TestCase(Direction.West, "1,0")]
        [TestCase(Direction.North, "0,-1")]
        public void TestMoveRoverMoveBackward(Direction direction, String resultingPosition)
        {
            pointAtZeroZero.Direction = direction;
            var rover = new Rover(pointAtZeroZero, planet);
            rover.MoveBackward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo(resultingPosition));
        }

        [Test]
        public void TestTurnRoverRightFromNorth()
        {
            pointAtZeroZero.Direction = Direction.North;
            var rover = new Rover(pointAtZeroZero, planet);
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
            pointAtZeroZero.Direction = Direction.North;
            var rover = new Rover(pointAtZeroZero, planet);
            rover.TurnLeft();
            rover.TurnLeft();
            rover.TurnLeft();
            rover.TurnLeft();
            rover.MoveForward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo("0,1"));
        }

        [Test]
        [TestCase(25, 0, Direction.East, "-25,0")]
        [TestCase(-25, 0, Direction.West, "25,0")]
        public void TestRoverWrapsAroundXAxisMovingForward(Int32 x, Int32 y, Direction direction, String result)
        {
            var rover = new Rover(new RoverLocation { X = x, Y = y, Direction = direction }, planet);
            rover.MoveForward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo(result));
        }

        [Test]
        [TestCase(25, 0, Direction.West, "-25,0")]
        [TestCase(-25, 0, Direction.East, "25,0")]
        public void TestRoverWrapsAroundXAxisMovingBackward(Int32 x, Int32 y, Direction direction, String result)
        {
            var rover = new Rover(new RoverLocation { X = x, Y = y, Direction = direction }, planet);
            rover.MoveBackward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo(result));
        }

        [Test]
        [TestCase(0, 25, Direction.North, "0,-25")]
        [TestCase(0, -25, Direction.South, "0,25")]
        public void TestRoverWrapsAroundYAxisMovingForward(Int32 x, Int32 y, Direction direction, String result)
        {
            var rover = new Rover(new RoverLocation { X = x, Y = y, Direction = direction }, planet);
            rover.MoveForward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo(result));
        }

        [Test]
        [TestCase(0, 25, Direction.South, "0,-25")]
        [TestCase(0, -25, Direction.North, "0,25")]
        public void TestRoverWrapsAroundYAxisMovingBackward(Int32 x, Int32 y, Direction direction, String result)
        {
            var rover = new Rover(new RoverLocation { X = x, Y = y, Direction = direction }, planet);
            rover.MoveBackward();
            Assert.That(rover.GetCurrentPosition(), Is.EqualTo(result));
        }

        [Test]
        public void TestRoverEncountersObstacleMovingPositively()
        {
            var planetWithObstacles = new Planet(50, new Point[] { new Point { X = 2, Y = 2 } });
            var rover = new Rover(new RoverLocation { X = 2, Y = 1, Direction = Direction.North }, 
                                  planetWithObstacles);

            var exception = Assert.Throws<BlockedByObstacleException>(new TestDelegate(() => rover.MoveForward()));
            Assert.That(exception.Message, Is.EqualTo("Obstacle was encountered at 2,2, rover stopped at 2,1"));
        }

        [Test]
        public void TestRoverEncountersObstacleMovingNegatively()
        {
            var planetWithObstacles = new Planet(50, new Point[] { new Point { X = 2, Y = 2 } });
            var rover = new Rover(new RoverLocation { X = 3, Y = 2, Direction = Direction.West }, planetWithObstacles);

            var exception = Assert.Throws<BlockedByObstacleException>(new TestDelegate(() => rover.MoveForward()));
            Assert.That(exception.Message, Is.EqualTo("Obstacle was encountered at 2,2, rover stopped at 3,2"));
        }
    }
}
