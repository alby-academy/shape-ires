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

        _workflow.CreateStructure();
        _workflow.PendingTEST();
	    
	    // var filesS = _workflow.PendingInStarting();
        // foreach (var fS in filesS) Console.WriteLine(fS);

        // _workflow.TryMoveFiles("starting", "working");
        
        // var filesW = _workflow.PendingInWorking();
        // foreach (var fW in filesW) Console.WriteLine(fW);

        // var shapes = _reader.Read(files);

        // var shapes = Provide();
        // shapes = _painter.Paint(shapes);
        // shapes = _checker.Check(shapes);
        // _printer.Print(shapes);

        // _workflow.TryMoveFiles("working", "ending");


        Console.WriteLine("Run End");
    }
}