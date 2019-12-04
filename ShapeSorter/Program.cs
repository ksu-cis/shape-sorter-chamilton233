using System;
using System.Collections.Generic;
using System.Linq;
namespace ShapeSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fun With Shapes!");

            List<IShape> shapes = new List<IShape>()
            {
                new Circle(4),
                new Rectangle(3.2, 5.9),
                new Square(10),
                new Square(7),
                new Circle(7)
            };
            Console.WriteLine("---------------------------------------");

            foreach (IShape shape in shapes)
            {
                Console.WriteLine(shape.Area);
            }
            Console.WriteLine("---------------------------------------");

            IEnumerable<IShape> filteredShapes = shapes.Where(shape => shape.Area > 50);
            Console.WriteLine($"Shape with area greater than 50");
            foreach (IShape shape in filteredShapes)
            {
                Console.WriteLine(shape.Area);
            }

            IEnumerable<Circle> circles = shapes.OfType<Circle>();
            Console.WriteLine("---------------------------------------");
            foreach (Circle shape in circles)
            {
                Console.WriteLine($"Circle of rauius:{shape.Radius} and area of {shape.Area}");
            }

            IEnumerable<Circle> Fileteredcircles = circles.Where(shape => shape.Area>60);
            Console.WriteLine("---------------------------------------");
            foreach (Circle shape in Fileteredcircles)
            {
                Console.WriteLine($"Circle of rauius:{shape.Radius} and area of {shape.Area}");
            }
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"Combined example");
            foreach (Circle circle in shapes.OfType<Circle>().Where(c => c.Radius < 4.5))
            {
                Console.WriteLine($"Circle of rauius:{circle.Radius} and area of {circle.Area}");
            }

            Console.WriteLine("Group by type");
            var groupedShapes = shapes.GroupBy(shape => shape.GetType());

            foreach (var group in groupedShapes)
            {
                Console.WriteLine($"Shapes of type {group.Key}");
                foreach (IShape shape in group)
                {
                    Console.WriteLine($"The area of this shape is {shape.Area}");
                }
            }
            Console.WriteLine("---------------------------------------");

            var groupedbyarea = shapes.GroupBy(shape => shape.Area%2==0);
            foreach (var group in groupedbyarea)
            {
                Console.WriteLine(group.Key? "Even areas":"Odd areas");
                foreach (IShape shape in group)
                {
                    Console.WriteLine($"The area of this shape is {shape.Area}");
                }
            }

            Console.ReadKey();
        }
    }
}
