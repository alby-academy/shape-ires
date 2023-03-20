namespace ShapeFactory;

using Domain;

public class Reader
{
    private readonly string _separator;

    public Reader(string separator) => _separator = separator;

    public IEnumerable<Shape> Read(string path)
    {
         var lines = File.ReadAllLines(path);

        foreach (var line in lines.Skip(1))
        {
            var elements = line.Split(_separator);
            yield return new(int.Parse(elements[0]), int.Parse(elements[1]));
        }
    }
}