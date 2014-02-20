using System;
using MarsRover.States;

namespace MarsRover
{
    public interface IStateFactory
    {
        State BuildState(Rover rover, Char direction, Planet planet);
    }
}
