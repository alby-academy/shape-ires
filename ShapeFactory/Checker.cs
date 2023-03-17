using System;
using System.Collections.Generic;
using ShapeFactory.Domain;

namespace ShapeFactory
{
    public class Checker
    {
        public IEnumerable<Shape> Check(IEnumerable<Shape> shapes) 
	    {
            foreach (var shape in shapes)
            {
                Console.Write($"Check({shape}) => ");
                if (shape.Color != null)
                {
                    Console.WriteLine($"{shape}");
                    yield return shape;
                }
            }
        }
    }
}