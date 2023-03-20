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

    public IEnumerable<Shape> OtherPaint(IEnumerable<Shape> shapes)
    {
        foreach (var shape in shapes)
        {
            var color = _faker.PickRandom(_colors);
            if(color is "R" or "G" or "B")
            {
                PaintShape(shape, color);
            }
            else
            {
                NoPaintShape(shape);
            }
            yield return shape;
        }
    }

    public IEnumerable<Shape> PaintWithRandom(IEnumerable<Shape> shapes)
    {
        var random = new Random();
        foreach (var shape in shapes)
        {
            switch (random.Next(0, 4))
            {
                case 1:
                    PaintShape(shape, "R");
                    yield return shape;
                    break;
                case 2:
                    PaintShape(shape, "G");
                    yield return shape;
                    break;
                case 3:
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

    public IEnumerable<Shape> OtherPaintWithRandom(IEnumerable<Shape> shapes)
    {
        var random = new Random();
        var enumerator = shapes.GetEnumerator();
        while (enumerator.MoveNext())
        {
            switch (random.Next(0, 4))
            {
                case 1:
                    PaintShape(enumerator.Current, "R");
                    yield return enumerator.Current;
                    break;
                case 2:
                    PaintShape(enumerator.Current, "G");
                    yield return enumerator.Current;
                    break;
                case 3:
                    PaintShape(enumerator.Current, "B");
                    yield return enumerator.Current;
                    break;
                default:
                    NoPaintShape(enumerator.Current);
                    yield return enumerator.Current;
                    break;
            }
        }
    }
}