using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    public class Rover
    {
        private const Int32 POSITIVE_DIRECTION = 1;
        private const Int32 NEGATIVE_DIRECTION = -1;

        private RoverLocation currentPoint;
        private Planet planet;

        public Rover(RoverLocation roverLocation, Planet planet)
        {
            currentPoint = roverLocation;
            this.planet = planet;
        }

        public String GetCurrentPosition()
        {
            return currentPoint.ToString();
        }

        public void TurnRight()
        {
            if (FacingNorth())
                currentPoint.Direction = Direction.East;
            else if (FacingEast())
                currentPoint.Direction = Direction.South;
            else if (FacingSouth())
                currentPoint.Direction = Direction.West;
            else 
                currentPoint.Direction = Direction.North;
        }

        public void TurnLeft()
        {
            if (FacingNorth())
                currentPoint.Direction = Direction.West;
            else if (FacingEast())
                currentPoint.Direction = Direction.North;
            else if (FacingSouth())
                currentPoint.Direction = Direction.East;
            else
                currentPoint.Direction = Direction.South;
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
            return currentPoint.Direction == Direction.North;
        }

        private Boolean FacingSouth()
        {
            return currentPoint.Direction == Direction.South;
        }

        private Boolean FacingEast()
        {
            return currentPoint.Direction == Direction.East;
        }
        
        private Boolean FacingWest()
        {
            return currentPoint.Direction == Direction.West;
        }
    }
}
