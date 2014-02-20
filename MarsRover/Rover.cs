using System;
using MarsRover.States;

namespace MarsRover
{
    public class Rover
    {
        private const Int32 positiveDirection = 1;
        private const Int32 negativeDirection = -1;

        public Boolean IsObstructed { get; private set; }
        public Point Obstruction { get; private set; }

        private Point currentPoint;
        private State state;

        public Rover(Point point, Char direction, IStateFactory stateFactory, Planet planet)
        {
            currentPoint = point;
            state = stateFactory.BuildState(this, direction, planet);
        }

        public Point GetCurrentPosition()
        {
            return currentPoint;
        }

        public void SetPosition(Point point)
        {
            currentPoint = point;
        }

        public void SetObstruction(Point obstruction)
        {
            IsObstructed = true;
            Obstruction = obstruction;
        }

        public void SetState(State state)
        {
            this.state = state;
        }
        
        public void TurnRight()
        {
            state.TurnRight();
        }

        public void TurnLeft()
        {
            state.TurnLeft();
        }

        public void MoveBackward()
        {
            state.MoveBackward();
        }

        public void MoveForward()
        {
            state.MoveForward();
        }
    }
}
