using System;
using System.Linq;
namespace MarsRover.States
{
    public abstract class State
    {
        public abstract void MoveForward();
        public abstract void MoveBackward();
        public abstract void TurnLeft();
        public abstract void TurnRight();
    }
}
