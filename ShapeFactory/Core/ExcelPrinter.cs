namespace ShapeFactory.Core;

using Abstract;
using Domain;
using SwiftExcel;

public class ExcelPrinter : IPrinter, IDisposable
{
    private readonly ExcelWriter _writer;

    public ExcelPrinter(string filename)
    {
        var sheet = new Sheet { Name = "Report" };
        var file = Path.Combine(filename, $"REPORT_{DateTime.Now:yyyy-MM-dd_hh-mm-dd}.xlsx");
        _writer = new(file, sheet);
    }

    public void Print(IEnumerable<Shape> shapes)
    {
        _writer.Write("Message", 1, 1);

        var messages = GetMessage(shapes);

        using var enumerator = messages.GetEnumerator();

        var rowNumber = 2;
        while (enumerator.MoveNext())
        {
            _writer.Write(enumerator.Current, 1, rowNumber);
            rowNumber++;
        }
    }

    public void Dispose() => _writer.Dispose();

    private static IEnumerable<string> GetMessage(IEnumerable<Shape> shapes)
    {
        foreach (var shape in shapes)
        {
            var message = shape switch
            {
                { Angles: 0, Color: "R" } => $"ID={shape.Id} CIRCLE is red. At {DateTime.Now:F}",
                { Angles: 4, Color: "R" } => $"ID={shape.Id} SQUARE is red. At {DateTime.Now:M}",
                { Angles: 0 } => $"ID={shape.Id} CIRCLE is yellow/blue. At {DateTime.Now:h:mm:ss tt zz}",
                not null => $"ID={shape.Id} SQUARE is {shape.Color.ToUpperInvariant()}",
                _ => throw new ArgumentOutOfRangeException(nameof(shape))
            };

            Console.WriteLine(shape.ToString());
            Console.WriteLine(message);
            Console.WriteLine("===========================================");

            yield return message;
        }
    }
}