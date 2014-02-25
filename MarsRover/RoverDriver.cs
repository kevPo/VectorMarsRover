using System;
using System.Linq;

namespace MarsRover
{
    public class RoverDriver
    {
        private const Char forward = 'f';
        private const Char backward = 'b';
        private const Char left = 'l';
        private const Char right = 'r';
        private Rover rover;
        
        public RoverDriver(Rover rover)
        {
            this.rover = rover;
        }

        public String GetRoverPosition()
        {
            return rover.GetCurrentPosition().ToString();
        }

        public String MoveRover(String commands)
        {
            var commandSequence = commands.ToCharArray();

            try 
            {
                for (var i = 0; i < commandSequence.Length; i++)
                {
                    CommandRover(commandSequence[i]);

                    if (rover.IsObstructed)
                    {
                        return String.Format("Rover encountered obstacle at position ({0}), rover stopped at ({1}).",
                            rover.Obstruction, rover.GetCurrentPosition());
                    }
                }
            }
            catch (InvalidOperationException exception)
            {
                return exception.Message;
            }

            return String.Format("Rover was successfully moved to ({0}).", rover.GetCurrentPosition());
        }

        private void CommandRover(Char command)
        {
            switch (command)
            {
                case forward:
                    rover.MoveForward();
                    break;
                case backward:
                    rover.MoveBackward();
                    break;
                case left:
                    rover.TurnLeft();
                    break;
                case right:
                    rover.TurnRight();
                    break;
                default:
                    throw new InvalidOperationException(String.Format("Error, \'{0}\' is an undefined command.", command));
            }
        }
    }
}
