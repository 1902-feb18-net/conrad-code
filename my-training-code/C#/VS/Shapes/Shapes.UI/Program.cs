using System;
using Shapes.Library;

namespace Shapes.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            IShapes[] shapes = new IShapes[2];

            shapes[0] = new Circle
            {
                Name = "Jim",
                Color = "Blue",
                Radius = 5,
            };

            shapes[1] = new Square
            {
                Name = "Julie",
                Color = "Red",
                SideLength = 3,
            };

            Circle circle = (Circle)shapes[0];
            Console.WriteLine($"The Cicumference and Area of {circle.Name} are {circle.CalculateCircum()} " +
                $"and {circle.CalculateArea()}");

            Square square = (Square)shapes[1];
            Console.WriteLine($"The Perimeter and Area of {square.Name} are {square.CalculatePerim()} " +
                $"and {square.CalculateArea()}");
        }
    }
}
