using System.Linq;
using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class RoverTests
    {
        private Planet planet;
        private Point pointAtZeroZero;
        private IStateFactory stateFactory;

        [SetUp]
        public void SetUp()
        {
            planet = new Planet(50, Enumerable.Empty<Point>());
            pointAtZeroZero = new Point { X = 0, Y = 0 };
            stateFactory = new StateFactory();
        }

        [Test]
        public void TestMoveRoverForwardNorth()
        {
            var rover = new Rover(pointAtZeroZero, 'N', stateFactory, planet);
            rover.MoveForward();
            Assert.That(rover.GetCurrentPosition().ToString(), Is.EqualTo("0,1"));
        }

        [Test]
        public void TestMoveRoverForwardEast()
        {
            var rover = new Rover(pointAtZeroZero, 'E', stateFactory, planet);
            rover.MoveForward();
            Assert.That(rover.GetCurrentPosition().ToString(), Is.EqualTo("1,0"));
        }

        [Test]
        public void TestMoveRoverForwardSouth()
        {
            var rover = new Rover(pointAtZeroZero, 'S', stateFactory, planet);
            rover.MoveForward();
            Assert.That(rover.GetCurrentPosition().ToString(), Is.EqualTo("0,-1"));
        }

        [Test]
        public void TestMoveRoverForwardWest()
        {
            var rover = new Rover(pointAtZeroZero, 'W', stateFactory, planet);
            rover.MoveForward();
            Assert.That(rover.GetCurrentPosition().ToString(), Is.EqualTo("-1,0"));
        }

        [Test]
        public void TestMoveRoverMoveBackwardSouth()
        {
            var rover = new Rover(pointAtZeroZero, 'S', stateFactory, planet);
            rover.MoveBackward();
            Assert.That(rover.GetCurrentPosition().ToString(), Is.EqualTo("0,1"));
        }

        [Test]
        public void TestMoveRoverMoveBackwardEast()
        {
            var rover = new Rover(pointAtZeroZero, 'E', stateFactory, planet);
            rover.MoveBackward();
            Assert.That(rover.GetCurrentPosition().ToString(), Is.EqualTo("-1,0"));
        }

        [Test]
        public void TestMoveRoverMoveBackwardWest()
        {
            var rover = new Rover(pointAtZeroZero, 'W', stateFactory, planet);
            rover.MoveBackward();
            Assert.That(rover.GetCurrentPosition().ToString(), Is.EqualTo("1,0"));
        }

        [Test]
        public void TestMoveRoverMoveBackwardNorth()
        {
            var rover = new Rover(pointAtZeroZero, 'N', stateFactory, planet);
            rover.MoveBackward();
            Assert.That(rover.GetCurrentPosition().ToString(), Is.EqualTo("0,-1"));
        }

        [Test]
        public void TestTurnRoverRightFromNorth()
        {
            var rover = new Rover(pointAtZeroZero, 'N', stateFactory, planet);
            rover.TurnRight();
            rover.TurnRight();
            rover.TurnRight();
            rover.TurnRight();
            rover.MoveForward();
            Assert.That(rover.GetCurrentPosition().ToString(), Is.EqualTo("0,1"));
        }

        [Test]
        public void TestTurnLeftFromNorth()
        {
            var rover = new Rover(pointAtZeroZero, 'N', stateFactory, planet);
            rover.TurnLeft();
            rover.TurnLeft();
            rover.TurnLeft();
            rover.TurnLeft();
            rover.MoveForward();
            Assert.That(rover.GetCurrentPosition().ToString(), Is.EqualTo("0,1"));
        }

        [Test]
        public void TestRoverWrapsAroundXAxisMovingForwardEast()
        {
            var rover = new Rover(new Point { X = 25, Y = 0 }, 'E', stateFactory, planet);
            rover.MoveForward();
            Assert.That(rover.GetCurrentPosition().ToString(), Is.EqualTo("-25,0"));
        }

        [Test]
        public void TestRoverWrapsAroundXAxisMovingForwardWest()
        {
            var rover = new Rover(new Point { X = -25, Y = 0 }, 'W', stateFactory, planet);
            rover.MoveForward();
            Assert.That(rover.GetCurrentPosition().ToString(), Is.EqualTo("25,0"));
        }

        [Test]
        public void TestRoverWrapsAroundXAxisMovingBackwardWest()
        {
            var rover = new Rover(new Point { X = 25, Y = 0 }, 'W', stateFactory, planet);
            rover.MoveBackward();
            Assert.That(rover.GetCurrentPosition().ToString(), Is.EqualTo("-25,0"));
        }

        [Test]
        public void TestRoverWrapsAroundXAxisMovingBackwardEast()
        {
            var rover = new Rover(new Point { X = -25, Y = 0 }, 'E', stateFactory, planet);
            rover.MoveBackward();
            Assert.That(rover.GetCurrentPosition().ToString(), Is.EqualTo("25,0"));
        }

        [Test]
        public void TestRoverWrapsAroundYAxisMovingForwardNorth()
        {
            var rover = new Rover(new Point { X = 0, Y = 25 }, 'N', stateFactory, planet);
            rover.MoveForward();
            Assert.That(rover.GetCurrentPosition().ToString(), Is.EqualTo("0,-25"));
        }

        [Test]
        public void TestRoverWrapsAroundYAxisMovingForwardSouth()
        {
            var rover = new Rover(new Point { X = 0, Y = -25 }, 'S', stateFactory, planet);
            rover.MoveForward();
            Assert.That(rover.GetCurrentPosition().ToString(), Is.EqualTo("0,25"));
        }

        [Test]
        public void TestRoverWrapsAroundYAxisMovingBackwardSouth()
        {
            var rover = new Rover(new Point { X = 0, Y = 25 }, 'S', stateFactory, planet);
            rover.MoveBackward();
            Assert.That(rover.GetCurrentPosition().ToString(), Is.EqualTo("0,-25"));
        }

        [Test]
        public void TestRoverWrapsAroundYAxisMovingBackwardNorth()
        {
            var rover = new Rover(new Point { X = 0, Y = -25 }, 'N', stateFactory, planet);
            rover.MoveBackward();
            Assert.That(rover.GetCurrentPosition().ToString(), Is.EqualTo("0,25"));
        }

        [Test]
        public void TestRoverEncountersObstacleMovingPositively()
        {
            var obstructionPoint = new Point { X = 2, Y = 2 };
            var planetWithObstacles = new Planet(50, new Point[] { obstructionPoint });
            var rover = new Rover(new Point { X = 2, Y = 1 }, 'N', stateFactory, planetWithObstacles);
            rover.MoveForward();

            Assert.That(rover.IsObstructed, Is.EqualTo(true));
            Assert.That(rover.Obstruction.ToString(), Is.EqualTo(obstructionPoint.ToString()));
            Assert.That(rover.GetCurrentPosition().ToString(), Is.EqualTo("2,1"));
        }

        [Test]
        public void TestRoverEncountersObstacleMovingNegatively()
        {
            var obstructionPoint = new Point { X = 2, Y = 2 };
            var planetWithObstacles = new Planet(50, new Point[] { obstructionPoint });
            var rover = new Rover(new Point { X = 3, Y = 2 }, 'W', stateFactory, planetWithObstacles);
            rover.MoveForward();

            Assert.That(rover.IsObstructed, Is.EqualTo(true));
            Assert.That(rover.Obstruction.ToString(), Is.EqualTo(obstructionPoint.ToString()));
            Assert.That(rover.GetCurrentPosition().ToString(), Is.EqualTo("3,2"));
        }
    }
}
