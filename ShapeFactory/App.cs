namespace ShapeFactory;

using Bogus;

public class App
{
    private readonly Checker _checker;
    private readonly Painter _painter;
    private readonly Printer _printer;
    private readonly Provider _provider;
    
    public App(Provider provider, Painter painter, Checker checker, Printer printer)
    {
        _provider = provider;
        _painter = painter;
        _checker = checker;
        _printer = printer;
    }

    public void Run()
    {
        Console.WriteLine("Run Start");
        var shapes = _provider.Provide();

        shapes = _painter.Paint(shapes);

        shapes = _checker.Check(shapes);

        _printer.Print(shapes);
        Console.WriteLine("Run End");
    }
}