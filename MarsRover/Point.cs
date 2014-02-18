using System;

namespace MarsRover
{
    public class Point
    {
        public Int32 X { get; set; }
        public Int32 Y { get; set; }

        public override String ToString()
        {
            return String.Join(",",  new [] { X, Y });
        }
    }
}
