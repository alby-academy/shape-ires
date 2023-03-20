namespace ShapeFactory.Core;

using Bogus;
using Domain;

public class Painter
{
    private readonly IEnumerable<string> _colors;
    private readonly Faker _faker;

    public Painter(Faker faker)
    {
        _faker = faker;
        _colors = new[] { "R", "G", "B" };
    }

    public IEnumerable<Shape> Paint(IEnumerable<Shape> shapes)
    {
        foreach (var shape in shapes)
        {
            var color = _faker.PickRandom(_colors).OrNull(_faker, 0.2f);
            shape.Color = color;

            Console.WriteLine("PAINTER: {0}", shape);
            if (color == null) Console.WriteLine("===========================================");

            yield return shape;
        }
    }
}