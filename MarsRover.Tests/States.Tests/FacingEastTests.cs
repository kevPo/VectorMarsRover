using NUnit.Framework;

namespace MarsRover.Tests.States.Tests
{
    [TestFixture]
    public class FacingEastTests
    {
        private Planet planet;
        private IStateFactory stateFactory;

        [SetUp]
        public void SetUp()
        {
            planet = new Planet(100, new Point[] { });
            stateFactory = new StateFactory();
        }

        [Test]
        public void TestMoveForward()
        {
            var rover = new Rover(new Point { X = 0, Y = 0 }, 'E', stateFactory, planet);
            rover.MoveForward();

            Assert.That(rover.GetCurrentPosition().ToString(), Is.EqualTo("1,0"));
        }

        [Test]
        public void TestMoveBackward()
        {
            var rover = new Rover(new Point { X = 0, Y = 0 }, 'E', stateFactory, planet);
            rover.MoveBackward();

            Assert.That(rover.GetCurrentPosition().ToString(), Is.EqualTo("-1,0"));
        }

        [Test]
        public void TestRoverWrapsAroundPlanetForward()
        {
            var rover = new Rover(new Point { X = 50, Y = 0 }, 'E', stateFactory, planet);
            rover.MoveForward();

            Assert.That(rover.GetCurrentPosition().ToString(), Is.EqualTo("-50,0"));
        }

        [Test]
        public void TestRoverWrapsAroundPlanetBackward()
        {
            var rover = new Rover(new Point { X = -50, Y = 0 }, 'E', stateFactory, planet);
            rover.MoveBackward();

            Assert.That(rover.GetCurrentPosition().ToString(), Is.EqualTo("50,0"));
        }

        [Test]
        public void TestEnountersObstructionAndDoesNotMoveForward()
        {
            var planetWithObstruction = new Planet(50, new Point[] { new Point { X = 1, Y = 0 } });
            var rover = new Rover(new Point { X = 0, Y = 0 }, 'E', stateFactory, planetWithObstruction);
            rover.MoveForward();

            Assert.That(rover.GetCurrentPosition().ToString(), Is.EqualTo("0,0"));
        }

        [Test]
        public void TestEnountersObstructionAndDoesNotMoveBackward()
        {
            var planetWithObstruction = new Planet(50, new Point[] { new Point { X = -1, Y = 0 } });
            var rover = new Rover(new Point { X = 0, Y = 0 }, 'E', stateFactory, planetWithObstruction);
            rover.MoveBackward();

            Assert.That(rover.GetCurrentPosition().ToString(), Is.EqualTo("0,0"));
        }

        [Test]
        public void TestEncounterObstacleOnOtherSideOfAxisAndDoesNotMoveForward()
        {
            var planetWithObstruction = new Planet(50, new Point[] { new Point { X = -25, Y = 0 } });
            var rover = new Rover(new Point { X = 25, Y = 0 }, 'E', stateFactory, planetWithObstruction);
            rover.MoveForward();

            Assert.That(rover.GetCurrentPosition().ToString(), Is.EqualTo("25,0"));
        }

        [Test]
        public void TestEncounterObstacleOnOtherSideOfAxisAndDoesNotMoveBackward()
        {
            var planetWithObstruction = new Planet(50, new Point[] { new Point { X = 25, Y = 0 } });
            var rover = new Rover(new Point { X = -25, Y = 0 }, 'E', stateFactory, planetWithObstruction);
            rover.MoveBackward();

            Assert.That(rover.GetCurrentPosition().ToString(), Is.EqualTo("-25,0"));
        }
    }
}
