namespace ShapeFactory.Abstract;

using Domain;

public interface IReader
{
    IEnumerable<Shape> Read(string path);
}