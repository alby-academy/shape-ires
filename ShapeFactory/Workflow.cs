namespace ShapeFactory;

public class Workflow
{
    private static Random random = new Random();
    private readonly string _basePath;

    public Workflow(string basePath) => _basePath = basePath;

    public string GetBasePath() => _basePath;

    public void Infrastructure(IEnumerable<string> paths)
    {
        foreach (var path in paths) Directory.CreateDirectory(Path.Combine(_basePath, path));
    }

    public IEnumerable<string> Pending(string source) => Directory.GetFiles(Path.Combine(_basePath, source));

    private bool TryMove(string file, string destination)
    {
        try
        {
            File.Move(
                Path.Combine(_basePath, file), 
                Path.Combine(_basePath, destination, Path.GetFileName(file)));
        }
        catch (Exception e)
        {
            return false;
        }
        return true;
    }

    // for testing
    private bool RandomFailureMove(string file, string destination)
    {
        int n = random.Next(0, 10);
        return (n > 1) ? TryMove(file, destination) : false;
    }

    public bool MoveFilesToDestination(IEnumerable<string> files, string destination)
    {
        bool success = true;
        foreach (var file in files)
        {
            bool moved = TryMove(file, destination);
            success = success && moved;
        }
        return success;
    }

    public bool RandomMoveFilesToDestination(IEnumerable<string> files, string destination)
    {
        bool success = true;
        foreach (var file in files)
        {
            bool moved = RandomFailureMove(file, destination);
            success = success && moved;
        }
        return success;
    }


}