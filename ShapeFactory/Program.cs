using Bogus;
using ShapeFactory;
using ShapeFactory.Domain;

Faker faker = new();
Painter painter = new(faker);

//const string basePath = @"/Users/gabrielececutti/Desktop/ShapeFactory/shape-ires/files"; 
const string basePathFileExcel = @"/Users/gabrielececutti/Desktop/ShapeFactory/shape-ires/excelFiles";

var workflow = new Workflow(basePathFileExcel);
var reader = new Reader(",");
var excelReader = new ExcelReader();

var app = new App(new(), painter, new(), new(), workflow, reader, excelReader);

Welcome();
Console.WriteLine("");
app.Run();  // (root) files --> working --> completed / failed --> repeat until root and failed are empty
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


