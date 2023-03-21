namespace ShapeFactory.Abstract;

using Domain;

public interface IPrinter : IDisposable
{
    public void Print(IEnumerable<Shape> shapes);
}