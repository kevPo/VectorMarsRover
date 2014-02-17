
using System;
using System.Collections.Generic;
namespace MarsRover
{
    public class Rover
    {
        public const Char NORTH = 'N';
        public const Char SOUTH = 'S';
        public const Char EAST =  'E';
        public const Char WEST =  'W';
        
        private Int32 X;
        private Int32 Y;
        private Char direction;

        public Rover(String initialPosition, Char initialDirection)
        {
            var coordinates = initialPosition.Split(',');
            X = Int32.Parse(coordinates[0]);
            Y = Int32.Parse(coordinates[1]);
            direction = initialDirection;
        }

        public String GetCurrentPosition()
        {
            return String.Join(",", new Int32[] { X, Y });
        }

        public void MoveForward()
        {
            if (FacingNorth())
                Y++;
            else if (FacingSouth())
                Y--;
            else if (FacingEast())
                X++;
            else if (FacingWest())
                X--;
            else
                throw new InvalidOperationException("Current direction of rover is unrecognizable");
        }

        private Boolean FacingNorth()
        {
            return direction == 'N';
        }

        private Boolean FacingSouth()
        {
            return direction == 'S';
        }

        private Boolean FacingEast()
        {
            return direction == 'E';
        }
        
        private Boolean FacingWest()
        {
            return direction == 'W';
        }
    }
}
