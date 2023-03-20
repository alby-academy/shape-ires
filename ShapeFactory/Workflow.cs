using System.Collections.Generic;
using System.IO;

namespace ShapeFactory;

public class Workflow
{
    private readonly string _basePath;
    private readonly string[] _directories;


    public Workflow(string basePath, string[] directories)
    {
        _basePath = basePath;
        _directories = directories;
    }

    public Workflow(string basePath) : 
	       this(basePath, new string[] { "starting", "working", "ending" }) { }

    public Workflow() :
           this(Path.GetFullPath("ShapeFiles"), new string[] { "starting", "working", "ending" }) { }


    public void CreateStructure()
    {
        foreach (var directory in _directories)
        {
            Directory.CreateDirectory(Path.Combine(_basePath, directory));
        }
    }


    public IEnumerable<string> Pending(string directory)
    {
        // Console.WriteLine(Path.Combine(_basePath, directory));
        // Console.WriteLine(Directory.Exists(Path.Combine(_basePath, directory)));
        // foreach (var file in Directory.GetFiles(Path.Combine(_basePath, directory), "*.txt")) Console.WriteLine(file);
        return Directory.GetFiles(Path.Combine(_basePath, directory), "*.txt");
    }

    public IEnumerable<string> PendingInStarting() => Pending(_directories[0]);
    public IEnumerable<string> PendingInWorking() => Pending(_directories[1]);
    public IEnumerable<string> PendingInEnding() => Pending(_directories[2]);


    public IEnumerable<string> PendingNames(string directory)
    {
        return Pending(directory).Select(file => Path.GetFileName(file));
    }

    public IEnumerable<string> PendingNamesInStarting() => PendingNames(_directories[0]);
    public IEnumerable<string> PendingNamesInWorking() => PendingNames(_directories[1]);
    public IEnumerable<string> PendingNamesInEnding() => PendingNames(_directories[2]);


    public bool TryMoveFile(string file, string directory1, string directory2)
    {
        try
        {
            Console.WriteLine($"{file} try moving from {directory1} to {directory2}.");
            File.Move(
                Path.Combine(_basePath, directory1, file),
                Path.Combine(_basePath, directory2, file));
        }
        catch (FileNotFoundException fileNotFound)
        {
            Console.WriteLine($"Error: {fileNotFound}");
            return false;
        }
        catch (DirectoryNotFoundException directoryNotFound)
        {
            Console.WriteLine($"Error: {directoryNotFound}");
            return false;
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Error: {exception}");
            return false;
        }
        return true;
    }

    public void MoveFile(string file, string directory1, string directory2) 
    {
        if (TryMoveFile(file, directory1, directory2))
        {
            Console.WriteLine($"{file} moved from {directory1} to {directory2}.");
        }
        else
        {
            Console.WriteLine($"{file} not moved from {directory1} to {directory2}, retry later.");
        }
    }


    public void MoveFirstFile(string directory1, string directory2)
    {
        try
        {
            string first = PendingNames(directory1).First();
            // Console.WriteLine(first);
	        MoveFile(first, directory1, directory2);
        }
        catch (Exception ex) when (ex is ArgumentNullException || ex is InvalidOperationException)
        {
            Console.WriteLine($"No Pending File");
        }
    }

    public void MoveFirstFileFromStartingToWorking() => MoveFirstFile(_directories[0], _directories[1]);
    public void MoveFirstFileFromWorkingToEnding() => MoveFirstFile(_directories[1], _directories[2]);
    public void MoveFirstFileFromEndingToStarting() => MoveFirstFile(_directories[2], _directories[0]);


    public void MoveFiles(string directory1, string directory2)
    {
        foreach (string file in PendingNames(directory1))
        {
            MoveFile(file, directory1, directory2);
        }
    }

    public void MoveFilesFromStartingToWorking() => MoveFiles(_directories[0], _directories[1]);
    public void MoveFilesFromWorkingToEnding() => MoveFiles(_directories[1], _directories[2]);
    public void MoveFilesFromEndingToStarting() => MoveFiles(_directories[2], _directories[0]);

}