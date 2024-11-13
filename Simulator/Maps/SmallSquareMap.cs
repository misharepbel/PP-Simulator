namespace Simulator.Maps;

public class SmallSquareMap : Map
{
    private int size;
    private Rectangle check;
    public SmallSquareMap(int size)
    {
        if (size < 5)
        {
            throw new ArgumentOutOfRangeException(nameof(size), "Can't create a map that small.");
        }
        if (size > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(size), "Can't create a map that big.");
        }
        check = new(0, 0, size - 1, size - 1);
        this.size = size;
    }
    public int Size
    {
        get => size;
    }
    public override bool Exist(Point p)
    {
        return check.Contains(p);
    }
    public override Point Next(Point p, Direction d)
    {
        return d switch
        {
            Direction.Up => p.Y == Size - 1 ? p : p.Next(d),
            Direction.Down => p.Y == 0 ? p : p.Next(d),
            Direction.Right => p.X == Size - 1 ? p : p.Next(d),
            Direction.Left => p.X == 0 ? p : p.Next(d),
            _ => default,
        };
    }
    public override Point NextDiagonal(Point p, Direction d)
    {
        return d switch
        {
            Direction.Up => p.Y == Size - 1 || p.X == Size - 1 ? p : p.NextDiagonal(d),
            Direction.Down => p.Y == 0 || p.X == 0 ? p : p.NextDiagonal(d),
            Direction.Right => p.X == Size - 1 || p.Y == 0 ? p : p.NextDiagonal(d),
            Direction.Left => p.X == 0 || p.Y == Size - 1 ? p : p.NextDiagonal(d),
            _ => default,
        };
    }
}