namespace ShapeFactory.Core;

using System.Text;
using Abstract;
using Domain;
using ExcelDataReader;
using Exceptions;

public class ExcelReader : IReader
{
    public IEnumerable<Shape> Read(string path)
    {
        using var stream = File.Open(path, FileMode.Open, FileAccess.Read);
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        using var reader = ExcelReaderFactory.CreateReader(stream);

        while (reader.Read())
        {
            if (reader.Depth == 0) continue;

            Shape shape = null;

            try
            {
                var id = $"{reader.GetValue(0)}";
                var angles = $"{reader.GetValue(1)}";

                if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(angles)) yield break;

                shape = Parse(id, angles);
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

    private static Shape Parse(string idValue, string anglesValue)
    {
        var idSuccess = int.TryParse(idValue, out var id);
        var anglesSuccess = int.TryParse(anglesValue, out var angles);

        if (!idSuccess) throw new InvalidIdException();
        if (!anglesSuccess) throw new InvalidAnglesException();

        return new(id, angles);
    }
}