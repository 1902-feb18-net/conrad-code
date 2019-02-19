using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Library
{
    public class Rectangle : IShapes
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int NumSides { get; set; } = 4;

        public double Length { get; set; }
        public double Width { get; set; }

        public double CalculateArea()
        {
            return Length * Width;
        }

        public double CalculatePerim()
        {
            return 2 * Length + 2 * Width;
        }
    }
}
