using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Library
{
    public interface IShapes
    {
        string Name { get; set; }
        string Color { get; set; }
        int NumSides { get; set; }

        double CalculateArea();
    }
}
