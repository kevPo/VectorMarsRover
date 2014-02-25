using System;
using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class RoverDriverTests
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
            var rover = new Rover(new Point(0,0), 'N', planet);
            var driver = new RoverDriver(rover);
            Assert.That(driver.GetRoverPosition(), Is.EqualTo("0,0"));
        }

        [Test]
        public void TestMarsRoverInitializationAtFourFour()
        {
            var rover = new Rover(new Point(4,4), 'N', planet);
            var driver = new RoverDriver(rover);
            Assert.That(driver.GetRoverPosition(), Is.EqualTo("4,4"));
        }

        [Test]
        public void TestMoveRoverWithCommands()
        {
            var rover = new Rover(new Point(0, 0), 'N', planet);
            var driver = new RoverDriver(rover);
            Assert.That(driver.MoveRover("ffrff"), Is.EqualTo("Rover was successfully moved to (2,2)."));
        }

        [Test]
        public void TestRoverEncountersObstacle()
        {
            var planetWithObstacles = new Planet(50, new [] { new Point { X = 3, Y = 3} } );
            var rover = new Rover(new Point(3, 2), 'N', planetWithObstacles);
            var driver = new RoverDriver(rover);
            Assert.That(driver.MoveRover("ffrff"), Is.EqualTo("Rover encountered obstacle at position (3,3), rover stopped at (3,2)."));
        }

        [Test]
        public void TestRoverWrapsAroundAxis()
        {
            var rover = new Rover(new Point(0, 50), 'N', planet);
            var driver = new RoverDriver(rover);
            Assert.That(driver.MoveRover("ffrff"), Is.EqualTo("Rover was successfully moved to (2,-49)."));
        }

        [Test]
        public void TestRoverEncountersObstacleOnOtherSideOfXAxis()
        {
            var planetWithObstacles = new Planet(50, new[] { new Point { X = 0, Y = -25 } });
            var rover = new Rover(new Point(0, 25), 'N', planetWithObstacles);
            var driver = new RoverDriver(rover);
            Assert.That(driver.MoveRover("ffrff"), Is.EqualTo("Rover encountered obstacle at position (0,-25), rover stopped at (0,25)."));
        }

        [Test]
        public void TestRoverWithUndefinedCommand()
        {
            var rover = new Rover(new Point(0, 50), 'N', planet);
            var driver = new RoverDriver(rover);
            Assert.That(driver.MoveRover("fzrff"), Is.EqualTo("Error, 'z' is an undefined command."));
        }
    }
}
