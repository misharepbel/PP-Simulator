namespace Simulator.Maps;
public class SmallTorusMap : Map
{
    private readonly Rectangle check;
    public SmallTorusMap(int size)
    {
        if (size < 5)
        {
            throw new ArgumentOutOfRangeException(nameof(size), "Can't create a map that small.");
        }
        if (size > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(size), "Can't create a map that big.");
        }
        Size = size;
        check = new(0, 0, Size - 1, Size - 1);
    }
    public int Size { get; }
    public override bool Exist(Point p)
    {
        return check.Contains(p);
    }

    public override Point Next(Point p, Direction d)
    {
        return d switch
        {
            Direction.Up => new Point(p.X, (p.Y + 1) % Size),
            Direction.Down => p.Y == 0 ? new Point(p.X, Size-1) : p.Next(d),
            Direction.Right => new Point((p.X + 1) % Size, p.Y),
            Direction.Left => p.X == 0 ? new Point(Size - 1, p.Y) : p.Next(d),
            _ => default,
        };
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        return d switch
        {
            Direction.Up => new Point((p.X + 1) % Size, (p.Y + 1) % Size),
            Direction.Down => new Point(p.X == 0 ? Size - 1 : p.X - 1, p.Y == 0 ? Size - 1 : p.Y - 1),
            Direction.Right => new Point((p.X + 1) % Size, p.Y == 0 ? Size - 1 : p.Y - 1),
            Direction.Left => new Point(p.X == 0 ? Size - 1 : p.X - 1, (p.Y + 1) % Size),
            _ => default,
        };
    }
}
