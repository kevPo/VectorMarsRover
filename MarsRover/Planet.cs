using System;
using System.Collections.Generic;

namespace MarsRover
{
    public class Planet
    {
        public IEnumerable<Point> Obstacles;
        private Int32 size;

        public Int32 PositiveBorder { get { return size / 2; } }
        public Int32 NegativeBorder { get { return size / 2 - size; } }

        public Planet(Int32 planetSize, IEnumerable<Point> obstacles)
        {
            if (planetSize % 2 != 0)
                size = planetSize - 1;
            else
                size = planetSize;
            
            Obstacles = obstacles;
        }
    }
}
