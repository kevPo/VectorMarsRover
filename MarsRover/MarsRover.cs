using System;

namespace MarsRover
{
    public class MarsRover
    {
        private const Char FORWARD = 'f';
        private const Char BACKWARD = 'b';
        private const Char LEFT = 'l';
        private const Char RIGHT = 'r';

        private Rover rover;
        
        public MarsRover(Int32 planetSize, String roverStartingPoint, Char direction)
        {
            rover = new Rover(roverStartingPoint, direction, planetSize);
        }

        public String GetRoverPosition()
        {
            return rover.GetCurrentPosition();
        }

        public void MoveRover(String commands)
        {
            var commandSequence = commands.ToCharArray();

            for (var i = 0; i < commandSequence.Length; i++)
                CommandRover(commandSequence[i]);
        }

        private void CommandRover(Char command)
        {
            switch (command)
            {
                case FORWARD:
                    rover.MoveForward();
                    break;
                case BACKWARD:
                    rover.MoveBackward();
                    break;
                case LEFT:
                    rover.TurnLeft();
                    break;
                case RIGHT:
                    rover.TurnRight();
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
