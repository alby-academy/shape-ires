namespace ShapeFactory;

public class App
{
    private readonly Checker _checker;
    private readonly Painter _painter;
    private readonly Printer _printer;
    private readonly Provider _provider;
    private readonly Reader _reader;
    private readonly Workflow _workflow;

    public App(Provider provider, Painter painter, Checker checker, Printer printer, Workflow workflow, Reader reader)
    {
        _provider = provider;
        _painter = painter;
        _checker = checker;
        _printer = printer;
        _workflow = workflow;
        _reader = reader;
    }

    public void Run()
    {
        Console.WriteLine("Run Start");

        _workflow.Infrastructure(new[] { @"working", @"completed" });
        var moved = _workflow.TryMove("Shapes.txt", "working");

        if (!moved)
        {
            Console.WriteLine("Error. Please retry later");
            return;
        }

        var files = _workflow.Pending("working");

        var shapes = _reader.Read(files.FirstOrDefault());

        shapes = _painter.Paint(shapes);

        shapes = _checker.Check(shapes);

        _printer.Print(shapes);

        _workflow.TryMove("working\\Shapes.txt", "completed");


        Console.WriteLine("Run End");
    }
}