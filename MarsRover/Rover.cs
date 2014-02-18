using System;
using System.Collections.Generic;
using System.Linq;

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

        private Point currentPoint;
        private Char direction;
        private Planet planet;

        public Rover(Point initialPosition, Char initialDirection, Planet planet)
        {
            currentPoint = initialPosition;
            direction = initialDirection;
            this.planet = planet;
        }

        public String GetCurrentPosition()
        {
            return currentPoint.ToString();
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

        private Boolean FacingPositiveDirection()
        {
            return FacingNorth() || FacingEast();
        }

        private void Move(Int32 movement)
        {
            if (FacingNorth() || FacingSouth())
            {
                MoveTo(currentPoint.X, currentPoint.Y + movement);
            }
            else if (FacingEast() || FacingWest())
            {
                MoveTo(currentPoint.X + movement, currentPoint.Y);
            }
            else
                throw new InvalidOperationException("Current direction of rover is unrecognizable");

            HandleWrapping();
        }

        private void MoveTo(Int32 x, Int32 y)
        {
            if (PositionHasObstacle(x, y))
            {
                throw new BlockedByObstacleException(String.Format("Obstacle was encountered at {0}, rover stopped at {1}",
                    String.Join(",", new[] { x, y }), currentPoint.ToString()));
            }
            currentPoint.X = x;
            currentPoint.Y = y;
        }

        private void HandleWrapping()
        {
            if (currentPoint.Y > planet.PositiveBorder)
                currentPoint.Y = planet.NegativeBorder;

            if (currentPoint.Y < planet.NegativeBorder)
                currentPoint.Y = planet.PositiveBorder;

            if (currentPoint.X > planet.PositiveBorder)
                currentPoint.X = planet.NegativeBorder;

            if (currentPoint.X < planet.NegativeBorder)
                currentPoint.X = planet.PositiveBorder;
        }

        private Boolean PositionHasObstacle(Int32 x, Int32 y)
        {
            return planet.Obstacles.Any(o => o.X == x && o.Y == y);
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
