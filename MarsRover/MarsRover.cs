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
        
        public MarsRover(Planet planet, RoverLocation roverLocation)
        {
            rover = new Rover(roverLocation, planet);
        }

        public String GetRoverPosition()
        {
            return rover.GetCurrentPosition();
        }

        public String MoveRover(String commands)
        {
            try
            {
                var commandSequence = commands.ToCharArray();

                for (var i = 0; i < commandSequence.Length; i++)
                    CommandRover(commandSequence[i]);

                return "Sucess!";
            }
            catch (BlockedByObstacleException exception)
            {
                return exception.Message;
            }
            
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
