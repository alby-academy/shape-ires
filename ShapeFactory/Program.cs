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
    const string basePath = @"C:\Training\shape-ires\Files";
    var options = new Options(basePath, "working", "completed", "failed", "xlsx");
    var workflow = new Workflow(options);

    var reader = new ExcelReader();
    var painter = new Painter(new());
    var checker = new Checker();
    var printer = new ExcelPrinter(basePath);

    return new(workflow, reader, painter, checker, printer);
}