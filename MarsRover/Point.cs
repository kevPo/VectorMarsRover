using System;

namespace MarsRover
{
    public class Point
    {
        public Int32 X { get; set; }
        public Int32 Y { get; set; }

        public Point()
        {}

        public Point(String rawCoordinates)
        {
            var coordinates = rawCoordinates.Split(',');
            X = Int32.Parse(coordinates[0]);
            Y = Int32.Parse(coordinates[1]);
        }

        public override String ToString()
        {
            return String.Join(",",  new [] { X, Y });
        }
    }
}
