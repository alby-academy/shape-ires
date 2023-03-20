using Bogus;
using ShapeFactory.Domain;

namespace ShapeFactory;

public class App
{
    private static Random random = new Random();
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

    // (root) "files" --> "working" --> "completed" or "failed" --> repeat until all the files are in completed
    public void Run()
    {
        Console.WriteLine("Run Start");
        _workflow.Infrastructure(new[] {@"working", @"failed", @"completed" });

        bool successRW = false; // indicates if all files from "files" have been moved to "working"
        bool successWC = false; // indicates if all files from "working" have been moved to "completed"
        bool successFW = false; // indicates if all files from "failed" have been moved to "working"
        do
        {
            // files --> working
            IEnumerable<string> rootFiles = Directory.GetFiles(_workflow.GetBasePath());
            successRW = _workflow.MoveFilesToDestination(rootFiles, "working");

            // execution
            IEnumerable<string> workingFiles = _workflow.Pending("working");
            foreach (var file in workingFiles)
            {
                try
                {
                    IEnumerable<Shape> shapes = _reader.Read(file);
                    shapes = _painter.Paint(shapes);
                    shapes = _checker.Check(shapes);
                    _printer.Print(shapes);
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine("Error. Please retry later");
                }
            }

            // working --> completed / failed
            successWC = _workflow.RandomMoveFilesToDestination(workingFiles, "completed");
            if (!successWC)
            {
                _workflow.MoveFilesToDestination(workingFiles, "failed");
            }

            //failed --> working
            IEnumerable<string> failedFiles = _workflow.Pending("failed");
            successFW = _workflow.MoveFilesToDestination(failedFiles, "working");

        } while (!successRW || !successWC || !successFW);
        Console.WriteLine("Run End");
    }
}