namespace ShapeFactory;

using Abstract;
using Core;

public class App
{
    private readonly Checker _checker;
    private readonly Painter _painter;
    private readonly IPrinter _printer;
    private readonly IReader _reader;
    private readonly Workflow _workflow;

    public App(Workflow workflow, IReader reader, Painter painter, Checker checker, IPrinter printer)
    {
        _workflow = workflow;

        _reader = reader;
        _painter = painter;
        _checker = checker;
        _printer = printer;
    }

    public void Run()
    {
        Console.WriteLine("App Start");

        _workflow.Infrastructure();
        var result = _workflow.MoveToWorking();
        if (!result)
        {
            Console.WriteLine("An error occured during the file movement");
            return;
        }

        foreach (var file in _workflow.Pending())
        {
            try
            {
                Work(file);
            }
            catch (Exception e)
            {
                var failed = _workflow.MoveToFailed(file);
                if (!failed) Console.WriteLine("Cannot move file {0} to failed folder", file);
            }

            var completed = _workflow.MoveToCompleted(file);
            if (!completed) Console.WriteLine("Cannot move to completed {0} folder", file);
        }
    }

    private void Work(string file)
    {
        var shapes = _reader.Read(file);
        var painted = _painter.Paint(shapes);
        var @checked = _checker.Check(painted);
        _printer.Print(@checked);
        _printer.Dispose();
    }
}