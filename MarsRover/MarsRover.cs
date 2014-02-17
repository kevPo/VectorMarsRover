using System;

namespace MarsRover
{
    public class MarsRover
    {
        private Rover rover;
        
        public MarsRover(Int32 planetSize, String roverStartingPoint, String direction)
        {
            rover = new Rover(roverStartingPoint, direction);
        }

        public String GetRoverPosition()
        {
            return rover.GetCurrentPosition();
        }
    }
}
