namespace ShapeFactory.Core;

using Domain;

public class Checker
{
    public IEnumerable<Shape> Check(IEnumerable<Shape> shapes) => shapes.Where(shape => shape.Color != null);
}