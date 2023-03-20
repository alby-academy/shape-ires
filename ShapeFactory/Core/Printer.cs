namespace ShapeFactory.Core;

using Abstract;
using Domain;

public class Printer : IPrinter
{
    public void Print(IEnumerable<Shape> shapes)
    {
        using var enumerator = shapes.GetEnumerator();

        while (enumerator.MoveNext())
        {
            var message = enumerator.Current switch
            {
                { Angles: 0, Color: "R" } => $"ID={enumerator.Current.Id} CIRCLE is red. At {DateTime.Now:F}",
                { Angles: 4, Color: "R" } => $"ID={enumerator.Current.Id} SQUARE is red. At {DateTime.Now:M}",
                { Angles: 0 } => $"ID={enumerator.Current.Id} CIRCLE is yellow/blue. At {DateTime.Now:h:mm:ss tt zz}",
                not null => $"ID={enumerator.Current.Id} SQUARE is {enumerator.Current.Color.ToUpperInvariant()}",
                _ => throw new ArgumentOutOfRangeException(nameof(enumerator.Current))
            };

            Console.WriteLine(enumerator.Current.ToString());
            Console.WriteLine(message);
            Console.WriteLine("===========================================");
        }
    }
}