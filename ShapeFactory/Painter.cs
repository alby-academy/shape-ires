using ShapeFactory.Domain;

namespace ShapeFactory
{
    public class Painter
    {
        public IEnumerable<Shape> Paint(IEnumerable<Shape> shapes)
        {
            Random random = new Random();
            foreach(var shape in shapes)
            {
                switch (random.Next(0, 4))
                {
                    case 1:
                        shape.Color = "R";
                        Console.WriteLine($"Paint({shape}) => {shape}");
                        yield return shape;
                        break;
                    case 2:
                        shape.Color = "G";
                        Console.WriteLine($"Paint({shape}) => {shape}");
                        yield return shape;
                        break;
                    case 3:
                        shape.Color = "B";
                        Console.WriteLine($"Paint({shape}) => {shape}");
                        yield return shape;
                        break;
                    default:
                        // shape.Color = null;
                        Console.WriteLine($"Paint({shape}) => {shape}");
                        yield return shape;
                        break;
                }
            }
        }

        public IEnumerable<Shape> OtherPaint(IEnumerable<Shape> shapes)
        {
            Random random = new Random();

            var enumerator = shapes.GetEnumerator();
            while (enumerator.MoveNext())
            {
                switch (random.Next(0, 4))
                {
                    case 1:
                        enumerator.Current.Color = "R";
                        yield return enumerator.Current;
                        break;
                    case 2:
                        enumerator.Current.Color = "G";
                        yield return enumerator.Current;
                        break;
                    case 3:
                        enumerator.Current.Color = "B";
                        yield return enumerator.Current;
                        break;
                    default:
                        // enumerator.Current.Color = null;
                        yield return enumerator.Current;
                        break;
                }
            }
        }
    }
}