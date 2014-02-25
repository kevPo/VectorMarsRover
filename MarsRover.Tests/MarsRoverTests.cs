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
            var marsRover = new MarsRover(planet, "0,0", 'N');
            Assert.That(marsRover.GetRoverPosition(), Is.EqualTo("0,0"));
        }

        [Test]
        public void TestMarsRoverInitializationAtFourFour()
        {
            var marsRover = new MarsRover(planet, "4,4", 'N');
            Assert.That(marsRover.GetRoverPosition(), Is.EqualTo("4,4"));
        }

        [Test]
        public void TestMoveRoverWithCommands()
        {
            var marsRover = new MarsRover(planet, "0,0", 'N');
            Assert.That(marsRover.MoveRover("ffrff"), Is.EqualTo("Rover was successfully moved to (2,2)."));
        }

        [Test]
        public void TestRoverEncountersObstacle()
        {
            var planetWithObstacles = new Planet(50, new [] { new Point { X = 3, Y = 3} } );
            var marsRover = new MarsRover(planetWithObstacles, "3,2", 'N');
            Assert.That(marsRover.MoveRover("ffrff"), Is.EqualTo("Rover encountered obstacle at position (3,3), rover stopped at (3,2)."));
        }

        [Test]
        public void TestRoverWrapsAroundAxis()
        {
            var marsRover = new MarsRover(planet, "0,50", 'N');
            Assert.That(marsRover.MoveRover("ffrff"), Is.EqualTo("Rover was successfully moved to (2,-49)."));
        }

        [Test]
        public void TestRoverEncountersObstacleOnOtherSideOfXAxis()
        {
            var planetWithObstacles = new Planet(50, new[] { new Point { X = 0, Y = -25 } });
            var marsRover = new MarsRover(planetWithObstacles, "0,25", 'N');
            Assert.That(marsRover.MoveRover("ffrff"), Is.EqualTo("Rover encountered obstacle at position (0,-25), rover stopped at (0,25)."));
        }

        [Test]
        public void TestRoverWithUndefinedCommand()
        {
            var marsRover = new MarsRover(planet, "0,50", 'N');
            Assert.That(marsRover.MoveRover("fzrff"), Is.EqualTo("Error, 'z' is an undefined command."));
        }
    }
}
