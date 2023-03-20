namespace ShapeFactory.Workflow;

public class Workflow
{
    private readonly string _basePath;
    private readonly string[] _directories;
    
    private Workflow(string basePath, string[] directories)
    {
        _basePath = basePath;
        _directories = directories;
    }

    public Workflow() : this(Path.GetFullPath("ShapeFiles"), new[] { "starting", "working", "ending" }) { }

    public void CreateStructure()
    {
        foreach (var directory in _directories)
        {
            Directory.CreateDirectory(Path.Combine(_basePath, directory));
        }
    }
    
    private IEnumerable<string> Pending(string directory) =>
        // Console.WriteLine(Path.Combine(_basePath, directory));
        // Console.WriteLine(Directory.Exists(Path.Combine(_basePath, directory)));
        // foreach (var file in Directory.GetFiles(Path.Combine(_basePath, directory), "*.txt")) Console.WriteLine(file);
        Directory.GetFiles(Path.Combine(_basePath, directory), "*.txt");

    public IEnumerable<string> PendingInStarting() => Pending(_directories[0]);
    public IEnumerable<string> PendingInWorking() => Pending(_directories[1]);
    public IEnumerable<string> PendingInEnding() => Pending(_directories[2]);


    private IEnumerable<string> PendingNames(string directory) => Pending(directory).Select(Path.GetFileName);
    
    private bool TryMoveFile(string file, string directory1, string directory2)
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

    private void MoveFile(string file, string directory1, string directory2)
    {
        Console.WriteLine(TryMoveFile(file, directory1, directory2) 
            ? $"{file} moved from {directory1} to {directory2}." 
            : $"{file} not moved from {directory1} to {directory2}, retry later.");
    }


    private void MoveFirstFile(string directory1, string directory2)
    {
        try
        {
            var first = PendingNames(directory1).First();
	        MoveFile(first, directory1, directory2);
        }
        catch (Exception ex) when (ex is ArgumentNullException or InvalidOperationException)
        {
            Console.WriteLine($"No Pending File");
        }
    }

    public void MoveFirstFileFromStartingToWorking() => MoveFirstFile(_directories[0], _directories[1]);
    public void MoveFirstFileFromWorkingToEnding() => MoveFirstFile(_directories[1], _directories[2]);
    public void MoveFirstFileFromEndingToStarting() => MoveFirstFile(_directories[2], _directories[0]);
}