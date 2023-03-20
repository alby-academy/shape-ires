using Bogus;
using ShapeFactory;

var faker = new Faker();

var provider = new Provider();
var painter = new Painter(faker);
var checker = new Checker();
var printer = new Printer();
var workflow = new Workflow();
var reader = new Reader();

var app = new App(provider, painter, checker, printer, workflow, reader);

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
    Console.ReadLine();
    Console.WriteLine("");
}

static void SeeYouSoon() => Console.WriteLine("See You Soon.");