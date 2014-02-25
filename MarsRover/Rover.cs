using System;
using System.Linq;

namespace MarsRover
{
    public class Rover
    {
        private const Double radianRotation = Math.PI / 2; 
        
        public Boolean IsObstructed { get; private set; }
        public Point Obstruction { get; private set; }

        private Vector currentPoint;
        private Vector currentDirection;
        private Planet planet;

        public Rover(Point point, Char direction, Planet planet)
        {
            currentPoint = new Vector(point.X, point.Y);
            currentDirection = InitializeDirection(direction);
            this.planet = planet;
        }

        private Vector InitializeDirection(char direction)
        {
            switch (direction)
            {
                case 'E':
                    return new Vector((Int32)Math.Cos(2 * Math.PI), (Int32)Math.Sin(2 * Math.PI));
                case 'N':
                    return new Vector((Int32)Math.Cos(Math.PI / 2), (Int32)Math.Sin(Math.PI / 2));
                case 'W':
                    return new Vector((Int32)Math.Cos(Math.PI), (Int32)Math.Sin(Math.PI));
                case 'S':
                    return new Vector((Int32)Math.Cos((3 * Math.PI) / 2), (Int32)Math.Sin((3 * Math.PI) / 2));
                default:
                    throw new InvalidOperationException(String.Format("Direction \'{0}\' is not recognized", direction));
            }
        }

        public Point GetCurrentPosition()
        {
            return currentPoint;
        }

        public void TurnRight()
        {
            currentDirection = currentDirection.MinusRadians(radianRotation);
        }

        public void TurnLeft()
        {
            currentDirection = currentDirection.PlusRadians(radianRotation);
        }

        public void MoveBackward()
        {
            var futurePosition = new Vector(currentPoint.X, currentPoint.Y);
            futurePosition -= currentDirection;
            MoveRover(futurePosition);
        }

        public void MoveForward()
        {
            var futurePosition = new Vector(currentPoint.X, currentPoint.Y);
            futurePosition += currentDirection;
            MoveRover(futurePosition);
        }

        private void MoveRover(Vector futurePosition)
        {
            var nextPosition = WrapAroundAxisIfNeeded(futurePosition);

            if (NextPositionIsBlockedByObstacle(nextPosition))
            {
                IsObstructed = true;
                Obstruction = nextPosition;
            }
            else
            {
                currentPoint = nextPosition;
            }
        }

        private Boolean NextPositionIsBlockedByObstacle(Vector nextPosition)
        {
            return planet.Obstacles.Any(o => o.X == nextPosition.X && o.Y == nextPosition.Y);
        }

        private Vector WrapAroundAxisIfNeeded(Vector futurePoint)
        {
            if (futurePoint.X > planet.PositiveBorder)
                futurePoint.X = planet.NegativeBorder;
            else if (futurePoint.X < planet.NegativeBorder)
                futurePoint.X = planet.PositiveBorder;
            
            if (futurePoint.Y > planet.PositiveBorder)
                futurePoint.Y = planet.NegativeBorder;
            else if (futurePoint.Y < planet.NegativeBorder)
                futurePoint.Y = planet.PositiveBorder;

            return futurePoint;
        }
    }
}
