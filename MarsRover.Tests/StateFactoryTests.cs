using MarsRover.States;
using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class StateFactoryTests
    {
        private IStateFactory factory;
        private Planet planet;
        private Rover rover;

        [SetUp]
        public void SetUp()
        {
            factory = new StateFactory();
            planet = new Planet(100, new Point[] {});
            rover = new Rover(new Point { X = 0, Y = 0 }, 'N', factory, planet);
        }

        [Test]
        public void TestFactoryReturnsNorthFacingState()
        {
            var northFacing = factory.BuildState(rover, 'N', planet);
            Assert.That(northFacing.GetType() == typeof(FacingNorth), Is.EqualTo(true));
        }

        [Test]
        public void TestFactoryReturnsSouthFacingState()
        {
            var southFacing = factory.BuildState(rover, 'S', planet);
            Assert.That(southFacing.GetType() == typeof(FacingSouth), Is.EqualTo(true));
        }

        [Test]
        public void TestFactoryReturnsEastFacingState()
        {
            var eastFacing = factory.BuildState(rover, 'E', planet);
            Assert.That(eastFacing.GetType() == typeof(FacingEast), Is.EqualTo(true));
        }

        [Test]
        public void TestFactoryReturnsWestFacingState()
        {
            var westFacing = factory.BuildState(rover, 'W', planet);
            Assert.That(westFacing.GetType() == typeof(FacingWest), Is.EqualTo(true));
        }

        [Test]
        public void TestFactoryReturnsNullForUndefinedStates()
        {
            var undefinedFacing = factory.BuildState(rover, 'Z', planet);
            Assert.That(undefinedFacing == null, Is.EqualTo(true));
        }
    }
}
