using ShapeFactory.Domain;
using System;

namespace ShapeFactory
{
    public class App
    {
        private Provider _provider;
        private Painter _painter;
        private Checker _checker;
        private Printer _printer;

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
}