namespace ShapeFactory.Core;

using Abstract;
using Domain;
using Exceptions;

public class Reader : IReader
{
    private readonly string _separator;

    public Reader(string separator) => _separator = separator;

    public IEnumerable<Shape> Read(string path)
    {
        var lines = File.ReadAllLines(path);

        foreach (var line in lines.Skip(1))
        {
            Shape shape = default;

            try
            {
                shape = Parse(line);
                Console.WriteLine("READER: {0}", shape);
            }
            catch (Exception e) when (e is InvalidIdException or InvalidAnglesException)
            {
                Console.WriteLine("Cannot cast values. Error message: {0}", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unsuspected error occured. Error message: {0}", e.Message);
            }

            yield return shape;
        }
    }

    private Shape Parse(string line)
    {
        var elements = line.Split(_separator);

        var idSuccess = int.TryParse(elements[0], out var id);
        var anglesSuccess = int.TryParse(elements[1], out var angles);

        if (!idSuccess) throw new InvalidIdException();
        if (!anglesSuccess) throw new InvalidAnglesException();

        return new(id, angles);
    }
}