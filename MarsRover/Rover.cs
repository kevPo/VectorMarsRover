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
        private const Int32 POSITIVE_DIRECTION = 1;
        private const Int32 NEGATIVE_DIRECTION = -1;

        private Int32 X;
        private Int32 Y;
        private Char direction;
        private Int32 positiveBorder;
        private Int32 negativeBorder;

        public Rover(String initialPosition, Char initialDirection, Int32 planetSize)
        {
            var coordinates = initialPosition.Split(',');
            X = Int32.Parse(coordinates[0]);
            Y = Int32.Parse(coordinates[1]);
            direction = initialDirection;
            positiveBorder = planetSize / 2;
            negativeBorder = planetSize / 2 - planetSize;
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
            if (FacingPositiveDirection())
                Move(NEGATIVE_DIRECTION);
            else
                Move(POSITIVE_DIRECTION);
        }

        public void MoveForward()
        {
            if (FacingPositiveDirection())
                Move(POSITIVE_DIRECTION);
            else
                Move(NEGATIVE_DIRECTION);
        }

        private bool FacingPositiveDirection()
        {
            return FacingNorth() || FacingEast();
        }

        private void Move(Int32 movement)
        {
            if (FacingNorth() || FacingSouth())
            {
                Y += movement;
                if (Y > positiveBorder || Y < negativeBorder)
                    WrapAroundXAxis();
            }
            else if (FacingEast() || FacingWest())
            {
                X += movement;
                if (X > positiveBorder || X < negativeBorder)
                    WrapAroundYAxis();
            }
            else
                throw new InvalidOperationException("Current direction of rover is unrecognizable");
        }

        private void WrapAroundXAxis()
        {
            if (Y > positiveBorder)
                Y = negativeBorder;
            else
                Y = positiveBorder;
        }

        private void WrapAroundYAxis()
        {
            if (X > positiveBorder)
                X = negativeBorder;
            else
                X = positiveBorder;
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
