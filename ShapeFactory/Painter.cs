namespace ShapeFactory;

using Bogus;
using Domain;

public class Painter
{
    private readonly IEnumerable<string> _colors;
    private readonly Faker _faker;

    public Painter(Faker faker)
    {
        _faker = faker;
        _colors = new[] { "R", "G", "B", "NO COLOR" };
    }

    private static void PaintShape(Shape shape, string color) 
    {
        Console.Write($"Paint({shape})");
        shape.Color = color;
        Console.WriteLine($" => {shape}");
    }

    private static void NoPaintShape(Shape shape)
    {
        Console.Write($"Paint({shape})");
        Console.WriteLine($" => NOT PAINTED");
    }

    public IEnumerable<Shape> Paint(IEnumerable<Shape> shapes)
    {
        foreach (var shape in shapes)
        {
            switch (_faker.PickRandom(_colors))
            {
                case "R":
                    PaintShape(shape, "R");
                    yield return shape;
                    break;
                case "G":
                    PaintShape(shape, "G");
                    yield return shape;
                    break;
                case "B":
                    PaintShape(shape, "B");
                    yield return shape;
                    break;
                default:
                    NoPaintShape(shape);
                    yield return shape;
                    break;
            }
        }
    }
}