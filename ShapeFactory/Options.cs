namespace ShapeFactory;

public class Options
{
    private readonly string _completed;
    private readonly string _failed;
    private readonly string _working;

    public Options(string basePath, string working, string completed, string failed, string pattern)
    {
        BasePath = basePath;
        Pattern = pattern;
        _working = working;
        _completed = completed;
        _failed = failed;
    }

    public string BasePath { get; }
    public string Pattern { get; }
    public string WorkingPath => Path.Combine(BasePath, _working);
    public string CompletedPath => Path.Combine(BasePath, _completed);
    public string FailedPath => Path.Combine(BasePath, _failed);

    public IReadOnlyCollection<string> GetAllDirectories => new[]
    {
        BasePath,
        WorkingPath,
        CompletedPath,
        FailedPath
    };
}