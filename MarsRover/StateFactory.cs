using System;
using MarsRover.States;

namespace MarsRover
{
    public class StateFactory : IStateFactory
    {
        private const Char north = 'N';
        private const Char south = 'S';
        private const Char east = 'E';
        private const Char west = 'W';

        public State BuildState(Rover rover, char direction, Planet planet)
        {
            switch (direction)
            {
                case north:
                    return new FacingNorth(rover, planet);
                case south:
                    return new FacingSouth(rover, planet);
                case east:
                    return new FacingEast(rover, planet);
                case west:
                    return new FacingWest(rover, planet);
                default:
                    return null;
            }
        }
    }
}
