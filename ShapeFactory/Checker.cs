namespace ShapeFactory;

using Domain;

public class Checker
{
    private static bool CheckShape(Shape shape) 
    {
        Console.Write($"Check({shape})");
        if (shape.Color is null)
        {
            Console.WriteLine($" => Bad => CONTINUE");
            return false;
        }
        else 
        {
            Console.WriteLine($" => Good => {shape}");
            return true;
        }
    }

    public IEnumerable<Shape> Check(IEnumerable<Shape> shapes)
    {
        foreach (var shape in shapes)
        {
            if (CheckShape(shape))
            {
                yield return shape;
            }
            else 
            {
                continue;
            }
        }
    }
}