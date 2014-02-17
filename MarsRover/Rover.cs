
using System;
using System.Collections.Generic;
namespace MarsRover
{
    public class Rover
    {
        private Int32 X;
        private Int32 Y;

        public Rover(String roverStartingPoint, String direction)
        {
            var coordinates = roverStartingPoint.Split(',');
            X = Int32.Parse(coordinates[0]);
            Y = Int32.Parse(coordinates[1]);
        }

        public String GetCurrentPosition()
        {
            return String.Join(",", new Int32[] { X, Y });
        }
    }
}
