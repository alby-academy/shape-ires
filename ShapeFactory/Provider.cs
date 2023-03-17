using System.Collections.Generic;
using ShapeFactory.Domain;

namespace ShapeFactory
{
    public class Provider
    {
        public IEnumerable<Shape> Provide()
        {
            Random random = new Random();
            foreach (var i in Enumerable.Range(0, 10))
            {
                var shape = new Shape(i, (random.Next(0, 4) < 2 ? 0 : 4));
                Console.WriteLine($"Provide() => {shape}");
                yield return shape;
            }

        }
    }
}