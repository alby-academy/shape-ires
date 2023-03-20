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


    public string IdToString()
    {
        return "ID={" + Id + "}";
    }

    public string AnglesToString()
    {
        switch (Angles)
        {
            case 0:
                return "CIRCLE";
            case 4:
                return "SQUARE";
            default:
                return null;
        }
    }

    public string ColorToString()
    {
        switch (Color)
        {
            case "R":
                return "red";
            case "G":
                return "green";
            case "B":
                return "blue";
            default:
                return null;
        }
    }
    

    public static bool CheckId(int id)
    {
        if (id >= 0 || id <= 9)
        {
            return true;
        }
        return false;
    }

    public static bool CheckAngles(int angles)
    {
        if (angles == 0 || angles == 4)
        {
            return true;
        }
        return true;
    }

    public static bool CheckColor(string color)
    {
        if (color == "R" || color == "G" || color == "B")
        {
            return true;
        }
        return false;
    }


    public static bool CheckStringId(string s)
    {
        int id;
        try
        {
            id = int.Parse(s);
        }
        catch (Exception ex) when (ex is ArgumentException || ex is FormatException || ex is OverflowException)
        {
            return false;
        }
        return CheckId(id);
    }

    public static bool CheckStringAngles(string s)
    {
        int angles;
        try
        {
            angles = int.Parse(s);
        }
        catch (Exception ex) when (ex is ArgumentException || ex is FormatException || ex is OverflowException)
        {
            return false;
        }
        return CheckAngles(angles);
    }
}