using System;
using System.Linq;

namespace MarsRover.States
{
    public class FacingEast : State
    {
        private Rover rover;
        private Planet planet;

        public FacingEast(Rover rover, Planet planet)
        {
            this.rover = rover;
            this.planet = planet;
        }

        public override void MoveForward()
        {
            var nextPosition = FindNextPositionMovingAlongXAxisBy(1);

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
            var nextPosition = FindNextPositionMovingAlongXAxisBy(-1);

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

        private Point FindNextPositionMovingAlongXAxisBy(Int32 movementChange)
        {
            var currentPosition = rover.GetCurrentPosition();
            var nextPosition = new Point { X = currentPosition.X + movementChange, Y = currentPosition.Y };

            if (nextPosition.X > planet.PositiveBorder)
                nextPosition.X = planet.NegativeBorder;
            else if (nextPosition.X < planet.NegativeBorder)
                nextPosition.X = planet.PositiveBorder;

            return nextPosition;
        }

        public override void TurnLeft()
        {
            rover.SetState(new FacingNorth(rover, planet));
        }

        public override void TurnRight()
        {
            rover.SetState(new FacingSouth(rover, planet));
        }
    }
}
