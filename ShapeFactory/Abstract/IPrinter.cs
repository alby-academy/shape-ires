namespace ShapeFactory.Abstract;

using Domain;

public interface IPrinter
{
    public void Print(IEnumerable<Shape> shapes);
}