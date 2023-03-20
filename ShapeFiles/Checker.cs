namespace ShapeFactory;

using Domain;

public class Checker
{
    public IEnumerable<Shape> Check(IEnumerable<Shape> shapes)
    {
        foreach (var shape in shapes)
        {
            Console.Write($"Check({shape}) => ");
            if (shape.Color == null) continue;

            Console.WriteLine($"{shape}");
            yield return shape;
        }
    }
}