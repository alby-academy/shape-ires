using ShapeFactory;
using ShapeFactory.Core;

Welcome();
BuildApp().Run();
Wait();
SeeYouSoon();

await Task.Delay(4000);

static void Welcome()
{
    Console.WriteLine("Welcome to ShapesApp.");
    Console.WriteLine();
}

static void Wait()
{
    Console.WriteLine("Waiting Input.");
    Console.ReadLine();
    Console.WriteLine();
}

static void SeeYouSoon() => Console.WriteLine("See You Soon.");

App BuildApp()
{
    var options = new Options(@"C:\Training\shape-ires\Files", "working", "completed", "failed", "txt");
    var workflow = new Workflow(options);

    const string separator = ",";
    var reader = new Reader(separator);
    var painter = new Painter(new());
    var checker = new Checker();
    var printer = new Printer();

    return new(workflow, reader, painter, checker, printer);
}