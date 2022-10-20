namespace SolidPrinciples;

public class AreaCalculator
{
    public double GetArea(IShape shape)
    {
        if (shape is Square square)
        {
            return square.Length * 4;
        }
        else
        {
            return Math.PI * Math.Pow(((Circle)shape).Radius, 2);
        }
        //TODO: What if we would want to add triangle area calculation?
    }
}

public interface IShape
{
}

public class Square
{
    public int Length { get; set; }
}

public class Circle
{
    public int Radius { get; set; }
}