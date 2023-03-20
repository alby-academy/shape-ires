namespace ShapeFactory;

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Domain;

public class Reader
{
    private readonly string _separator;

    public Reader(string separator)
    {
        _separator = separator;
    }

    public Reader() :
           this(",") { }


    public IEnumerable<Shape> Read(string path)
    {
        var lines = File.ReadAllLines(path);

        foreach (var line in lines.Skip(1))
        {
            var elements = line.Split(_separator);
            yield return new(int.Parse(elements[0]), int.Parse(elements[1]));
        }
    }

    public IEnumerable<Shape> ReadShapesInFile(string file)
    {
        Console.WriteLine($"Try Reading File: {file}");
        
        string[] lines;
        try 
        {
            lines = File.ReadAllLines(file);
            Console.WriteLine($"Reading File");
        } 
        catch(Exception ex)
        {
            lines = new[] { "" };
            Console.WriteLine("Cannot Read File");
            // Console.WriteLine($"Error: {ex}");
        }

        foreach (var line in lines)
        {
            var rawShape = line.Split(_separator);
            if(rawShape.Length >= 2 || rawShape.Length <= 3)
            {
                if (Shape.CheckStringId(rawShape[0]) && Shape.CheckStringId(rawShape[1]))
                {
                    yield return new(int.Parse(rawShape[0]), int.Parse(rawShape[1]));
                }
                else
                {
                    continue;
                    // yield return new();
                }
            }
            else
            {
                continue;
                // yield return new();
            }
        }
    }

    public IEnumerable<Shape> ReadShapesInFirstFile(IEnumerable<string> files)
    {
        Console.WriteLine($"Try Reading First File");
        return ReadShapesInFile(files.FirstOrDefault());
    }


    // DO NOT WORK, PLEASE DO NOT USE IT. IF YOU CAN MADE IT WORK!
    public IEnumerable<Shape> ReadShapesInFiles(IEnumerable<string> files)
    {
        foreach (var file in files)
        {
            foreach (var line in File.ReadAllLines(file))
            {
                var rawShape = line.Split(_separator);
                if (Shape.CheckStringId(rawShape[0]) && Shape.CheckStringId(rawShape[1]))
                {
                    yield return new(int.Parse(rawShape[0]), int.Parse(rawShape[1]));
                }
                else
                {
                    continue;
                    // yield return new();
                }
            }
        }
    }
}