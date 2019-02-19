using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Library
{
    public class Square : IShapes
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int NumSides { get; set; } = 4;

        public double SideLength { get; set; } = 0;

        public double CalculateArea()
        {
            return Math.Pow(SideLength, 2);
        }

        public double CalculatePerim()
        {
            return 4 * SideLength;
        }
    }
}
