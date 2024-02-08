using System;
using System.Collections.ObjectModel;

class Program
{
    static void Main(string[] args)
    {
        // List of Shapes class, derived classes also work here
        List<Shape> shapesList = new List<Shape>();

        // Creates a new object of each type - passes arguments as required by each type's constructor -
        // and adds it to the Shapes list
        shapesList.Add(new Square("Pink", 2));
        shapesList.Add(new Rectangle("Green", 2, 5));
        shapesList.Add(new Circle("Blue", 5));

        foreach (Shape s in shapesList)
        {
            // Each object in the list is a shape, therefore they inherit these methods from the abstract class
            // GeatArea() is overriden in each for specific functionality
            Console.WriteLine($"Color: {s.GetColor()} -- Area: {s.GetArea()}");
        }
    }
}