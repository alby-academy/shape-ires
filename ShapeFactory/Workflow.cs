namespace ShapeFactory;

public class Workflow
{
    private readonly string _basePath;

    public Workflow(string basePath) => _basePath = basePath;

    public void Infrastructure(IEnumerable<string> paths)
    {
        foreach (var path in paths) Directory.CreateDirectory(Path.Combine(_basePath, path));
    }

    public IEnumerable<string> Pending(string source) => Directory.GetFiles(Path.Combine(_basePath, source));

    public bool TryMove(string file, string destination)
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
}