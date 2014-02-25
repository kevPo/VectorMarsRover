using System;
using System.Linq;

namespace MarsRover
{
    public class Rover
    {
        private const Double radianRotationalTurn = Math.PI / 2;
        
        public Boolean IsObstructed { get; private set; }
        public Point Obstruction { get; private set; }

        private Vector currentPoint;
        private Double currentDirection;
        private Planet planet;

        public Rover(Point point, Char direction, Planet planet)
        {
            currentPoint = new Vector(point.X, point.Y);
            currentDirection = InitializeDirection(direction);
            this.planet = planet;
        }

        private Double InitializeDirection(char direction)
        {
            switch (direction)
            {
                case 'E':
                    return 2 * Math.PI;
                case 'N':
                    return Math.PI / 2;
                case 'W':
                    return Math.PI;
                case 'S':
                    return (3 * Math.PI) / 2;
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
            currentDirection -= radianRotationalTurn;
        }

        public void TurnLeft()
        {
            currentDirection += radianRotationalTurn;
        }

        public void MoveBackward()
        {
            var futurePosition = new Vector(currentPoint.X, currentPoint.Y);
            var direction = GetDirectionVector();
            futurePosition -= direction;
            MoveRover(futurePosition);
        }

        public void MoveForward()
        {
            var futurePosition = new Vector(currentPoint.X, currentPoint.Y);
            var direction = GetDirectionVector();
            futurePosition += direction;
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

        private Vector GetDirectionVector()
        {
            var directionVector = new Vector((Int32)Math.Cos(currentDirection), (Int32)Math.Sin(currentDirection));
            directionVector.Normalize();
            return directionVector;
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
