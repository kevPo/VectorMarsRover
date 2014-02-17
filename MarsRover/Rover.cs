
using System;
using System.Collections.Generic;
namespace MarsRover
{
    public class Rover
    {
        private const Char NORTH = 'N';
        private const Char SOUTH = 'S';
        private const Char EAST =  'E';
        private const Char WEST =  'W';
        private const Int32 FORWARD = 1;
        private const Int32 BACKWARD = -1;

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

        public void TurnRight()
        {
            if (FacingNorth())
                direction = EAST;
            else if (FacingEast())
                direction = SOUTH;
            else if (FacingSouth())
                direction = WEST;
            else 
                direction = NORTH;
        }

        public void TurnLeft()
        {
            if (FacingNorth())
                direction = WEST;
            else if (FacingEast())
                direction = NORTH;
            else if (FacingSouth())
                direction = EAST;
            else
                direction = SOUTH;
        }

        public void MoveBackward()
        {
            if (FacingNorth())
                Y--;
            else if (FacingSouth())
                Y++;
            else if (FacingEast())
                X--;
            else if (FacingWest())
                X++;
            else
                throw new InvalidOperationException("Current direction of rover is unrecognizable");
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
