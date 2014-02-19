using System;
using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class MarsRoverTests
    {
        private Planet planet;

        [SetUp]
        public void SetUp()
        {
            planet = new Planet(100, new Point[] { });
        }

        [Test]
        public void TestMarsRoverInitializationAtZeroZero()
        {
            var marsRover = new MarsRover(planet, new RoverLocation { X = 0, Y = 0, Direction = Direction.North});
            Assert.That(marsRover.GetRoverPosition(), Is.EqualTo("0,0"));
        }

        [Test]
        public void TestMarsRoverInitializationAtFourFour()
        {
            var marsRover = new MarsRover(planet, new RoverLocation { X = 4, Y = 4, Direction = Direction.North });
            Assert.That(marsRover.GetRoverPosition(), Is.EqualTo("4,4"));
        }

        [Test]
        public void TestMoveRoverWithCommands()
        {
            var marsRover = new MarsRover(planet, new RoverLocation { X = 0, Y = 0, Direction = Direction.North });
            marsRover.MoveRover("ffrff");
            Assert.That(marsRover.GetRoverPosition(), Is.EqualTo("2,2"));
        }

        [Test]
        public void TestRoverEncountersObstacle()
        {
            var planetWithObstacles = new Planet(50, new [] { new Point { X = 3, Y = 3} } );
            var marsRover = new MarsRover(planetWithObstacles, new RoverLocation { X = 3, Y = 2, Direction = Direction.North });
            Assert.That(marsRover.MoveRover("ffrff"), Is.EqualTo("Obstacle was encountered at 3,3, rover stopped at 3,2"));
        }
    }
}
