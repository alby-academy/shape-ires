namespace ShapeFactory.Core;

public class Workflow
{
    private readonly Options _options;

    public Workflow(Options options) => _options = options;

    public void Infrastructure()
    {
        foreach (var directory in _options.GetAllDirectories) Directory.CreateDirectory(directory);
    }

    public IEnumerable<string> Pending() => TryGetFiles(_options.WorkingPath);

    public bool MoveToWorking() => TryGetFiles(_options.BasePath).Aggregate(true, (current, file) => current && TryMove(file, _options.WorkingPath));
    public bool MoveToCompleted(string file) => TryMove(Path.Combine(_options.BasePath, file), _options.CompletedPath);
    public bool MoveToFailed(string file) => TryMove(Path.Combine(_options.BasePath, file), _options.FailedPath);

    private IEnumerable<string> TryGetFiles(string path)
    {
        try
        {
            return Directory.GetFiles(path, $"*.{_options.Pattern}");
        }
        catch
        {
            Console.WriteLine("Cannot get files");
            return Enumerable.Empty<string>();
        }
    }

    private static bool TryMove(string source, string destination)
    {
        try
        {
            File.Move(source, Path.Combine(destination, Path.GetFileName(source)));
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}