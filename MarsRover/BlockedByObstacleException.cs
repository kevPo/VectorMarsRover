using System;

namespace MarsRover
{
    public class BlockedByObstacleException : Exception
    {
        public BlockedByObstacleException(String message)
            : base(message)
        {
        }
    }
}
