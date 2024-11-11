namespace Simulator;

public class Rectangle
{
	public bool exceptionFlag = false;
	public Rectangle(int x1, int y1, int x2, int y2)
	{
		try
		{
			if (x1 == x2 || y1 == y2)
			{
				throw new ArgumentException("Couldn't create rectangle. It's a line!");
			}
			if (x1 > x2)
			{
                (x1, x2) = (x2, x1);
            }
            if (y1 > y2)
			{
                (y1, y2) = (y2, y1);
            }
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }
		catch (ArgumentException exc)
		{
			Console.WriteLine(exc.Message);
            throw;
        }
	}
	public Rectangle(Point p1, Point p2) : this(p1.X, p1.Y, p2.X, p2.Y) { }
	public readonly int X1, Y1;
	public readonly int X2, Y2;
	public bool Contains(Point point)
	{
        return (X1 <= point.X && Y1 <= point.Y && X2 >= point.X && Y2 >=point.Y);
	}
	public override string ToString()
	{
		return $"({X1}, {Y1}):({X2}, {Y2})";
	}
}
