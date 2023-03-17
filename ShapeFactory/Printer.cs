using ShapeFactory.Domain;

namespace ShapeFactory
{
    public class Printer
    {
        public void Print(IEnumerable<Shape> shapes)
        {
            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.ToString());
            }
        }
    }
}