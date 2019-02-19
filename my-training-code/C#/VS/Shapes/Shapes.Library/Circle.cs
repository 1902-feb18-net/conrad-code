using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Library
{
    public class Circle : IShapes
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int NumSides { get; set; } = 0;

        public double Radius { get; set; } = 0;

        public double CalculateArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public double CalculateCircum()
        {
            return 2 * Math.PI * Radius;
        }
    }
}
