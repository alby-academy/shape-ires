namespace ShapeFactory.Domain;

public class Shape
{
    public int Id { get; set; }
    public int Angles { get; set; }
    public string Color { get; set; }

    public Shape(int id = default, int angles = default, string color = default)
    {
        Id = id;
        Angles = angles;
        Color = color;
    }

    public override string ToString()
    {
        return $"Shape: ID = {Id}, Angles = {Angles}, Color = {Color}";
    }
}