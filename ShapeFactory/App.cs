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

        _workflow.CreateStructure(); // creates directories: starting, working, ending

        // moves files from ending to starting (NOT REQUIRED BUT HELPS)
        _workflow.MoveFirstFileFromEndingToStarting();
        // _workflow.MoveFilesFromEndingToStarting();
        var filesInStarting = _workflow.PendingInStarting();
        // Console.WriteLine(filesInStarting.FirstOrDefault());

        // moves files from starting to working (REQUIRED)
        _workflow.MoveFirstFileFromStartingToWorking();
        // _workflow.MoveFilesFromStartingToWorking();
        var filesInWorking = _workflow.PendingInWorking();
        // Console.WriteLine(filesInWorking.FirstOrDefault());

        // work on files!
        // var shapes = _reader.Read(filesInWorking.FirstOrDefault()); // OLD WAY
        var shapes = _reader.ReadShapesInFirstFile(filesInWorking);

        // var shapes = Provide();
        shapes = _painter.Paint(shapes);
        shapes = _checker.Check(shapes);
        _printer.Print(shapes);


        // moves files from working to ending (REQUIRED) 
        _workflow.MoveFirstFileFromWorkingToEnding();
        // _workflow.MoveFilesFromWorkingToEnding();
        var filesInEnding = _workflow.PendingInEnding();
        // Console.WriteLine(filesInEnding.FirstOrDefault());

        Console.WriteLine("Run End");
    }
}