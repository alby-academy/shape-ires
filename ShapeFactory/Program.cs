using Bogus;
using ShapeFactory;

Faker faker = new();
Painter painter = new(faker);

const string basePath = @"C:\Training\facotry-ires\files";
var workflow = new Workflow(basePath);

var reader = new Reader(",");

var app = new App(new(), painter, new(), new(), workflow, reader);

Welcome();
Console.WriteLine("");
app.Run();
Console.WriteLine("");
Wait();
Console.WriteLine("");
SeeYouSoon();


static void Welcome() => Console.WriteLine("Welcome to ShapesApp.");

static void Wait()
{
    Console.WriteLine("Waiting Input.");
    Console.ReadKey();
    Console.WriteLine("");
}

static void SeeYouSoon() => Console.WriteLine("See You Soon.");