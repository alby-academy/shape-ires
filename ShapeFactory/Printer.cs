namespace ShapeFactory;

using System;
using Domain;

public class Printer
{
    private static void PrintShape(Shape shape)
    {
        Console.Write($"Print({shape})");
        Console.WriteLine($" => {shape.IdToString()} {shape.AnglesToString()} is {shape.ColorToString()}");
    }
    
    public void Print(IEnumerable<Shape> shapes)
    {
        var enumerator = shapes.GetEnumerator();
        while (enumerator.MoveNext())
        {
            PrintShape(enumerator.Current);
        }
    }
}