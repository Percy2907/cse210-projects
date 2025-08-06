using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Shapes Project.");

        Square square = new Square("Red", 4);
        Rectangle rectangle = new Rectangle("Blue", 5, 3);
        Circle circle = new Circle("Green", 2);

        List<Shape> shapes = new List<Shape>();
        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);
        
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()}");
            Console.WriteLine($"Area: {shape.GetArea():F2}");
            Console.WriteLine();
        }
    }
}