using System;
using System.Linq;

namespace MarsRover.States
{
    public class FacingSouth : State
    {
        private Rover rover;
        private Planet planet;

        public FacingSouth(Rover rover, Planet planet)
        {
            this.rover = rover;
            this.planet = planet;
        }

        public override void MoveForward()
        {
            var nextPosition = FindNextPositionMovingUpYAxisBy(-1);

            if (planet.Obstacles.Any(o => o.X == nextPosition.X && o.Y == nextPosition.Y))
            {
                rover.SetObstruction(new Point { X = nextPosition.X, Y = nextPosition.Y });
                rover.SetState(new ObstructedState());
            }
            else
            {
                rover.SetPosition(new Point { X = nextPosition.X, Y = nextPosition.Y });
            }
        }

        public override void MoveBackward()
        {
            var nextPosition = FindNextPositionMovingUpYAxisBy(1);

            if (planet.Obstacles.Any(o => o.X == nextPosition.X && o.Y == nextPosition.Y))
            {
                rover.SetObstruction(new Point { X = nextPosition.X, Y = nextPosition.Y });
                rover.SetState(new ObstructedState());
            }
            else
            {
                rover.SetPosition(new Point { X = nextPosition.X, Y = nextPosition.Y });
            }
        }

        private Point FindNextPositionMovingUpYAxisBy(Int32 movementChange)
        {
            var currentPosition = rover.GetCurrentPosition();
            var nextPosition = new Point { X = currentPosition.X, Y = currentPosition.Y + movementChange };

            if (nextPosition.Y > planet.PositiveBorder)
                nextPosition.Y = planet.NegativeBorder;
            else if (nextPosition.Y < planet.NegativeBorder)
                nextPosition.Y = planet.PositiveBorder;

            return nextPosition;
        }

        public override void TurnLeft()
        {
            rover.SetState(new FacingEast(rover, planet));
        }

        public override void TurnRight()
        {
            rover.SetState(new FacingWest(rover, planet));
        }
    }
}
