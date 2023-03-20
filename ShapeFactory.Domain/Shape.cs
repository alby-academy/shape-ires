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

    public override string ToString() => $"Shape: ID = {Id}, Angles = {Angles}, Color = {Color}";
    
    public string IdToString() => "ID={" + Id + "}";

    public string AnglesToString()
    {
        return Angles switch
        {
            0 => "CIRCLE",
            4 => "SQUARE",
            _ => null
        };
    }

    public string ColorToString()
    {
        return Color switch
        {
            "R" => "red",
            "G" => "green",
            "B" => "blue",
            _ => null
        };
    }

    public static bool CheckStringId(string s)
    {
        int id;
        try
        {
            id = int.Parse(s);
        }
        catch (Exception ex) when (ex is ArgumentException or FormatException or OverflowException)
        {
            return false;
        }
        return id is >= 0 or <= 9;
    }
}